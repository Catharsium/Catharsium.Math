using System;

/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF1<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>TriangleIABC.java</B><BR>
 * TriangleIABC is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Circle I en drie Circle objecten K, L en M
 * dat automatisch berekent wordt wanneer een van de hoekpunten veranderd wordt
 * of bij het maken van het object.<BR><BR>
 *
 * <B>Probleem IABC:</B><BR>
 * Circle I kunnen we berekenen door een TriangleI object van het TriangleIABC
 * object te maken. Dit gebeurt door de TriangleIABC naar een Triangle te
 * casten en dit object als argument van een TriangleI constructor mee te geven
 * waarna we de Circle I kunnen opvragen.
 * Point IA is het snijpunt van de buitenhoekdeellijnen van de hoekpunten B en
 * C, ofwel het snijpunt van de lijnen die loodrecht op de binnenhoekdeellijnen
 * van de punten B en C staan. Deze binnenhoekdeellijnen zijn de lijnen IB en
 * IC. Als we alle drie de buitenhoekdeellijnen hebben kunnen we de telkens het
 * juiste tweetal laten snijden om de punten IA, IB en IC te krijgen. De
 * straal van de cirkel IA is te berekenen volgens: O / (s-a).
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version TriangleIABC.java v1.0 --- (02-05-2002)
 */
public class TriangleIABC : TriangleI {

    protected Circle K { get; set; }
    protected Circle L { get; set; }
    protected Circle M { get; set; }


    public TriangleIABC() : base()
    {
        this.SetE();
        this.A.Id = "IA";
        this.B.Id = "IB";
        this.C.Id = "IC";
    }


    public TriangleIABC(Point a, Point b, Point c) : base(a, b, c, "T") {
        this.SetE();
        this.A.Id = "IA";
        this.B.Id = "IB";
        this.C.Id = "IC";
    }


    public TriangleIABC(Point a, Point b, Point c, string id) : base(a, b, c, id) {
        this.SetE();
        this.A.Id = "IA";
        this.B.Id = "IB";
        this.C.Id = "IC";
    }


    public TriangleIABC(Triangle t) : base(t) {
        this.SetE();
        this.A.Id = "IA";
        this.B.Id = "IB";
        this.C.Id = "IC";
    }


    public TriangleIABC(TriangleIABC t) : this(t.A, t.B, t.C, t.Id) {
        this.SetE();
        this.A.Id = "IA";
        this.B.Id = "IB";
        this.C.Id = "IC";
    }


    /** Setter van Point A
     * @param A - De nieuwe waarde (locatie) voor het eerste eindpunt
     */
    public void SetA(Point a) {
        this.A = new Point(a);
        this.SetE();
    }

    /** Setter van Point B
     * @param B - De nieuwe waarde (locatie) voor het tweede eindpunt
     */
    public void SetB(Point b) {
        this.B = new Point(b);
        this.SetE();
    }

    /** Setter van Point C
     * @param C - De nieuwe waarde (locatie) voor het derde eindpunt
     */
    public void SetC(Point c) {
        this.C = new Point(c);
        this.SetE();
    }


    /*  setE (E = Extra Point) berekent het I, IA, IB en IC Point met de
     *  bijbehorende stralen van de Triangle en slaat de waarde op in het
     *  object; PRIVATE methode en geen Setter (ondanks de naam)! De methode
     *  wordt aangeroepen bij het maken van het object en bij het wijzigen van
     *  een van de hoekpunten
     */
    private void SetE() {
        Point dir;
        var ti = new TriangleI((Triangle)this);
        var la = new Line(ti.I.P, ti.A);
        var lb = new Line(ti.I.P, ti.B);
        var lc = new Line(ti.I.P, ti.C);
        // Bereken de lijnen loodrecht op AA', BB' en CC'
        dir = la.ToVector().Q;
        la = new Line(ti.A, new Point(-dir.Y + ti.A.X, dir.X + ti.A.Y));
        dir = lb.ToVector().Q;
        lb = new Line(ti.B, new Point(-dir.Y + ti.B.X, dir.X + ti.B.Y));
        dir = lc.ToVector().Q;
        lc = new Line(ti.C, new Point(-dir.Y + ti.C.X, dir.X + ti.C.Y));

        this.I = ti.I;
        this.I.Id = "I";
        this.K = new Circle(lb.CutsWith(lc), ti.GetArea() / ((ti.GetPerimeter() / 2) - ti.GetLengthA()))
        {
            Id = "IA"
        };
        this.L = new Circle(la.CutsWith(lc), ti.GetArea() / ((ti.GetPerimeter() / 2) - ti.GetLengthB()))
        {
            Id = "IB"
        };
        this.M = new Circle(la.CutsWith(lb), ti.GetArea() / ((ti.GetPerimeter() / 2) - ti.GetLengthC()))
        {
            Id = "IC"
        };
    }


    public override string ToString() {
        return $"{new Triangle(this)} => {this.I},{this.K},{this.L},{this.M}";
    }


    public new static void Main(string[] args) {
        var ti = new TriangleIABC(new Triangle(332, 383, 528, 303, 485, 193));
        Console.WriteLine(ti);
        ti = new TriangleIABC(new Triangle(346, 343, 495, 358, 537, 250));
        Console.WriteLine(ti);
    }
}