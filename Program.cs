using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle ABC = new Triangle(0, 10, 7, 10, 0, 0);
            ABC.Print();

            SquareFigure ABCD = new SquareFigure(10);
            ABCD.Print();

            Rhombus rhombus = new Rhombus(12, 6);
            rhombus.Print();

            Rectangle rectangle = new Rectangle(12, 6);
            rectangle.Print();


            Geometric_figure[] gfArr = new Geometric_figure[4]
            {
            ABC,
            ABCD,
            rhombus,
            rectangle,
            };
            
            SostavnFigura sf = new SostavnFigura(gfArr);
            sf.Print();
            

            Console.ReadKey();
        }
    }
}
