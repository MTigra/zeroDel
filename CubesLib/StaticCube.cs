/*
Дисциплина: Программирование
Студент: Мартиросян Тигран
Группа: 176(1)
Задача: про делегаты.
*/

namespace CubesLib
{
    public static class StaticCube
    {
        /// <summary>
        /// Multiply <code>Cube</code> side by 2.
        /// </summary>
        /// <param name="cube"></param>
        public static void MultiplyBy2(Cube cube)
        {
            cube.Side *= 2;
        }
        /// <summary>
        /// Get Area of <c>Cube</c>
        /// </summary>
        /// <param name="cube">instance of <c>Cube</c></param>
        /// <param name="area"></param>
        public static void GetArea(Cube cube, ref double area)
        {
            area = cube.Side * cube.Side * 6;
        }

        /// <summary>
        /// Get Perimeter of <c>Cube</c>
        /// </summary>
        /// <param name="cube">instance of <c>Cube</c></param>
        /// <param name="area"></param>
        public static void GetPerimeter(Cube cube, ref double perimeter)
        {
            perimeter = cube.Side * 12;
        }

        /// <summary>
        /// Get Volume of <c>Cube</c>
        /// </summary>
        /// <param name="cube">instance of <c>Cube</c></param>
        /// <param name="area"></param>
        public static void GetVolume(Cube cube, ref double volume)
        {
            volume = cube.Side * cube.Side * cube.Side;
        }
    }
}
