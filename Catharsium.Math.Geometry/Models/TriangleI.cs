using System;
using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;

/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF1<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>TriangleI.java</B><BR>
 * TriangleI is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Circle I dat automatisch berekent wordt
 * wanneer een van de hoekpunten veranderd wordt of bij het maken van het
 * object.<BR><BR>
 *
 * <B>Probleem I:</B><BR>
 * Volgens de regel dat BA' staat tot A'C is als c staat tot b kunnen we A'
 * berekenen met de formule getPoint die als argumenten de lengtes c en b (de
 * volgorde is uiteraard van belang) mee krijgt. Hetzelfde geldt voor het punt
 * B'; CB' : B'A = c : a. Het snijpunt van de lijnen die we hieruit kunnen
 * maken (namelijk AA' en BB') is het gezochte punt I.<BR>
 * De straal van de ingeschreven cirkel is exact de afstand van het punt I tot
 * een van de zijden van de driehoek, bijvoorbeeld lijn BC.<BR>
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version TriangleI.java v1.0 --- (28-04-2002)
 */
public class TriangleI : Triangle
{
    public Circle I;
    protected readonly IDistanceCalculator distanceCalculator;


    public TriangleI() : base()
    {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    public TriangleI(Point a, Point b, Point c) : base(a, b, c, "T")
    {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    public TriangleI(Point a, Point b, Point c, string id) : base(a, b, c, id)
    {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    public TriangleI(Triangle t) : base(t)
    {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    public TriangleI(TriangleI t) : this(t.A, t.B, t.C, t.Id)
    {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    /** Setter van Point A
     * @param A - De nieuwe waarde (locatie) voor het eerste hoekpunt
     */
    public void SetA(Point a)
    {
        this.A = new Point(a);
        this.SetE();
    }

    /** Setter van Point B
     * @param B - De nieuwe waarde (locatie) voor het tweede hoekpunt
     */
    public void SetB(Point b)
    {
        this.B = new Point(b);
        this.SetE();
    }

    /** Setter van Point C
     * @param C - De nieuwe waarde (locatie) voor het derde hoekpunt
     */
    public void SetC(Point c)
    {
        this.C = new Point(c);
        this.SetE();
    }


    /*  setE (E = Extra Point) berekent het I-Point van de Triangle en slaat de
     *  waarde op in het object; PRIVATE methode en geen Setter (ondanks de
     *  naam)! De methode wordt aangeroepen bij het maken van het object en bij
     *  het wijzigen van een van de hoekpunten
     */
    private void SetE()
    {
        var Ac = this.GetLineA().GetPoint(this.distanceCalculator.GetLength(this.GetLineC()), this.distanceCalculator.GetLength(this.GetLineB()));
        var Bc = this.GetLineB().GetPoint(this.distanceCalculator.GetLength(this.GetLineC()), this.distanceCalculator.GetLength(this.GetLineA()));
        var ta = new Line(this.A, Ac);
        var tb = new Line(this.B, Bc);
        this.I = new Circle(ta.CutsWith(tb), this.distanceCalculator.GetDistance(ta.CutsWith(tb), this.GetLineA()))
        {
            Id = "I"
        };
    }


    public override string ToString()
    {
        return $"{new Triangle(this)} => {this.I}";
    }


    public new static void Main(string[] args)
    {
        var ti = new TriangleI(new Triangle(167, 371, 611, 371, 552, 101));
        Console.WriteLine(ti);
        ti = new TriangleI(new Triangle(261, 347, 653, 347, 653, 105));
        Console.WriteLine(ti);
        ti = new TriangleI(new Triangle(120, 300, 480, 380, 579, 197));
        Console.WriteLine(ti);
    }
}