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
            int CountPars = 4;
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
            for (int i = 3; i < CountPars; ++i)
            {
                //Вывод части и названия задания
                Console.WriteLine($"Часть {i + 1}: {Denuntiatio[i]}");

                switch (i)
                {
                    case 0:
                        ShowDiaArray(4,4);
                        break;
                    case 1:
                        TellDirectoy(2);
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

        static void ShowDiaArray( int i001, int j001 )
        {
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
        static string OffsetSpacer(int CountSpace)
        {
            string MaSpacer = "";
            string Returnerer = MaSpacer.PadLeft(CountSpace, ' ');
            return Returnerer;
        }

        static void TellDirectoy(int Number)
        {
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

        static void Reverser()
        {
            Console.WriteLine("Введите некое слово");
            string SomeString = Console.ReadLine();
            for (int i = ( SomeString.Length - 1 ); i >+ 0; --i)
            {
                Console.Write(SomeString[i]);
            }
        }

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
            for (int i = 0; i < 4; ++i)
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
                    Koords = CheckShip(ref SomeArray, ref Shippos[i], Rotater);

                    Func.CopyStringToArray(ref Koords, ref Shippos[i], ref SomeArray, Rotater);
                }
                --Sizes.j;
            }
            Func.ShowArray(ref SomeArray);
        }
        //Проверка положения корабля для его постановки и выдача координат, которые бы подошли
        static Str_Indexes CheckShip(ref char[,] Array001, ref string Ship, bool Horu001)
        {
            var Rnd = new Random();
            Str_Indexes Tempo = Func.SetteStr(0, 0);

            do
            {
                Tempo.i = Rnd.Next(0, Array001.GetLength(0));
                Tempo.j = Rnd.Next(0, Array001.GetLength(0));
            }
            while (!CheckDirection(ref Tempo, ref Array001, ref Ship, Horu001) && !CheckForwardSpace(ref Tempo, ref Array001, ref Ship, Horu001));

            return Tempo;
        }
        //Проверка возможности помещения корабля в массив с указанным направлением
        static bool CheckDirection(ref Str_Indexes Koords001, ref char[,] Array002, ref string Ship, bool Horu002)
        {
            for (int i = 0; i < Ship.Length; ++i)
            {
                if(Horu002)
                {
                    if(Koords001.j < Array002.GetLength(1))
                    {
                        return false;
                    }
                    if(Array002[Koords001.i, Koords001.j] == Ship[i] )
                    {
                        return false;
                    }
                    ++Koords001.j;
                }
                else
                {
                    if (Koords001.i < Array002.GetLength(0))
                    {
                        return false;
                    }
                    if (Array002[Koords001.i, Koords001.j] == Ship[i])
                    {
                        return false;
                    }
                    ++Koords001.i;
                }
            }
            return true;
        }
        //Проверка выхода корабля за пределы поля
        static bool CheckForwardSpace(ref Str_Indexes Koords001, ref char[,] Array002, ref string Ship, bool Horu002)
        {
            int TotalValue = 0;
            if (Horu002)
            {
                TotalValue = Koords001.j + Ship.Length;
                if (TotalValue > Array002.GetLength(1))
                {
                    return false;
                }
            }
            else
            {
                TotalValue = Koords001.i + Ship.Length;
                if (TotalValue > Array002.GetLength(0))
                {
                    return false;
                }
            }
            return true;
        }

        static void OffSetValuesInArray<T>( ref T[] Array, int OffSet001)
        {

        }
    }
}
