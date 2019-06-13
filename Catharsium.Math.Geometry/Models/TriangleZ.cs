using Catharsium.Math.Geometry.Interfaces;

/**
 * TriangleZ is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Point Z dat automatisch berekent wordt
 * wanneer een van de hoekpunten veranderd wordt of bij het maken van het
 * object.
 *
 * Probleem Z:
 * We zoeken het snijpunt van de lijnen AA' en BB' waarbij A en B twee
 * hoekpunten van de driehoek zijn en A', B' twee punten die respectievelijk
 * op het midden van de lijnen BC en AC liggen. A' en B' zijn eenvoudig te
 * berekenen met de getPoint methode uit de klasse Line en de combinaties van A
 * met A' en B met B' leveren twee lijnen op. Het snijpunt van deze lijnen is
 * zoals gezegd het gezochte punt.
 */
namespace Catharsium.Math.Geometry.Models
{
    public class TriangleZ : Triangle
    {
        #region Properties

        protected Point Z { get; set; }

        #endregion

        public TriangleZ(
            IAreaCalculator areaCalculator,
            IDistanceCalculator distanceCalculator,
            ICircumferenceCalculator circumferenceCalculator)
            : base(areaCalculator, distanceCalculator, circumferenceCalculator) { }


        /* berekent het Z-Point van de Triangle en slaat de
     *  waarde op in het object; PRIVATE methode en geen Setter (ondanks de
     *  naam)! De methode wordt aangeroepen bij het maken van het object en bij
     *  het wijzigen van een van de hoekpunten
     */
        protected override void Recalculate()
        {
            // TODO
            //var ra = new Point(this.GetLineA().GetPoint(1, 1));
            //var rb = new Point(this.GetLineB().GetPoint(1, 1));
            //var ta = new Line(this.DistanceCalculator) {
            //    P = this.A,
            //    Q = ra
            //};
            //var tb = new Line(this.DistanceCalculator) {
            //    P = this.B,
            //    Q = rb
            //};
            //this.Z = new Point(ta.CutsWith(tb)) {
            //    Id = "Z"
            //};
        }


        public override string ToString()
        {
            return $"{base.ToString()} => {this.Z}";
        }


        //public new static void Main(string[] args)
        //{
        //    var tz = new TriangleZ(new Triangle(106, 408, 610, 408, 531, 120));
        //    Console.WriteLine(tz);
        //    tz = new TriangleZ(new Triangle(245, 366, 609, 366, 244, 119));
        //    Console.WriteLine(tz);
        //    tz = new TriangleZ(new Triangle(120, 199, 484, 339, 687, 148));
        //    Console.WriteLine(tz);
        //}
    }
}