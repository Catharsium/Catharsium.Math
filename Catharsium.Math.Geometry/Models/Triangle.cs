using Catharsium.Math.Geometry.Interfaces;

namespace Catharsium.Math.Geometry.Models
{
    public class Triangle : Shape
    {
        protected readonly IAreaCalculator AreaCalculator;
        protected readonly IDistanceCalculator DistanceCalculator;
        protected readonly ICircumferenceCalculator CircumferenceCalculator;


        public Triangle(IAreaCalculator areaCalculator, IDistanceCalculator distanceCalculator, ICircumferenceCalculator circumferenceCalculator)
        {
            this.AreaCalculator = areaCalculator;
            this.DistanceCalculator = distanceCalculator;
            this.CircumferenceCalculator = circumferenceCalculator;
        }


        private Point a;
        public virtual Point A
        {
            get => this.a;
            set {
                this.a = new Point(value);
                this.Recalculate();
            }
        }


        private Point b;
        public virtual Point B
        {
            get => this.b;
            set {
                this.b = new Point(value);
                this.Recalculate();
            }
        }


        private Point c;
        public virtual Point C
        {
            get => this.c;
            set {
                this.c = new Point(value);
                this.Recalculate();
            }
        }

        #region Mathematical Properties

        public double GetCircumference()
        {
            return this.CircumferenceCalculator.GetCircumference(this);
        }


        public double GetArea()
        {
            return this.AreaCalculator.GetArea(this);
        }

        #endregion

        protected virtual void Recalculate()
        {
        }


        public double GetInAlfa()
        {
            var a2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineA()), 2);
            var b2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineB()), 2);
            var c2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineC()), 2);
            var alpha = System.Math.Acos((b2 + c2 - a2) / (2 * this.DistanceCalculator.GetLength(this.GetLineB()) * this.DistanceCalculator.GetLength(this.GetLineC())));
            return alpha * 360 / (2 * System.Math.PI);
        }


        /** getOutBeta berekent de binnenhoek beta van hoekpunt B
     * @return beta - De binnenhoek van hoekpunt B
     */
        public double GetInBeta()
        {
            var a2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineA()), 2);
            var b2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineB()), 2);
            var c2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineC()), 2);
            return System.Math.Acos((a2 + c2 - b2) / (2 * this.DistanceCalculator.GetLength(this.GetLineA()) * this.DistanceCalculator.GetLength(this.GetLineC())));
        }


        /** getOutGamma berekent de binnenhoek gamma van hoekpunt C
     * @return gamma - De binnenhoek van hoekpunt C
     */
        public double GetInGamma()
        {
            var a2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineA()), 2);
            var b2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineB()), 2);
            var c2 = System.Math.Pow(this.DistanceCalculator.GetLength(this.GetLineC()), 2);
            return System.Math.Acos((a2 + b2 - c2) / (2 * this.DistanceCalculator.GetLength(this.GetLineA()) * this.DistanceCalculator.GetLength(this.GetLineB())));
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
            return new Line(this.DistanceCalculator)
            {
                P = this.B,
                Q = this.C
            };
        }


        public Line GetLineB()
        {
            return new Line(this.DistanceCalculator)
            {
                P = this.A,
                Q = this.C
            };
        }


        public Line GetLineC()
        {
            return new Line(this.DistanceCalculator)
            {
                P = this.A,
                Q = this.B
            };
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