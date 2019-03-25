using System;
using Catharsium.Math.Geometry.Interfaces;

public class Line : Shape
{
    private readonly IDistanceCalculator distanceCalculator;


    public Line(IDistanceCalculator distanceCalculator)
    {
        this.distanceCalculator = distanceCalculator;
    }


    #region Properties

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

    #endregion

    #region Construction

    public Line() : this(0, 0, 0, 0)
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
        this.Id = id;
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

    #endregion

    public double GetLength()
    {
        return this.distanceCalculator.GetDistance(this.P, this.Q);
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
        var direction = new Point(this.Q.X - this.P.X, this.Q.Y - this.P.Y);
        return new Line(start, direction);
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
        var dpq = this.distanceCalculator.GetDistance(this.P, this.Q);

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
                if (this.distanceCalculator.GetDistance(new Point(x, y), this.Q) > dpq)
                {
                    dx *= -1; dy *= -1;
                }
            }
            this.Q = new Point(x, y);
        }
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
}