using System;

public class Triangle : Shape
{
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


    public Triangle(Point A, Point B, Point C) : this(A, B, C, "T")
    {
    }


    public Triangle(Point A, Point B, Point C, string id)
    {
        this.A = new Point(A);
        A.Id = "A";
        this.B = new Point(B);
        B.Id = "B";
        this.C = new Point(C);
        C.Id = "C";
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
        var a2 = Math.Pow(this.GetLengthA(), 2);
        var b2 = Math.Pow(this.GetLengthB(), 2);
        var c2 = Math.Pow(this.GetLengthC(), 2);
        var alpha = Math.Acos((b2 + c2 - a2) / (2 * this.GetLengthB() * this.GetLengthC()));
        return alpha * 360 / (2 * Math.PI);
    }


    /** getOutBeta berekent de binnenhoek beta van hoekpunt B
     * @return beta - De binnenhoek van hoekpunt B
     */
    public double GetInBeta()
    {
        var a2 = Math.Pow(this.GetLengthA(), 2);
        var b2 = Math.Pow(this.GetLengthB(), 2);
        var c2 = Math.Pow(this.GetLengthC(), 2);
        return Math.Acos((a2 + c2 - b2) / (2 * this.GetLengthA() * this.GetLengthC()));
    }


    /** getOutGamma berekent de binnenhoek gamma van hoekpunt C
     * @return gamma - De binnenhoek van hoekpunt C
     */
    public double GetInGamma()
    {
        var a2 = Math.Pow(this.GetLengthA(), 2);
        var b2 = Math.Pow(this.GetLengthB(), 2);
        var c2 = Math.Pow(this.GetLengthC(), 2);
        return Math.Acos((a2 + b2 - c2) / (2 * this.GetLengthA() * this.GetLengthB()));
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
        return Math.Sqrt(s * (s - this.GetLengthA()) *
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