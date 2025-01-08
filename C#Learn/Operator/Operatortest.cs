using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Operator
{
    public class Operatortest
    {
       public void DO()
        {
            var p1 = new Point(1,2);
            var p2 = new Point(1, 3);

            var p3 = p1 * p2;

            Console.WriteLine($"{ p3.x} {p3.y}");
            Console.WriteLine(p1==p2);
        }
    }

    public class Point
    {
        public int x,y;
        public Point(int x, int y) 
        { 
            this.x = x; this.y = y;
        }
        public static Point operator +(Point p1, Point p2)          // must be static
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }
        public static Point operator *(Point p1, Point p2) => new Point(p1.x * p2.x, p1.y * p2.y);  


        public static bool operator >(Point p1, Point p2)          // must be static
        {
            return (p1.x > p2.x&& p1.y > p2.y);
        }
        public static bool operator <(Point p1, Point p2)  => (p1.x < p2.x && p1.y < p2.y);        // must be static

        public static bool operator ==(Point p1, Point p2)          // must be static
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }
        public static bool operator !=(Point p1, Point p2)          // must be static
        {
            return (p1.x != p2.x && p1.y != p2.y);
        }

        public static implicit operator Point(int o)          // implicit
        {
            return new Point(o,o);
        }
    }

    class person {
        public int a, b;
    }
  
}
