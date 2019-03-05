using System;

public class Line : Shape
{
    private Point p;
    public Point P
    {
        get => this.p;
        set => this.p = new Point(value);
    }


    private Point q;
    public Point Q
    {
        get => this.q;
        set => this.q = new Point(value);
    }


    public Line() :
        this(0, 0, 0, 0)
    {
        this.P.Id = "P";
        this.Q.Id = "Q";
    }


    public Line(double x1, double y1, double x2, double y2) :
        this(new Point(x1, y1), new Point(x2, y2), "L")
    {
        this.P.Id = "P";
        this.Q.Id = "Q";
    }


    public Line(Point p, Point q) :
        this(new Point(p), new Point(q), "L")
    {
        this.P.Id = "P";
        this.Q.Id = "Q";
    }



    public Line(Point p, Point q, string id)
    {
        this.P = new Point(p)
        {
            Id = "P"
        };
        this.Q = new Point(q)
        {
            Id = "Q"
        };
        this.Id = new string(id);
    }


    public Line(Line l)
    {
        this.P = new Point(l.P)
        {
            Id = "P"
        };
        this.Q = new Point(l.Q)
        {
            Id = "Q"
        };
    }


    public double GetLength()
    {
        return this.P.DistanceTo(this.Q);
    }


    public Point GetPoint(double pr, double rq)
    {
        var part = 1.0 / (pr + rq);
        var vector = this.ToVector();
        // x = a.x + (labda * b.x) --> a.x = vector.p.X ;
        // labda = (pr * part) ; b.x = vector.q.X ;
        var x = vector.P.X + (pr * part * vector.Q.X);
        var y = vector.P.Y + (pr * part * vector.Q.Y);
        return new Point(x, y);
    }



    public Line ToVector()
    {
        var start = new Point(this.P);
        var dir = new Point(this.Q.X - this.P.X, this.Q.Y - this.P.Y);
        return new Line(start, dir);
    }


    /** toEq retourneert de vergelijking van de Line l als Point object waarbij
     * het x element als richting en het y element als hoogte fungeert
     * @return vergelijking - De vergelijking van de Line l
     */
    public Point ToEq()
    {
        double a, b;
        var dy = this.P.Y - this.Q.Y;
        var dx = this.P.X - this.Q.X;
        a = dy / dx;
        b = this.P.Y - (this.P.X * a);
        return new Point(a, b);
    }


    /** normalize berekent of het punt Q van een Line buiten het scherm met
     *  breedte w en hoogte h valt en projecteert in dat geval punt Q op een
     *  van de zijden van het scherm
     * @param w De breedte van het scherm
     * @param h De hoogte van het scherm
     */
    public void Normalize(int w, int h)
    {
        var dpq = this.P.DistanceTo(this.Q);

        if ((this.Q.X < 0) || (this.Q.X > w) || (this.Q.Y < 0) || (this.Q.Y > h))
        {
            var l = this.ToVector();
            double x = l.P.X, y = l.P.Y;
            double dx = l.Q.X, dy = l.Q.Y;

            if (dy != 0) { dx /= dy; dy /= dy; }
            else { dx = 1; }

            while ((x > 0) && (x < w) && (y > 0) && (y < h))
            {
                x += dx;
                y += dy;
                if (new Point(x, y).DistanceTo(this.Q) > dpq)
                {
                    dx *= -1; dy *= -1;
                }
            }
            this.Q = new Point(x, y);
        }
    }


    /** distanceTo berekent de afstand tussen een Line object en een Point
     * @param p Het Point waarvan de afstand tot het aanroepende Line object
     *            berekent moet worden
     * @return De afstand tussen de Line en het Point
     */
    public double DistanceTo(Point p)
    {
        // Bereken de lijn die loodrecht staat op het Line object en laat deze
        // door het Point p gaan. De afstand is de lengte van de Line tussen
        // p en het snijpunt de Line en zijn loodrechte tegenhanger
        var v = this.ToVector();
        var r = new Point(-1 * v.Q.Y, v.Q.X);
        var x2 = r.X + p.X;
        var y2 = r.Y + p.Y;
        v = new Line(p, new Point(x2, y2));
        r = this.CutsWith(v);
        return r.DistanceTo(v.P);
    }


    /** angleWith berekent de hoek tussen 2 Line objecten in graden
     * @param l De Line waarvan de hoek met het aanroepende Line object
     *            berekent moet worden
     * @return De hoek in graden tussen beide Line objecten
     */
    public double AngleWith(Line l)
    {
        var alfa = this.P.X - this.Q.X == 0 ? 90 :
            Math.Atan((this.P.Y - this.Q.Y) / (this.P.X - this.Q.X));
        var beta = l.P.X - l.Q.X == 0 ? 90 :
            Math.Atan((l.P.Y - l.Q.Y) /
                (l.P.X - l.Q.X));
        return Math.Abs(alfa - beta) * 360 / (2 * Math.PI);
    }


    /** cutsWith berekent het snijpunt van 2 Line objecten
     * @param l De Line waarvan het snijpunt met het aanroepende Line object
     *            berekent moet worden
     * @return Het snijpunt van beide Line objecten
     */
    public Point CutsWith(Line l)
    {
        double x, y;
        var f = l.ToEq();
        var g = this.ToEq();
        if (double.IsInfinity(g.X))
        {
            x = this.P.X;
            y = (f.X * x) + f.Y;
        }
        else if (double.IsInfinity(f.X))
        {
            x = l.P.X;
            y = (g.X * x) + g.Y;
        }
        else
        {
            x = (g.Y - f.Y) / (f.X - g.X);
            y = (f.X * x) + f.Y;
        }
        return new Point(x, y);
    }


    public override string ToString()
    {
        return $"{this.Id}:[{this.P},{this.Q}]";
    }


    public static void Main(string[] args)
    {
        var l = new Line(2, 3, 5, 7);
        var m = new Line(0, 0, 4, 8);

        Console.WriteLine(l + "\nLengte l: " + l.GetLength());
        Console.WriteLine(m + "\nLengte m: " + m.GetLength());
        Console.WriteLine("R midden op m: " + m.GetPoint(1, 1));
        Console.WriteLine("Hoek l_m: " + l.AngleWith(m));
        m = new Line(0, 0, 10, 10)
        {
            Id = "M"
        };
        l = new Line(0, 10, 9, 1)
        {
            Id = "L"
        };
        Console.WriteLine(l.CutsWith(m) + "\n");
        m = new Line(0, 0, -5, 10);
        Console.WriteLine(m.GetPoint(2, -1).ToStringDouble());
    }
}