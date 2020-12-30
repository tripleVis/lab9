using System;
using System.Collections.Generic;


namespace lab9
{
    class Program
    {
        static event Action<int, int> Move;//объявляем события
        static event Action<double> Squeeze;

        static void Main(string[] args)
        {
            var list = new List<User>//инициализация списка
            {
                new User("Влад", 15, 15),
                new User("Иван", 20, 35),
                new User("Сергей", 10, 40),
                new User("Кирилл", 35, 25),
                new User("Ромен", 30, 30)
            };

            list[2].Move(5, 50);//"перемещаем" 3 элемент коллекции и вызываем событие

            Console.ReadKey();
            Move += list[0].SetCoords;//задаем координаты для элементов списка
            Move += list[1].SetCoords;
            Move += list[2].SetCoords;
            Move += list[3].SetCoords;
            Squeeze += list[2].SetP;//задаем сжатие для элементов списка
            Squeeze += list[3].SetP;
            Display(list);//вызов метода, который выводит список    
            Console.ReadKey();
            Move.Invoke(10, 20);
            Squeeze.Invoke(2);//вызов события через Invoke
            Console.WriteLine("Результаты изменений:");
            Display(list);//вызов метода, который выводит список
            StrActions();//вызов метода
        }

        static void Display(List<User> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Имя: {item.Name,-10} Координаты: {item.X,2}, {item.Y}");//вывод
            }

        }

        static void StrActions()
        {
            Func<string, string> StrReplace = str => str.Replace("и", "  $");//делегат, возвращающий результат замены символов
            Func<string, string> Delete_e = str => str.Replace("е", "");
            Func<string, int, string> Probel = (str, index) => str.Insert(index, " ");//делегат, возвращающий результат добавления символов
            Func<string, string> Upper = str => str.ToUpper();//делегат, возвращающий результат преобразования к верхнему регистру
            Action<string> Print = str => Console.WriteLine(str);

            string someStr = "Просто всякие нужные буквы";
            someStr = StrReplace(someStr);
            Print(someStr);//вывод
            someStr = Delete_e(someStr);
            Print(someStr);
            someStr = Probel(someStr, 5);
            Print(someStr);
            someStr = Upper(someStr);
            Print(someStr);
        }
    }
}





