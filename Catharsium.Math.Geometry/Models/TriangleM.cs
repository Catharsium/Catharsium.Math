using Catharsium.Math.Geometry.Interfaces;

/**
 * TriangleM is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Point M dat automatisch berekent wordt
 * wanneer een van de hoekpunten veranderd wordt of bij het maken van het
 * object.
 *
 * Probleem M:
 * Een oplossing van dit probleem ligt in de combinatie van de problemen H en
 * Z; we zoeken het snijpunt van de lijnen A'A'' en B'B'', waarbij A' en B'
 * respectievelijk op het midden van de lijnen BC en AC liggen en A'' en B''
 * op de lijnen vanuit A' en B' met richtingen die loodrecht staan de genoemde
 * lijnen BC en AC. We bepalen dus de middelpunten van de lijnen BC en AC en
 * vervolgens de loodrechte richtingen op deze lijnen. De gevonden lijnen A'A''
 * en B'B'' laten we snijden en het resultaat is het gezochte punt M.
 */
namespace Catharsium.Math.Geometry.Models
{
    public class TriangleM : Triangle
    {
        protected Point M { get; set; }


        public TriangleM(IAreaCalculator areaCalculator, IDistanceCalculator distanceCalculator, ICircumferenceCalculator circumferenceCalculator) :
            base(areaCalculator, distanceCalculator, circumferenceCalculator) { }


        /*  setE (E = Extra Point) berekent het M-Point van de Triangle en slaat de
     *  waarde op in het object; PRIVATE methode en geen Setter (ondanks de
     *  naam)! De methode wordt aangeroepen bij het maken van het object en bij
     *  het wijzigen van een van de hoekpunten
     */
        protected override void Recalculate()
        {
            var ma = new Point(this.GetLineA().GetPoint(1, 1));
            var mb = new Point(this.GetLineB().GetPoint(1, 1));
            var ya = ma.Y - (ma.X * (-1 / this.GetLineA().ToEq().X));
            var yb = mb.Y - (mb.X * (-1 / this.GetLineB().ToEq().X));
            var ta = new Line(this.DistanceCalculator) {
                P = ma,
                Q = new Point(0, ya)
            };
            var tb = new Line(this.DistanceCalculator) {
                P = mb,
                Q = new Point(0, yb)
            };
            this.M = new Point(ta.CutsWith(tb)) {
                Id = "M"
            };
        }


        public override string ToString()
        {
            return $"{base.ToString()} => {this.M}";
        }


        //public new static void Main(string[] args)
        //{
        //    var tm = new TriangleM(new Triangle(175, 400, 574, 400, 492, 190));
        //    Console.WriteLine(tm);
        //    tm = new TriangleM(new Triangle(262, 367, 582, 367, 582, 144));
        //    Console.WriteLine(tm);
        //    tm = new TriangleM(new Triangle(165, 350, 441, 371, 599, 263));
        //    Console.WriteLine(tm);
        //}
    }
}