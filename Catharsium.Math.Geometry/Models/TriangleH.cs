using System;

/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF1<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>TriangleH.java</B><BR>
 * TriangleH is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Point H dat automatisch berekent wordt
 * wanneer een van de hoekpunten veranderd wordt of bij het maken van het
 * object.<BR><BR>
 *
 * <B>Probleem H:</B><BR>
 * De lijn AA' staat loodrecht op (het verlengde van) de lijn BC, dus wanneer
 * de richting van de lijn bepalen die loodrecht op BC staat en deze door het
 * punt A laten gaan hebben we een van de 3 lijnen die we zoeken. Hetzelfde
 * passen we toe op BB' en de lijn AC. Het snijpunt van beide gevonden lijnen
 * is tevens het punt dat we zoeken.<BR>
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version TriangleH.java v1.0 --- (28-04-2002)
 */
namespace Catharsium.Math.Geometry.Models
{
    public class TriangleH : Triangle
    {
        protected Point H;


        public TriangleH() : base()
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleH(Point a, Point b, Point c) : base(a, b, c, "T")
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleH(Point a, Point b, Point c, string id) : base(a, b, c, id)
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleH(Triangle t) : base(t)
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleH(TriangleH t) : this(t.A, t.B, t.C, t.Id)
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public void SetA(Point a)
        {
            this.A = new Point(a);
            this.SetE();
        }


        public void SetB(Point b)
        {
            this.B = new Point(b);
            this.SetE();
        }


        public void SetC(Point c)
        {
            this.C = new Point(c);
            this.SetE();
        }



        /*  setE (E = Extra Point) berekent het H-Point van de Triangle en slaat de
     *  waarde op in het object; PRIVATE methode en geen Setter (ondanks de
     *  naam)! De methode wordt aangeroepen bij het maken van het object en bij
     *  het wijzigen van een van de hoekpunten
     */
        private void SetE()
        {
            var ra = -1 / this.GetLineA().ToEq().X;
            var rb = -1 / this.GetLineB().ToEq().X;
            var ya = this.A.Y - (this.A.X * ra);
            var yb = this.B.Y - (this.B.X * rb);
            var ta = new Line(this.A, new Point(0, ya));
            var tb = new Line(this.B, new Point(0, yb));
            this.H = new Point(ta.CutsWith(tb)) {
                Id = "H"
            };
        }


        public override string ToString()
        {
            return $"{new Triangle(this)} => {this.H}";
        }


        public new static void Main(string[] args)
        {
            var th = new TriangleH(new Triangle(178, 377, 649, 377, 557, 101));
            Console.WriteLine(th);
            th = new TriangleH(new Triangle(244, 378, 605, 378, 244, 115));
            Console.WriteLine(th);
            th = new TriangleH(new Triangle(123, 244, 405, 298, 518, 172));
            Console.WriteLine(th);
        }
    }
}