using System;

public class Circle : Shape
{
    #region Properties

    private Point center;
    public Point Center
    {
        get => this.center;
        set => this.center = new Point(value);
    }


    public double Radius { get; set; }

    #endregion

    #region Construction

    public Circle() : this(0, 0, 0)
    {
    }


    public Circle(double x, double y, double r) : this(new Point(x, y), r, "C")
    {
    }


    public Circle(double x, double y, double r, string id) : this(new Point(x, y), r, id)
    {
    }


    public Circle(Point p, double r) : this(p, r, "C")
    {
    }


    public Circle(Point p, double r, string id)
    {
        this.Center = new Point(p);
        this.Radius = r;
        this.Id = "C";
    }


    public Circle(Circle c) : this(c.Center, c.Radius, c.Id)
    {
    }

    #endregion

    public double GetPerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }


    public double GetArea()
    {
        return Math.PI * Math.Pow(this.Radius, 2);
    }


    public override string ToString()
    {
        return $"{this.Id}:[{this.Center},{this.Radius}:{Math.Round(this.Radius)}]";
    }
}