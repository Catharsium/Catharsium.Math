using System;

public class Circle : Shape
{

    private Point p;
    public Point P
    {
        get => this.p;
        set => this.p = new Point(value);
    }


    private double R;


    public Circle() :
        this(0, 0, 0)
    {
    }


    public Circle(double x, double y, double r) :
        this(new Point(x, y), r, "C")
    {
    }



    public Circle(double x, double y, double r, string id) :
        this(new Point(x, y), r, id)
    {
    }

    public Circle(Point p, double r) :
        this(p, r, "C")
    {
    }


    public Circle(Point p, double r, string id)
    {
        this.P = new Point(p);
        this.R = r;
        this.Id = "C";
    }

    
    public Circle(Circle c) :
        this(c.P, c.R, c.Id)
    {
    }
    

    public double GetPerimeter()
    {
        return 2 * Math.PI * this.R;
    }


    public double GetArea()
    {
        return Math.PI * Math.Pow(this.R, 2);
    }


    public override string ToString()
    {
        return $"{this.Id}:[{this.P},{this.R}:{Math.Round(this.R)}]";
    }


    public static void Main(string[] args)
    {
        var c = new Circle(2, 3, 5);
        var l = new Line(1, 2, 3, 4);
        var d = new Circle(5, 2, 10);
        var e = new Circle(0, 0, 8);
        Console.WriteLine(c + "\n" + c.GetArea());
        Console.WriteLine(d + "\n" + d.GetArea());
        Console.WriteLine(l + "\n" + l.GetLength());
        Console.WriteLine(e + "\n" + e.GetArea());
    }
}