/*
Дисциплина: Программирование
Студент: Мартиросян Тигран
Группа: 176(1)
Задача: про делегаты.
*/

using System;

namespace CubesLib
{
    public class Cube
    {
        /// <summary>
        /// Side-field.
        /// </summary>
        private double side;

        /// <summary>
        /// Property to get or set side value.
        /// </summary>
        public double Side
        {
            get
            {
                return side;
            }

            set
            {
                if(value<=0.0) throw  new ArgumentException("Сторона не может быть меньше или равна нулю", nameof(value));
                side = value;
            }
        }

        /// <summary>
        /// Constructor for Cube.
        /// </summary>
        /// <param name="side"> Int side of cube. As default=1</param>
        public Cube(double side=1.0)
        {
            Side = side;
        }

        /// <summary>
        ///  Returns String that represents side value.
        /// </summary>
        /// <returns> String that represents side value.</returns>
        public override string ToString()
        {
            return String.Format($"Сторона куба: {Side:F3}");
        }
    }
}
