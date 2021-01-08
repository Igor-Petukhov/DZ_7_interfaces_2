using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IFigure
    {
        void Print();
    }

    abstract class Geometric_figure
    {
        protected float square;
        protected float perimeter;

        public abstract float Square();
        public abstract float Perimeter();

        public void PrintSquareText()
        {
            Console.Write($"Площадь фигуры ");
        }

        public void PrintPerimeterText()
        {
            Console.Write($"Периметр фигуры ");
        }


    }

    class Triangle : Geometric_figure, IFigure
    {
        int x1, y1, x2, y2, x3, y3;
        float AB, BC, AC;

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            //Проверка треугольника на существование
            AB = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            BC = (float)Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            AC = (float)Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            if ((AB + BC <= AC) || (BC + AC <= AB) || (AC + AB <= BC))
                Console.WriteLine("Извините такого треугольника не существует. Возможно :)");
            else
            {
                x1 = x1;
                y1 = y1;
                x2 = x2;
                y2 = y2;
                x3 = x3;
                y3 = y3;
            }
        }
        public override float Square()
        {
            float p = (AB + BC + AC) / 2; //Полупериметр
            return (float)Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));
        }

        public override float Perimeter()
        {
            return AB + BC + AC;
        }

        public void Print()
        {
            float tmp = AB;
            for (int i = 0; i < (int)AC; i++)
            {
                for (int j = 0; j < tmp; j++)
                {
                    Console.Write("*");
                }
                tmp -= AB / AC;
                Console.WriteLine();
            }
        }
    }


    class SquareFigure : Geometric_figure, IFigure
    {
        float AB;
        public SquareFigure(float AB) //получим длину стороны квадрата
        {
            this.AB = AB;
        }
        public override float Square()
        {
            return AB * AB;
        }

        public override float Perimeter()
        {
            return 4 * AB;
        }

        public void PrintSquare()
        {
            base.PrintSquareText();
            Console.WriteLine($"квадрат: {Square()}");
        }

        public void PrintPerimeter()
        {
            base.PrintPerimeterText();
            Console.WriteLine($"квадрат: {Perimeter()}");
        }

        public void Print()
        {
            for (int i = 0; i < AB; i++)
            {
                for (int j = 0; j < AB; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }

    class Rhombus : Geometric_figure, IFigure
    {
        float AC, BD; //диагонали

        public Rhombus(float AC, float BD) //по двум диагоналям
        {
            this.AC = AC;
            this.BD = BD;
        }
        public override float Perimeter()
        {
            return (float)(2 * (Math.Sqrt(Math.Pow(AC, 2) + Math.Pow(BD, 2))));
        }

        public override float Square()
        {
            return AC * BD / 2;
        }

        public void PrintSquare()
        {
            base.PrintSquareText();
            Console.WriteLine($"ромб: {Square()}");
        }

        public void PrintPerimeter()
        {
            base.PrintPerimeterText();
            Console.WriteLine($"ромб: {Perimeter()}");
        }

        public void Print()
        {
            float tmp = (float)(AC / 2);
            for (int i = 0; i < (float)(BD/2); i++)
            {
                for (int j = 0; j < (float)(tmp); j++)
                {
                    Console.Write(" ");
                }
                for (int j = (int)(tmp); j < (float)AC /2; j++)
                {
                    Console.Write("2");
                }
                for (int j = (int)(tmp); j < (float)AC / 2; j++)
                {
                    Console.Write("3");
                }
                tmp -= (float)(AC / 2) / (float)(BD / 2);
                Console.WriteLine();
            }
            float tmp2 = (float)(AC / 2);
            for (int i = (int)(BD / 2); i > 0; i--)
            {
                for (int j = 0; j < (AC/2) - tmp2; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < tmp2; j++)
                {
                    Console.Write("4");
                }
                for (int j = 0; j < tmp2; j++)
                {
                    Console.Write("5");
                }
                tmp2 -= (float)(AC / 2) / (float)(BD / 2);
                Console.WriteLine();
            }
        }
    }

    class Rectangle : Geometric_figure, IFigure
    {
        float AB, AD; //через 2 стороны
        public Rectangle(float AB, float AD)
        {
            this.AB = AB;
            this.AD = AD;
        }

        public override float Perimeter()
        {
            return 2 * AB + 2 * AD;
        }
        public override float Square()
        {
            return AB * AD;
        }

        public void PrintSquare()
        {
            base.PrintSquareText();
            Console.WriteLine($"прямоугольник: {Square()}");
        }

        public void PrintPerimeter()
        {
            base.PrintPerimeterText();
            Console.WriteLine($"прямоугольник: {Perimeter()}");
        }

        public void Print()
        {
            for (int i = 0; i < (int)AD; i++)
            {
                for (int j = 0; j < (int)AB; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }

    class SostavnFigura : IFigure, IEnumerable
    {
        private Geometric_figure[] gfArr;

        public SostavnFigura(Geometric_figure[] arrIn)
        {
            gfArr = new Geometric_figure[arrIn.Length];
            for (int i = 0; i < arrIn.Length; i++)
            {
                gfArr[i] = arrIn[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return gfArr.GetEnumerator();
        }

        public float Perimeter()
        {
            float tmp = 0;
            foreach (Geometric_figure item in this)
            {
                tmp += item.Perimeter();
            }
            return tmp;
        }
        public float Square()
        {
            float tmp = 0;
            foreach (Geometric_figure item in this)
            {
                tmp += item.Square();
            }
            return tmp;
        }

        public void Print()
        {
            foreach (IFigure item in this)
            {
                item.Print();
            }
        }

        
    }
}
