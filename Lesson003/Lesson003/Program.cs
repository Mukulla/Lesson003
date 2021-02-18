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
            int CountPars = 5;
            string[] Denuntiatio = new string[]
            {
                "Элементы массива по диагонали",
                "Телефонный справочник",
                "Обращение строки",
                "Морской бой",
                "Смещение элементов массива"
            };
            //Console.WriteLine(System.Text.Encoding.Default.HeaderName);
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
                        TellDirectoy();
                        break;
                    case 2:
                        Reverser();
                        break;
                    case 3:
                        SeaWarrior();
                        break;
                }
                if (i == 4)
                {
                    ArrayOffSetter();

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
        //Вывод всех элементов двухмерного массива по диагонали
        static void ShowDiaArray()
        {
            Console.WriteLine("Введите колчиество строк массива: от 1 до 10");
            int i001 = Func.GetNumberFromString();
            Console.WriteLine("Введите колчиество строк массива: от 1 до 10");
            int j001 = Func.GetNumberFromString();

            Func.LeadToBoundaries(ref i001, 1, 10);
            Func.LeadToBoundaries(ref j001, 1, 10);

            int[,] SomeArray = new int[i001, j001];
            int Offset = 0;

            for (int i = 0; i < SomeArray.GetLength(0); ++i)
            {
                for (int j = 0; j < SomeArray.GetLength(1); ++j)
                {
                    Console.WriteLine(OffsetSpacer(Offset) + SomeArray[i, j]);
                    ++Offset;
                }
            }
        }
        //Вычисление строки смещения для каждого элемента в соответствии с его номером
        static string OffsetSpacer(int CountSpace)
        {
            string MaSpacer = "";
            string Returnerer = MaSpacer.PadLeft(CountSpace, ' ');
            return Returnerer;
        }
        //Список имён и адресов почт
        static void TellDirectoy()
        {
            Console.WriteLine("Введите номер строки из справочника: от 1 до 5");
            int Number = Func.GetNumberFromString();
            --Number;
            Func.LeadToBoundaries(ref Number, 0, 4);
            string[,] TellDiru =
            {
                {"Olivia", "Ol@gmail.com" },
                {"Lucas", "Luc@gmail.com" },
                {"Emily", "Emma@gmail.com" },
                {"Mateo", "Mteo@gmail.com" },
                {"Satella", "Sat@gmail.com" }
            };
            Console.WriteLine("{0:10} {1:10}", TellDiru[Number, 0], TellDiru[Number, 1]);
        }
        //Перевернуть строку
        static void Reverser()
        {
            Console.WriteLine("Введите некое слово");
            string SomeString = Console.ReadLine();
            for (int i = (SomeString.Length - 1); i > +0; --i)
            {
                Console.Write(SomeString[i]);
            }
        }
        //Карта с кораблями для морского боя
        static void SeaWarrior()
        {
            char[,] SomeArray = new char[10, 10];

            string[] Shippos =
            {
                "Х",
                "XX",
                "XXX",
                "XXXX"
            };

            Func.FillArray(ref SomeArray, '.');

            var Rnd = new Random();
            Str_Indexes Koords = Func.SetteStr(1, 2);
            bool Rotater = false;

            Str_Indexes Sizes = Func.SetteStr(Shippos.Length, 4);
            for (int i = 0; i < Sizes.i; ++i)
            {
                for (int j = Sizes.j; j > 0; --j)
                {
                    //Koords.i = Rnd.Next(0, SomeArray.GetLength(0));
                    //Koords.j = Rnd.Next(0, SomeArray.GetLength(1));                    
                    if (Koords.i > Sizes.i / 2)
                    {
                        Rotater = false;
                    }
                    else
                    {
                        Rotater = true;
                    }
                    Koords = CheckShip(ref SomeArray, ref Shippos[i], ref Rotater);

                    Func.CopyStringToArray(ref Koords, ref Shippos[i], ref SomeArray, Rotater);
                }
                --Sizes.j;
            }
            Func.ShowArray(ref SomeArray);
        }
        //Проверка положения корабля для его постановки и выдача координат, которые бы подошли
        static Str_Indexes CheckShip(ref char[,] Array001, ref string Ship, ref bool Horu001)
        {
            var Rnd = new Random();
            Str_Indexes Tempo = Func.SetteStr(0, 0);
            int Iter = 0;
            do
            {
                if ((Iter % 2) == 0)
                {
                    Horu001 = !Horu001;
                }
                Tempo.i = Rnd.Next(0, Array001.GetLength(0) - Ship.Length);
                Tempo.j = Rnd.Next(0, Array001.GetLength(1) - Ship.Length);
                //Console.WriteLine($"{Tempo.i} {Tempo.j}");
                ++Iter;
            }
            while (!CheckDirection(ref Tempo, ref Array001, ref Ship, ref Horu001));
            //Посмотреть итоговые координаты размещения текущего корабля и его направление
            //Console.WriteLine($"{Tempo.i} {Tempo.j} {Horu001}");
            //Количество попыток
            //Console.WriteLine(Iter);
            return Tempo;
        }
        //Проверка возможности помещения корабля в массив с указанным направлением
        static bool CheckDirection(ref Str_Indexes Koords001, ref char[,] Array002, ref string Ship, ref bool Horu002)
        {
            char Elem;
            int Iterator;
            for (int i = 0; i < Ship.Length; ++i)
            {
                Elem = Ship[i];
                if (Horu002)
                {
                    Iterator = Koords001.j;
                    if (Array002[Koords001.i, Koords001.j] == Elem)
                    {
                        return false;
                    }
                    ++Iterator;
                }
                else
                {
                    Iterator = Koords001.i;
                    if (Array002[Iterator, Koords001.j] == Elem)
                    {
                        return false;
                    }
                    ++Iterator;
                }
            }
            return true;
        }

        static void ArrayOffSetter()
        {
            Console.WriteLine("Введите размер массива");
            int Sizer = Func.GetNumberFromString();
            if (Sizer < 1)
            {
                Sizer = 1;
            }
            int[] SomeArray = new int[Sizer];
            Func.SetRandomValues(ref SomeArray, -99, 99);
            Func.ShowArray(ref SomeArray);

            Console.WriteLine("Введите величину смещения элементов в одномерном массиве");

            OffSetValuesInArray(ref SomeArray, Func.GetNumberFromString());
            Func.ShowArray(ref SomeArray);
        }

        static void OffSetValuesInArray<T>(ref T[] Array, int OffSet001)
        {
            int Min = OffSet001, Max = Min + Array.Length;
            Func.LeadToBoundaries(ref Min, 0, Array.Length);
            Func.LeadToBoundaries(ref Max, 0, Array.Length);

            int StartOffSet = 0;
            T T1;

            if (OffSet001 < 0)
            {
                T1 = Array[(Array.Length - 1)];
                StartOffSet -= OffSet001;
                for (int i = 0; i < Max; ++i)
                {
                    Array[i] = Array[StartOffSet];
                    ++StartOffSet;
                }

                for (int i = (Array.Length - 1); i >= Max; --i)
                {
                    Array[i] = T1;
                }
                return;
            }
            if (OffSet001 > 0)
            {
                T1 = Array[0];
                StartOffSet = (Max - 1) - Min;
                for (int i = (Max - 1); i >= Min; --i)
                {
                    Array[i] = Array[StartOffSet];
                    --StartOffSet;
                }

                for (int i = 0; i < Min; ++i)
                {
                    Array[i] = T1;
                }
            }
        }
    }
}
