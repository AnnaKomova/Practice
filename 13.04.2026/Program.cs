namespace Lab9
{
    public class Program
    {
        public static void Main()
        {
                // Contains (возвращает bool)

            string word = "Hello";
            //Console.WriteLine(word.Contains("ll"));
            //Console.WriteLine(word.Contains("oll"));

            //if (word.Contains("lo"))
            //{
            //    Console.WriteLine("Success");
            //}
            //else
            //{
            //    Console.WriteLine("unluck(");
            //}

            char[] example = { 'a', '.', '0' };
            //Console.WriteLine(example.Contains('a'));
            //Console.WriteLine(example.Contains(','));

            char[] punc = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };   // массив который у нас в лабе

            string aaa = "aaa";
            char x = 'a';
            //Console.WriteLine(aaa.Contains(x));


                // Replace

            string text = "Cat cat catastrophe dog dog dogs love";
            //Console.WriteLine(text.Replace("dog", "more cats"));    // если слово повторяется несколько раз то по умолчанию поменяются все
            //Console.WriteLine(text.Replace("cat", "1"));            // поменяет и часть слова catastrophe, но не первое Cat
            text.Replace("cat", "1");       // это новый объект поэтому его надо сохранять (он не меняет исходный)


                // Trim (удаляет крайние симолы)

            //string w1 = "  cat  ";
            //string w2 = "cat,";
            //Console.WriteLine(w1);
            //Console.WriteLine(w1.Trim(' '));
            //Console.WriteLine(w1.Trim('t'));    // не изменитс потому что t не крайний
            //Console.WriteLine(w2);
            //w2 = w2.Trim(punc);
            //Console.WriteLine(w2);
            //string w3 = "cat, dog";
            //Console.WriteLine(w3);
            //w3 = w3.Trim(punc);
            //Console.WriteLine(w3);


                // Split

            //string t1 = "Hello, my  dear 2 friends!";   // из-за двух пробелов будет одна пустая строка (можно просто пробежаться по массиву и удалить их)
            //string[] dirtyWords = t1.Split(' ');
            //foreach (string w in dirtyWords)
            //{
            //    //Console.WriteLine(w);
            //    Console.WriteLine(w.Trim(punc));    // удалит знаки пунктуации, оставит пустую строку и 2
            //}


                //    // Join

            //string text2 = String.Join(" ", dirtyWords);    // соединит все слова через пробелы
            //Console.WriteLine(text2);


                // IsDigit/IsLetter/...
            char s = 'a';
            Console.WriteLine(Char.IsLetter(s));
            Console.WriteLine(Char.IsDigit(s));
            Console.WriteLine(Char.IsLower(s));
            Console.WriteLine(Char.IsUpper(s));
            Console.WriteLine(Char.IsPunctuation(s));

                // ToUpper/ToLower
            string word3 = "HeLlO";

            Console.WriteLine(word3.ToLower());
            Console.WriteLine(word3.ToUpper());

            string v = "уеыаоэяиюё";
            v += v.ToUpper();
            Console.WriteLine(v);
        }
    }
}
