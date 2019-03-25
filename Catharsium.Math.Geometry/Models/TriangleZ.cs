using System;

/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF1<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>TriangleZ.java</B><BR>
 * TriangleZ is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Point Z dat automatisch berekent wordt
 * wanneer een van de hoekpunten veranderd wordt of bij het maken van het
 * object.<BR><BR>
 *
 * <B>Probleem Z:</B><BR>
 * We zoeken het snijpunt van de lijnen AA' en BB' waarbij A en B twee
 * hoekpunten van de driehoek zijn en A', B' twee punten die respectievelijk
 * op het midden van de lijnen BC en AC liggen. A' en B' zijn eenvoudig te
 * berekenen met de getPoint methode uit de klasse Line en de combinaties van A
 * met A' en B met B' leveren twee lijnen op. Het snijpunt van deze lijnen is
 * zoals gezegd het gezochte punt.<BR>
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version TriangleZ.java v1.0 --- (27-04-2002)
 */
namespace Catharsium.Math.Geometry.Models
{
    public class TriangleZ : Triangle
    {

        protected Point Z { get; set; }


        public TriangleZ() : base()
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleZ(Point A, Point B, Point C) :
            base(A, B, C, "T")
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleZ(Point A, Point B, Point C, string id) : base(A, B, C, id)
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleZ(Triangle t) : base(t)
        {
            this.SetE();
            this.A.Id = "A";
            this.B.Id = "B";
            this.C.Id = "C";
        }


        public TriangleZ(TriangleZ t) : this(t.A, t.B, t.C, t.Id)
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


        /*  setE (E = Extra Point) berekent het Z-Point van de Triangle en slaat de
     *  waarde op in het object; PRIVATE methode en geen Setter (ondanks de
     *  naam)! De methode wordt aangeroepen bij het maken van het object en bij
     *  het wijzigen van een van de hoekpunten
     */
        private void SetE()
        {
            var ra = new Point(this.GetLineA().GetPoint(1, 1));
            var rb = new Point(this.GetLineB().GetPoint(1, 1));
            var ta = new Line(this.A, ra);
            var tb = new Line(this.B, rb);
            this.Z = new Point(ta.CutsWith(tb)) {
                Id = "Z"
            };
        }


        public override string ToString()
        {
            return $"{new Triangle(this)} => {this.Z}";
        }


        public new static void Main(string[] args)
        {
            var tz = new TriangleZ(new Triangle(106, 408, 610, 408, 531, 120));
            Console.WriteLine(tz);
            tz = new TriangleZ(new Triangle(245, 366, 609, 366, 244, 119));
            Console.WriteLine(tz);
            tz = new TriangleZ(new Triangle(120, 199, 484, 339, 687, 148));
            Console.WriteLine(tz);
        }
    }
}