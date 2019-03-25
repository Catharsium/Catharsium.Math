using Catharsium.Math.Geometry.Interfaces;

namespace Catharsium.Math.Geometry.Models
{
    public class Triangle : Shape
    {
        private readonly IDistanceCalculator distanceCalculator;
        private readonly ICircumferenceCalculator circumferenceCalculator;


        public Triangle(IDistanceCalculator distanceCalculator, ICircumferenceCalculator circumferenceCalculator)
        {
            this.distanceCalculator = distanceCalculator;
            this.circumferenceCalculator = circumferenceCalculator;
        }


        private Point a;
        public Point A
        {
            get => this.a;
            set => this.a = new Point(value);
        }


        private Point b;
        public Point B
        {
            get => this.b;
            set => this.b = new Point(value);
        }


        private Point c;
        public Point C
        {
            get => this.c;
            set => this.c = new Point(value);
        }

    
        public Triangle() : this(0, 0, 1, 0, 0, 1)
        {
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public Triangle(double a1, double a2, double b1, double b2, double c1, double c2) :
            this(new Point(a1, a2), new Point(b1, b2), new Point(c1, c2), "T")
        {
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public Triangle(Point a, Point b, Point c) : this(a, b, c, "T")
        {
        }


        public Triangle(Point a, Point b, Point c, string id)
        {
            this.A = new Point(a) {Id = "A"};
            this.B = new Point(b) {Id = "B"};
            this.C = new Point(c) {Id = "C"};
            this.Id = id;
        }


        public Triangle(Triangle t) : this(t.A, t.B, t.C, t.Id)
        {
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public double GetInAlfa()
        {
            var a2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineA()), 2);
            var b2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineB()), 2);
            var c2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineC()), 2);
            var alpha = System.Math.Acos((b2 + c2 - a2) / (2 * this.distanceCalculator.GetLength(this.GetLineB()) * this.distanceCalculator.GetLength(this.GetLineC())));
            return alpha * 360 / (2 * System.Math.PI);
        }


        /** getOutBeta berekent de binnenhoek beta van hoekpunt B
     * @return beta - De binnenhoek van hoekpunt B
     */
        public double GetInBeta()
        {
            var a2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineA()), 2);
            var b2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineB()), 2);
            var c2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineC()), 2);
            return System.Math.Acos((a2 + c2 - b2) / (2 * this.distanceCalculator.GetLength(this.GetLineA()) * this.distanceCalculator.GetLength(this.GetLineC())));
        }


        /** getOutGamma berekent de binnenhoek gamma van hoekpunt C
     * @return gamma - De binnenhoek van hoekpunt C
     */
        public double GetInGamma()
        {
            var a2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineA()), 2);
            var b2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineB()), 2);
            var c2 = System.Math.Pow(this.distanceCalculator.GetLength(this.GetLineC()), 2);
            return System.Math.Acos((a2 + b2 - c2) / (2 * this.distanceCalculator.GetLength(this.GetLineA()) * this.distanceCalculator.GetLength(this.GetLineB())));
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


        public double GetArea()
        {
            // O^2 = s * (s - a) * (s - b) * (s - c)
            var s = this.circumferenceCalculator.GetCircumference(this) / 2;
            return System.Math.Sqrt(s * (s - this.distanceCalculator.GetLength(this.GetLineA())) *
                             (s - this.distanceCalculator.GetLength(this.GetLineB())) * (s - this.distanceCalculator.GetLength(this.GetLineC())));
        }


        public override string ToString()
        {
            return $"{this.Id}:[{this.A},{this.B},{this.C}]";
        }


        //public static void Main(string[] args)
        //{
        //    var t = new Triangle(0, 0, 10, 0, 10, 10);
        //    Console.WriteLine(t + "\nA:" + t.this.distanceCalculator.GetLength(this.GetLineA()) + "\nB:" +
        //                      t.GetLengthB() + "\nC:" + t.GetLengthC());
        //    Console.WriteLine("Alpha: " + t.GetInAlfa());
        //    Console.WriteLine("Area:  " + t.GetArea());
        //    //Console.WriteLine("Peri:  " + );
        //    //Console.WriteLine("d(a,A):" +t.A.distanceTo(t.getLineA())) ;
        //    Console.WriteLine("line A:" + t.GetLineA().ToVector());
        //}
    }
}