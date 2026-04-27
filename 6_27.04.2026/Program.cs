using Microsoft.VisualBasic;
using Newtonsoft.Json;      // для него придется качать плагин

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("HarryPotter", 102);
            movie1.Add(5);
            movie1.Add(5);
            movie1.Add(4);

            var temp = new
            {
                MovieType = movie1.GetType().Name,
                movie1.Name,
                movie1.Duration,
                movie1.Review
            };
            
            
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath1 = Path.Combine(folderPath, "Test", "example.json");

            string json = JsonConvert.SerializeObject(temp);
            File.WriteAllText(filePath1, json);

            // десериализация
            string content = File.ReadAllText(filePath1);
            var newJson = JsonConvert.DeserializeObject<dynamic>(content);

            Movie movie2 = new Movie((string)newJson.Name, (int)newJson.Duration);  // надо приводить
            foreach (int n in newJson.Review)
            {
                movie2.Add((int)n);
            }




            // File (статические методы, работа с файлом), Directory (статические методы, работа с папкой),
            // FileInfo (НЕстатические методы),            DirectoryInfo (НЕстатические методы)

            // Получение путей к папкам

            // Абсолютные пути (конкретный адрес C:/Users/...)
            // Относительный путь (Relative path) (в соседней квартире)
            // "data.txt" (относительный путь к файлу data.txt если он находится в той же папке)
            // "dataset/data.txt (data.txt находится в папке dataset)

            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);   // Записывает в переменную путь до рабочего стола на ЭТОМ компьютере
            //string filePath = Path.Combine(folderPath, "example.txt");   // Нужен Path.Combine() для того чтобы ставился правильный слеш на разных системах

            /*if (File.Exists(filePath))
            {
                Console.WriteLine("Существует на компьютере");
            }
            else
            {
                Console.WriteLine("Не существует на компьютере");
                //FileStream fs = File.Create(filePath);
                //fs.Close();
                File.Create(filePath).Close();      // .Close() нужен обязательно
                Console.WriteLine("Файл создан");
            }*/


            //string folderPath1 = Path.Combine(folderPath, "Test", "example.txt");     // Test - папка, exapmle.txt - файл
            /* string folderPath1 = Path.Combine(folderPath, "Test");
             string filePath1 = Path.Combine(folderPath1, "example.txt");

             if (!Directory.Exists(folderPath1))
             {
                 Directory.CreateDirectory(folderPath1);
             }

             if (!File.Exists(filePath1))
             {
                 File.Create(filePath1).Close();
             }

             string folderPathCheck = Path.GetDirectoryName(folderPath1);
             string fileNameCheck = Path.GetFileName(filePath1);
             string fileExtensionCheck = Path.GetExtension(filePath1);

             //Console.WriteLine(fileExtensionCheck);

             File.WriteAllText(filePath1, "REDACTED");       // записывает в файл сроку (создает файл если его не было) (перезаписывает содержимое файла)
             File.WriteAllLines(filePath1, new string[] { "So", "cold", "today"});       // записывает каждое слово в новую строку (перезаписывает содржимое)

             File.WriteAllText(filePath1, "");       // очистит файл

             File.AppendAllText(filePath1, "REDACTED");      // добавляет текст к уже существующему содержимому (не будет переноса строки "REDACTEDSo")
             File.AppendAllLines(filePath1, new string[] { "So", "cold", "today" });     // добавляет текст (будет перенос строки         "cold")

             string readFile = File.ReadAllText(filePath1);      // Read не сможет создать файл как Write или Append
             string[] lines = File.ReadAllLines(filePath1);
             Console.WriteLine(readFile);
             foreach(string line in lines)
             {
                 Console.WriteLine(line);
             }

             File.Delete(filePath1);*/
        }
    }

    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _review;

        public string Name => _name;
        public int Duration => _duration;
        public int[] Review => _review; //...

        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _review = new int[0];
        }

        public void Add(int num)
        {
            Array.Resize(ref _review, _review.Length + 1);
            _review[_review.Length - 1] = num;
        }
    }

}
