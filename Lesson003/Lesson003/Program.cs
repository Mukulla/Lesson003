using System;

namespace Lesson003
{
    class Program
    {
        static void Main(string[] args)
        {
            Executor();
        }


        static void Executor()
        {
            int CountPars = 1;
            string[] Denuntiatio = new string[]
            {
                "Элементы массива по диагонали",
                "Телефонный справочник",
                "Обращение строки", "Морской бой",
                "Смещение элементов массива"
            };

            //Цикл-обработчик каждого задания
            for (int i = 0; i < CountPars; ++i)
            {
                //Вывод части и названия задания
                Console.WriteLine($"Часть {i + 1}: {Denuntiatio[i]}");

                switch (i)
                {
                    case 0:
                        ShowDiaArray();
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                if (i == 4)
                {


                    Console.WriteLine();
                    Console.WriteLine("Все части пройдены");
                    Console.WriteLine("Для выхода нажмите любую клавишу");
                    Console.ReadKey();

                    break;
                }

                Console.WriteLine();
                Console.WriteLine("Для перехода к следующей части нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowDiaArray()
        {
            int[,] SomeArray = new int[9, 9];
            int Offset = 0;

            for (int i = 0; i < SomeArray.GetLength(0); ++i)
            {
                for (int j = 0; j < SomeArray.GetLength(1); ++j)
                {
                    //Console.WriteLine(MaSpacer);
                    Console.WriteLine(OffsetSpacer(Offset) + SomeArray[i, j]);
                    ++Offset;
                }
            }
        }
        static string OffsetSpacer(int CountSpace)
        {
            string MaSpacer = "";
            string Returnerer = MaSpacer.PadLeft(CountSpace, ' ');
            return Returnerer;
        }
    }
}
