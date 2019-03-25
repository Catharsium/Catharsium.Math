using System;
using Catharsium.Math.Geometry.Models;

/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF1<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>TriangleM.java</B><BR>
 * TriangleM is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Point M dat automatisch berekent wordt
 * wanneer een van de hoekpunten veranderd wordt of bij het maken van het
 * object.<BR><BR>
 *
 * <B>Probleem M:</B><BR>
 * Een oplossing van dit probleem ligt in de combinatie van de problemen H en
 * Z; we zoeken het snijpunt van de lijnen A'A'' en B'B'', waarbij A' en B'
 * respectievelijk op het midden van de lijnen BC en AC liggen en A'' en B''
 * op de lijnen vanuit A' en B' met richtingen die loodrecht staan de genoemde
 * lijnen BC en AC. We bepalen dus de middelpunten van de lijnen BC en AC en
 * vervolgens de loodrechte richtingen op deze lijnen. De gevonden lijnen A'A''
 * en B'B'' laten we snijden en het resultaat is het gezochte punt M.<BR>
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version TriangleM.java v1.0 --- (28-04-2002)
 */
public class TriangleM : Triangle {
    protected Point M { get; set; }


    public TriangleM() : base() {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    public TriangleM(Point A, Point B, Point C) : base(A, B, C, "T") {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    public TriangleM(Point A, Point B, Point C, string id) : base(A, B, C, id) {
        this.SetE();
        this.A.Id = "A" ;
        this.B.Id = "B" ;
        this.C.Id = "C";
    }


    public TriangleM(Triangle t) : base(t) {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }


    public TriangleM(TriangleM t) : this(t.A, t.B, t.C, t.Id) {
        this.SetE();
        this.A.Id = "A";
        this.B.Id = "B";
        this.C.Id = "C";
    }



    /** Setter van Point A
     * @param A - De nieuwe waarde (locatie) voor het eerste hoekpunt
     */
    public void SetA(Point a) {
        this.A = new Point(a);
        this.SetE();
    }

    /** Setter van Point B
     * @param B - De nieuwe waarde (locatie) voor het tweede hoekpunt
     */
    public void SetB(Point b) {
        this.B = new Point(b);
        this.SetE();
    }

    /** Setter van Point C
     * @param C - De nieuwe waarde (locatie) voor het derde hoekpunt
     */
    public void SetC(Point c) {
        this.C = new Point(c);
        this.SetE();
    }


    /*  setE (E = Extra Point) berekent het M-Point van de Triangle en slaat de
     *  waarde op in het object; PRIVATE methode en geen Setter (ondanks de
     *  naam)! De methode wordt aangeroepen bij het maken van het object en bij
     *  het wijzigen van een van de hoekpunten
     */
    private void SetE() {
        var ma = new Point(this.GetLineA().GetPoint(1, 1));
        var mb = new Point(this.GetLineB().GetPoint(1, 1));
        var ya = ma.Y - (ma.X * (-1 / this.GetLineA().ToEq().X));
        var yb = mb.Y - (mb.X * (-1 / this.GetLineB().ToEq().X));
        var ta = new Line(ma, new Point(0, ya));
        var tb = new Line(mb, new Point(0, yb));
        this.M = new Point(ta.CutsWith(tb))
        {
            Id = "M"
        };
    }


    public override string ToString() {
        return $"{new Triangle(this)} => {this.M}";
    }


    public new static void Main(string[] args) {
        var tm = new TriangleM(new Triangle(175, 400, 574, 400, 492, 190));
        Console.WriteLine(tm);
        tm = new TriangleM(new Triangle(262, 367, 582, 367, 582, 144));
        Console.WriteLine(tm);
        tm = new TriangleM(new Triangle(165, 350, 441, 371, 599, 263));
        Console.WriteLine(tm);
    }
}