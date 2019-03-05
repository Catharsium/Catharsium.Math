using System;

public class Point : Shape
{
    public double X { get; set; }
    public double Y { get; set; }


    public Point() :
        this(0, 0)
    {
    }


    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;

        this.Id = "P";
    }


    public Point(double x, double y, string id) : this(x, y)
    {
        this.Id = id;
    }


    public Point(Point p) : this(p.X, p.Y, p.Id)
    {
    }


    public double DistanceTo(Point p)
    {
        var dx = Math.Pow(p.X - this.X, 2);
        var dy = Math.Pow(p.Y - this.Y, 2);
        return Math.Sqrt(dx + dy);
    }


    public double DistanceTo(Line l)
    {
        return l.DistanceTo(this);
    }


    public override string ToString()
    {
        return this.Id + ":[" + Math.Round(this.X) + "," + Math.Round(this.Y) + "]";
    }


    public string ToStringDouble()
    {
        return $"{this.Id}:[{this.X},{this.Y}]";
    }


    public static void Main(string[] args)
    {
        var p = new Point(1, 4);
        var q = new Point(3, 9)
        {
            Id = "Q"
        };
        Console.WriteLine(p + "\n" + q);
    }
}