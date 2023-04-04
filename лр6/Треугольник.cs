using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лр6
{
    
        public class Triangle
        {
            public double a, b, c;
            public double angular;
            public double x1, y1, x2, y2, x3, y3;

            public double side_a
            {
                get
                {
                    return a;
                }
                set
                {
                    a = value;
                }
            }
            public double side_b
            {
                get
                {
                    return b;
                }
                set
                {
                    b = value;
                }
            }
            public double side_c
            {
                get
                {
                    return c;
                }
                set
                {
                    c = value;
                }
            }
            // Ввод новых точек. На их основе создаются стороны треугольника
            public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;

            // Стороны треугольника. Каждой стороне присваиваются 2 точки

            side_a = Math.Round(Math.Sqrt((((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)))));
            side_b = Math.Round(Math.Sqrt((((x3 - x2) * (x3 - x2)) + ((y3 - y2) * (y3 - y2)))));
            side_c = Math.Round(Math.Sqrt((((x1 - x3) * (x1 - x3)) + ((y1 - y3) * (y1 - y3)))));
            if (a == 0 || b == 0 || c == 0)
            {
                throw new Exception("Сторона не может быть равной нулю.");
            }
            if ((a >= b + c) || (c >= a + c) || (b >= b + a))
            {
                throw new Exception("Одна из сторон больше суммы двух других");
            }

        }
            
            // Поворот
            public void Turn(string center, double angular)
            {
            this.angular = angular;
            
            if (center == "x1")
                {
                    x2 = (x2 * (Math.Cos(angular))) - (y2 * (Math.Sin(angular)));
                    y2 = (y2 * (Math.Cos(angular))) + (x2 * (Math.Sin(angular)));
                    x3 = (x3 * (Math.Cos(angular))) - (y3 * (Math.Sin(angular)));
                    y3 = (y3 * (Math.Cos(angular))) + (x3 * (Math.Sin(angular)));
                }
                if (center == "x2")
                {
                    x1 = (x1 * (Math.Cos(angular))) - (y1 * (Math.Sin(angular)));
                    y1 = (y1 * (Math.Cos(angular))) + (x1 * (Math.Sin(angular)));
                    x3 = (x3 * (Math.Cos(angular))) - (y3 * (Math.Sin(angular)));
                    y2 = (y3 * (Math.Cos(angular))) + (x3 * (Math.Sin(angular)));
                }
                if (center == "x3")
                {
                    x1 = (x1 * (Math.Cos(angular))) - (y1 * (Math.Sin(angular)));
                    y1 = (y1 * (Math.Cos(angular))) + (x1 * (Math.Sin(angular)));
                    x2 = (x2 * (Math.Cos(angular))) - (y2 * (Math.Sin(angular)));
                    y2 = (y2 * (Math.Cos(angular))) + (x2 * (Math.Sin(angular)));
                }

            }
            
            // Изменение размера

            public void ChangeSize(double change_size)
            {
                // Если одна из сторон равна длине, на которую нужно уменьшить, выбрасывается исключение
            if (change_size <= (-side_a) || change_size <= (-side_b) || change_size <= (-side_c))
                {
                    throw new Exception("Нельзя уменьшить сторону на длину самой стороны или более");
                }
                side_a = side_a + change_size;
                side_b = side_b + change_size;
                side_c = side_c + change_size;
            }

            //Изменение размера не может быть равным одной из сторон или больше

            //Перемещение

            public void MoveOnPlane(double moving)
            {
                x1 = x1 + moving;
                x2 = x2 + moving;
                x3 = x3 + moving;
                y1 = y1 + moving;
                y2 = y2 + moving;
                y3 = y3 + moving;
            }


            // Свойство: первоначальные координаты, стороны треугольника, угол поворота

            public string Definition
            {
                get
                {
                    return $"Координаты: x1 = {x1}, y1 = {y1}, x2 = {x2}, y2 = {y2}, x3 = {x3}, y3 = {y3}. Угол поворота: {angular}. Стороны треугольника: AB = {side_a}, BC = {side_b}, CA = {side_c}.";
                }
            }


        }

    }


