using System.ComponentModel;
using System.Numerics;
using System.Xml.Serialization;     //обязательно нужно для работы с xml

namespace ConsoleApp6
{
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _rating;

        public string Name => _name;
        public int Duration => _duration;
        public int[] Rating => _rating.ToArray();

        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _rating = new int[0];
        }
        public void Add (int stars)
        {
            Array.Resize(ref _rating, _rating.Length +1);
            _rating[_rating.Length - 1] = stars;
        }
    }

    public class MovieDTO   // дополнительный класс для сериализатора
    {
        public string Name { get; set; }    // так делаем чтобы быстро создать публичный геттер и сеттер
        public int Duration { get; set; }
        public int[] Rating { get; set; }
        public MovieDTO() { }       // этот конструктор нужен только сериализатору
        public MovieDTO(string name, int duration, int[] rating)      // нужен только один из двух конструкторов (в этом придется переопределять каждый элемент)
        {
            Name = name;
            Duration = duration;
            Rating = rating;
        }

        public MovieDTO(Movie movie)    // здесь гораздо удобнее просто передать сам обьект
        {
            Name = movie.Name;
            Duration = movie.Duration;
            Rating = movie.Rating;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // обьект для сериализации
            Movie m1 = new Movie("тьфу", 10);
            m1.Add(5);
            m1.Add(8);
            m1.Add(9);
            MovieDTO mDTO = new MovieDTO(m1);

            // создать путь до файла
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "movie.xml");

            // создать xml-сериализатор
            // класс должен иметь конструктор без параметров
            // класс должен быть публичным
            // в классе все свойства должны иметь публичные геттеры и сеттеры

            // превратить оригинальный обьект в dto обьект => отдать его в сериализатор
            var  serializer = new XmlSerializer(typeof(MovieDTO));      // просто записать сюда Movie нельзя, так как у класса приватные сеттеры
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, mDTO);
            }

            // десереализировать обьект из файла => получаем ДТО обьект => оригинальный обьект
            MovieDTO mDTO2; 
            using (var reader = new StreamReader(filePath))
            {
                mDTO2 = (MovieDTO)serializer.Deserialize(reader);       // переделываем то что он прочитал из класса Object в класс MovieDTO и сохраняем в mDTO2
            }
            Movie m2 = new Movie(mDTO2.Name, mDTO2.Duration);
            foreach (var item in m1.Rating)     // нужно если есть массивы потому что сериализатор не переносит эту информацию (по карйней мере в данном случае)
            {
                m2.Add(item);
            }
            //Console.WriteLine(m1.Name + ": " + m1.Duration);
            //Console.WriteLine(m2.Name + ": " + m2.Duration);
            Console.WriteLine(CompareMovies(m1, m2));
            
        }
        private static bool CompareMovies(Movie movie1, Movie movie2)
        {
            if (movie1.Name != movie2.Name) return false;
            if (movie1.Duration != movie2.Duration) return false;
            if (movie1.Rating.Length != movie2.Rating.Length) return false;
            else
            {
                for (int i = 0; i <  movie1.Rating.Length; i++)
                {
                    if (movie1.Rating[i] != movie2.Rating[i]) return false;
                }
            }
            return true;
        }
    }

}
