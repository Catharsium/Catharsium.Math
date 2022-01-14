namespace Catharsium.Math.Geometry.Models;

public class Line : Shape
{
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

    #region Mathematical Properties

    public Point GetPoint(double pr, double rq)
    {
        var part = 1.0 / (pr + rq);
        var vector = this.ToVector();
        // x = a.x + (lambda * b.x) --> a.x = vector.p.X ;
        // lambda = (pr * part) ; b.x = vector.q.X ;
        var x = vector.P.X + pr * part * vector.Q.X;
        var y = vector.P.Y + pr * part * vector.Q.Y;
        return new Point(x, y);
    }


    public Line ToVector()
    {
        var start = new Point(this.P);
        var direction = new Point(this.Q.X - this.P.X, this.Q.Y - this.P.Y);
        return new Line {
            P = start,
            Q = direction
        };
    }


    /** toEq retourneert de vergelijking van de Line l als Point object waarbij
 * het x element als richting en het y element als hoogte fungeert
 * @return vergelijking - De vergelijking van de Line l
 */
    public Point ToEq()
    {
        var dy = this.P.Y - this.Q.Y;
        var dx = this.P.X - this.Q.X;
        var a = dy / dx;
        var b = this.P.Y - this.P.X * a;
        return new Point(a, b);
    }


    /** normalize berekent of het punt Q van een Line buiten het scherm met
 *  breedte w en hoogte h valt en projecteert in dat geval punt Q op een
 *  van de zijden van het scherm
 * @param w De breedte van het scherm
 * @param h De hoogte van het scherm
 */
    //public void Normalize(int w, int h)
    //{
    //    var dpq = this.distanceCalculator.GetDistance(this.P, this.Q);

    //    if ((this.Q.X < 0) || (this.Q.X > w) || (this.Q.Y < 0) || (this.Q.Y > h)) {
    //        var l = this.ToVector();
    //        double x = l.P.X, y = l.P.Y;
    //        double dx = l.Q.X, dy = l.Q.Y;

    //        if (dy != 0) {
    //            dx /= dy;
    //            dy /= dy;
    //        }
    //        else { dx = 1; }

    //        while ((x > 0) && (x < w) && (y > 0) && (y < h)) {
    //            x += dx;
    //            y += dy;
    //            if (this.distanceCalculator.GetDistance(new Point(x, y), this.Q) > dpq) {
    //                dx *= -1;
    //                dy *= -1;
    //            }
    //        }

    //        this.Q = new Point(x, y);
    //    }
    //}


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
        if (double.IsInfinity(g.X)) {
            x = this.P.X;
            y = (f.X * x) + f.Y;
        }
        else if (double.IsInfinity(f.X)) {
            x = l.P.X;
            y = (g.X * x) + g.Y;
        }
        else {
            x = (g.Y - f.Y) / (f.X - g.X);
            y = (f.X * x) + f.Y;
        }

        return new Point(x, y);
    }

    #endregion

    public override string ToString()
    {
        return $"{this.Id}:[{this.P},{this.Q}]";
    }
}