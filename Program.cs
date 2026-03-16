namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Cat(1);
            Cat c = new Cat(2);
            Dog d = new Dog(3);

            a.Method1(); a.Method2(); a.Method3();
            Console.WriteLine();
            c.Method1(); c.Method2(); c.Method3();
            Console.WriteLine();
            d.Method1(); d.Method2(); d.Method3();
            Console.WriteLine();
            Console.WriteLine(a.Word);
            Console.WriteLine(c.Word);
            Console.WriteLine(d.Word);
        }
        public abstract class Animal
        {
            private int _number;
            public abstract string Word { get; }    // абстрактное св-во

            public Animal(int number)
            {
                _number = number;
            }

            public void Method1()
            {
                Console.WriteLine("Method1");
            }
            public virtual void Method2()
            {
                Console.WriteLine("Method2");
            }

            public abstract void Method3();
        }

        public class Cat : Animal
        {
            public override string Word => "Bye!";
            public Cat(int number) : base(number) { }

            public new void Method1()
            {
                Console.WriteLine("Cat1");  // скрыли обычный метод
            }
            public override void Method2()
            {
                Console.WriteLine("Cat2");  // переопределили virtual
            }
            public override void Method3()
            {
                Console.WriteLine("Cat3");  // переопределили абстрактный
            }
        }

        public class Dog : Animal
        {
            public override string Word => "Woof!";
            public Dog(int number) : base(number) { }

            public new void Method1()
            {
                Console.WriteLine("Dog1");
            }
            public override void Method2()
            {
                Console.WriteLine("Dog2");
            }
            public override void Method3()
            {
                Console.WriteLine("Dog3");
            }
        }
    }
}
