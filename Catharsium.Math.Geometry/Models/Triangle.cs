using System;

namespace Catharsium.Math.Geometry.Models
{
    public class Triangle : Shape
    {
        private Point a;

        public Point A {
            get => this.a;
            set => this.a = new Point(value);
        }


        private Point b;

        public Point B {
            get => this.b;
            set => this.b = new Point(value);
        }


        private Point c;

        public Point C {
            get => this.c;
            set => this.c = new Point(value);
        }


        public Triangle() : this(0, 0, 1, 0, 0, 1) { }


        public Triangle(double aX, double aY, double bX, double bY, double cX, double cY) :
            this(new Point(aX, aY), new Point(bX, bY), new Point(cX, cY), "T") { }


        public Triangle(Point a, Point b, Point c) : this(a, b, c, "T") { }


        public Triangle(Point a, Point b, Point c, string id)
        {
            this.A = new Point(a);
            a.Id = "A";
            this.B = new Point(b);
            b.Id = "B";
            this.C = new Point(c);
            c.Id = "C";
            this.Id = id;
        }


        public Triangle(Triangle t) : this(t.A, t.B, t.C, t.Id) { }


        public double GetInAlfa()
        {
            var a2 = System.Math.Pow(this.GetLengthA(), 2);
            var b2 = System.Math.Pow(this.GetLengthB(), 2);
            var c2 = System.Math.Pow(this.GetLengthC(), 2);
            var alpha = System.Math.Acos((b2 + c2 - a2) / (2 * this.GetLengthB() * this.GetLengthC()));
            return alpha * 360 / (2 * System.Math.PI);
        }


        /** getOutBeta berekent de binnenhoek beta van hoekpunt B
     * @return beta - De binnenhoek van hoekpunt B
     */
        public double GetInBeta()
        {
            var a2 = System.Math.Pow(this.GetLengthA(), 2);
            var b2 = System.Math.Pow(this.GetLengthB(), 2);
            var c2 = System.Math.Pow(this.GetLengthC(), 2);
            return System.Math.Acos((a2 + c2 - b2) / (2 * this.GetLengthA() * this.GetLengthC()));
        }


        /** getOutGamma berekent de binnenhoek gamma van hoekpunt C
     * @return gamma - De binnenhoek van hoekpunt C
     */
        public double GetInGamma()
        {
            var a2 = System.Math.Pow(this.GetLengthA(), 2);
            var b2 = System.Math.Pow(this.GetLengthB(), 2);
            var c2 = System.Math.Pow(this.GetLengthC(), 2);
            return System.Math.Acos((a2 + b2 - c2) / (2 * this.GetLengthA() * this.GetLengthB()));
        }


        public double GetOutAlfa()
        {
            return 180 - this.GetInAlfa();
        }



        public double GetOutBeta()
        {
            return 180 - this.GetInBeta();
        }



        public double GetOutGamma()
        {
            return 180 - this.GetInGamma();
        }



        public Line GetLineA()
        {
            return new Line(this.B, this.C);
        }


        public Line GetLineB()
        {
            return new Line(this.A, this.C);
        }



        public Line GetLineC()
        {
            return new Line(this.A, this.B);
        }


        public double GetLengthA()
        {
            var l = this.GetLineA();
            return l.GetLength();
        }


        public double GetLengthB()
        {
            var l = this.GetLineB();
            return l.GetLength();
        }


        public double GetLengthC()
        {
            var l = this.GetLineC();
            return l.GetLength();
        }


        public double GetPerimeter()
        {
            return this.GetLengthA() + this.GetLengthB() + this.GetLengthC();
        }


        public double GetArea()
        {
            // O^2 = s * (s - a) * (s - b) * (s - c)
            var s = this.GetPerimeter() / 2;
            return System.Math.Sqrt(s * (s - this.GetLengthA()) *
                                    (s - this.GetLengthB()) * (s - this.GetLengthC()));
        }


        public override string ToString()
        {
            return $"{this.Id}:[{this.A},{this.B},{this.C}]";
        }


        public static void Main(string[] args)
        {
            var t = new Triangle(0, 0, 10, 0, 10, 10);
            Console.WriteLine(t + "\nA:" + t.GetLengthA() + "\nB:" +
                              t.GetLengthB() + "\nC:" + t.GetLengthC());
            Console.WriteLine("Alpha: " + t.GetInAlfa());
            Console.WriteLine("Area:  " + t.GetArea());
            Console.WriteLine("Peri:  " + t.GetPerimeter());
            //Console.WriteLine("d(a,A):" +t.A.distanceTo(t.getLineA())) ;
            Console.WriteLine("line A:" + t.GetLineA().ToVector());
        }
    }
}