using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Green
{
    internal class Task1 : Green
    {
        private int _output;

        public int Output => _output;

        public Task1(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            // исходный текст лежит в input
            // здесь решение
            // полученный ответ записываем в поле _output
            // Review ничего не возвращает
            // input менять нельзя (сделать копию если надо)

            throw new NotImplementedException();
        }

        public override string ToString()
        {
            // здесь вписываем вывод ответа
            return null;
        }
    }
}
