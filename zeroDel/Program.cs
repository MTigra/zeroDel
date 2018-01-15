using System;
using CubesLib;
/*
Дисциплина: Программирование
Студент: Мартиросян Тигран
Группа: 176(1)
Задача: про делегаты.
*/

namespace zeroDel
{
    public delegate double DelFigure1(Cube a);

    public delegate void DelFigure2(Cube a, ref double res);

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Random rnd = new Random();
                bool succes;
                // Извиняюсь за вот это вот, но как сделать по-другому, чтобы было и с эксепшном и повторным вводом я не знаю.
                // Если будете проверять и знаете какой-то красивый способ, то прошу фидбек.
                Cube[] arr = new Cube[0];

                do
                {
                    succes = true;
                    try
                    {

                        int n = InputPositive("Введите кол-во элементов массива");

                        arr = new Cube[n];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        succes = false;
                    }

                } while (!succes);

                //Initilize arr
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new Cube(rnd.Next(5, 10) + rnd.NextDouble());
                }

                #region del1

                // Array of delegate.
                DelFigure1[] delFigure1Arr = new DelFigure1[3]
                {
                    delegate(Cube a)
                    {
                        double perimeter = 0;
                        StaticCube.GetPerimeter(a, ref perimeter);
                        return perimeter;
                    },

                    x =>
                    {
                        double area = 0;
                        StaticCube.GetArea(x, ref area);
                        return area;

                    },

                    x =>
                    {
                        double vol = 0;
                        StaticCube.GetVolume(x, ref vol);
                        return vol;
                    }
                };

                #endregion

                ShowInfo(arr, delFigure1Arr);

                Console.WriteLine("Теперь с другим делегатом.");
                Console.WriteLine();

                #region del2

                //Multiadress delegate 
                DelFigure2 delFigure2 = StaticCube.GetArea;
                delFigure2 += StaticCube.GetPerimeter;
                delFigure2 += StaticCube.GetVolume;

                #endregion

                double res = 0;
                for (int i = 0; i < arr.Length; i++)
                {


                    delFigure2(arr[i], ref res);
                    Console.WriteLine($"Cube[{i}]: {arr[i]} Объем:{res:f3}");

                }
                Console.WriteLine("Для выхода нажмите ESC.");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Allow user to input int and check if it is really int.
        /// </summary>
        /// <param name="ms"> message</param>
        /// <returns>int, that user inputed</returns>
        static int InputInt(string ms)
        {
            int n;
            do
            {
                Console.WriteLine(ms);
            } while (!int.TryParse(Console.ReadLine(), out n));
            return n;
        }

        /// <summary>
        /// Allow user to input int and check if it is positive int.
        /// </summary>
        /// <param name="ms"> message that user see</param>
        /// <returns></returns>
        static int InputPositive(string ms)
        {
            int n;

            n = InputInt(ms);
            if (n <= 0)
            {

                throw new ArgumentOutOfRangeException("Значение не может быть меньше или равно нулю.", (Exception)null);
            }

            return n;

        }

        /// <summary>
        /// Prints info about cubes using delegates to Console. 
        /// </summary>
        /// <param name="arr">Array of Cube</param>
        /// <param name="delArr"> Array of Delegates type DelFigure1</param>
        static void ShowInfo(Cube[] arr, DelFigure1[] delArr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Cube[{i}]\n{arr[i]}");
                for (int j = 0; j < delArr.Length; j++)
                {

                    Console.WriteLine($"{(Properties)j}:{delArr[j](arr[i]):f3}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Instead of string array that represent names of cube property.
        /// </summary>
        enum Properties
        {
            Площадь, Периметр, Объем
        }

    }
}
