using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Задача
{
    internal class Program
    {
        public static int Num(string description, int min = int.MinValue, int max = int.MaxValue)
        {
            Console.Write(description);
            int n;
            while (!(int.TryParse(Console.ReadLine(), out n)) || !(n >= min) || !(n <= max))
                Console.Write("Неверный ввод. Повторите, пожалуйста: ");

            return n;
        }

        public static string Word(string description)
        {
            Console.Write(description);
            string n;
            while ((n = Console.ReadLine().Trim()) == "")
                Console.WriteLine("Неверный ввод. Повторите, пожалуйста: ");

            return n;
        }

        private static void Main()
        {
            while (true)
            {
                var count =Num("Введите число k: ", 1);
                var places = new int[count];                                // инициализация массива-карты
                var dePlaces = new int[count];                              // массив-карта для дешифровки

                for (var i = 0; i < count; i++)
                    // заполнение массива-карты
                    places[i] = Num("Введите место для символа: ", 1, count) - 1;

                for (int i = 0; i < count; i++)
                    dePlaces[places[i]] = i;

                Console.WriteLine();

                string cur = Word("Введите слово: "),                   // хранение данного слова
                    crypting = "",                                          // зашифрованный вариант слова
                    decripting = "";                                        // расшифрованный вариант слова

                if (cur.Length % count > 0)                                 // заполнение пробелами справа
                    cur = cur.PadRight(cur.Length + (count - cur.Length % count));

                var blocks = cur.Length / count;                            // количество блоков

                for (var i = 0; i < blocks; i++)                            // по-блочно
                {
                    for (var j = 0; j < count; j++)                         // внутри блока - побуквенно
                    {
                        crypting += cur[places[j]];                         // шифровка по карте
                        decripting += cur[dePlaces[j]];
                    }
                    cur = cur.Remove(0, count);                             // удаление расшифрованных символов
                }

                Console.WriteLine("Шифрованное от исходного слово: " + crypting);
                Console.WriteLine("Дешифрованное от исходного слово: " + decripting);

            }

        }
    }
}
