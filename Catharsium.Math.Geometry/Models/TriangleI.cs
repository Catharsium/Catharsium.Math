namespace Catharsium.Math.Geometry.Models;

/**
 * TriangleI is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Circle I dat automatisch berekent wordt
 * wanneer een van de hoekpunten veranderd wordt of bij het maken van het
 * object.
 *
 * Probleem I:
 * Volgens de regel dat BA' staat tot A'C is als c staat tot b kunnen we A'
 * berekenen met de formule getPoint die als argumenten de lengtes c en b (de
 * volgorde is uiteraard van belang) mee krijgt. Hetzelfde geldt voor het punt
 * B'; CB' : B'A = c : a. Het snijpunt van de lijnen die we hieruit kunnen
 * maken (namelijk AA' en BB') is het gezochte punt I.
 * De straal van de ingeschreven cirkel is exact de afstand van het punt I tot
 * een van de zijden van de driehoek, bijvoorbeeld lijn BC.
 */
public class TriangleI : Triangle
{
    public Circle I { get; set; }


    /*  setE (E = Extra Point) berekent het I-Point van de Triangle en slaat de
 *  waarde op in het object; PRIVATE methode en geen Setter (ondanks de
 *  naam)! De methode wordt aangeroepen bij het maken van het object en bij
 *  het wijzigen van een van de hoekpunten
 */
    protected override void Recalculate()
    {
        // TODO
        //var Ac = this.GetLineA().GetPoint(this.DistanceCalculator.GetLength(this.GetLineC()), this.DistanceCalculator.GetLength(this.GetLineB()));
        //var Bc = this.GetLineB().GetPoint(this.DistanceCalculator.GetLength(this.GetLineC()), this.DistanceCalculator.GetLength(this.GetLineA()));
        //var ta = new Line(this.DistanceCalculator) {
        //    P = this.A,
        //    Q = Ac
        //};
        //var tb = new Line(this.DistanceCalculator) {
        //    P = this.B,
        //    Q = Bc
        //};
        //this.I = new Circle(this.AreaCalculator, this.CircumferenceCalculator) {
        //    Center = ta.CutsWith(tb),
        //    Radius = this.DistanceCalculator.GetDistance(ta.CutsWith(tb), this.GetLineA()),
        //    Id = "I"
        //};
    }


    public override string ToString()
    {
        return $"{base.ToString()} => {this.I}";
    }


    //public new static void Main(string[] args)
    //{
    //    var ti = new TriangleI(new Triangle(167, 371, 611, 371, 552, 101));
    //    Console.WriteLine(ti);
    //    ti = new TriangleI(new Triangle(261, 347, 653, 347, 653, 105));
    //    Console.WriteLine(ti);
    //    ti = new TriangleI(new Triangle(120, 300, 480, 380, 579, 197));
    //    Console.WriteLine(ti);
    //}
}