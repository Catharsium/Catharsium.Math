using Catharsium.Math.Geometry.Interfaces;

/**
 * TriangleIABC is een Triangle object (zie de documentatie bij de klasse
 * Triangle) met als uitbreiding een Circle I en drie Circle objecten K, L en M
 * dat automatisch berekent wordt wanneer een van de hoekpunten veranderd wordt
 * of bij het maken van het object.
 *
 * Probleem IABC:
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
 */
namespace Catharsium.Math.Geometry.Models
{
    public class TriangleIabc : TriangleI
    {
        #region Properties

        protected Circle K { get; set; }
        protected Circle L { get; set; }
        protected Circle M { get; set; }

        #endregion


        /*  setE (E = Extra Point) berekent het I, IA, IB en IC Point met de
     *  bijbehorende stralen van de Triangle en slaat de waarde op in het
     *  object; PRIVATE methode en geen Setter (ondanks de naam)! De methode
     *  wordt aangeroepen bij het maken van het object en bij het wijzigen van
     *  een van de hoekpunten
     */
        //protected override void Recalculate()
        //{
        //    var ti = new TriangleI {
        //        A = this.A,
        //        B = this.B,
        //        C = this.C,
        //        Id = "I"
        //    };
        //    var la = new Line {
        //        P = ti.I.Center,
        //        Q = ti.A
        //    };
        //    var lb = new Line {
        //        P = ti.I.Center,
        //        Q = ti.B
        //    };
        //    var lc = new Line {
        //        P = ti.I.Center,
        //        Q = ti.C
        //    };
        //    // Bereken de lijnen loodrecht op AA', BB' en CC'

        //    // TODO
        //   // var dir = la.ToVector().Q;
        //    la = new Line {
        //        P = ti.A,
        //       // Q = new Point(-dir.Y + ti.A.X, dir.X + ti.A.Y)
        //    };
        //   // dir = lb.ToVector().Q;
        //    lb = new Line {
        //        P = ti.B,
        //      //  Q = new Point(-dir.Y + ti.B.X, dir.X + ti.B.Y)
        //    };
        //   // dir = lc.ToVector().Q;
        //    lc = new Line {
        //        P = ti.C,
        //      //  Q = new Point(-dir.Y + ti.C.X, dir.X + ti.C.Y)
        //    };

        //    this.I = ti.I;
        //    this.I.Id = "I";
        //    this.K = new Circle {
        //        Center = lb.CutsWith(lc),
        //        Radius = ti.GetArea() / ((this.CircumferenceCalculator.GetCircumference(ti) / 2) - this.DistanceCalculator.GetLength(ti.GetLineA())),
        //        Id = "IA"
        //    };
        //    this.L = new Circle {
        //        Center = la.CutsWith(lc),
        //        Radius = ti.GetArea() / ((this.CircumferenceCalculator.GetCircumference(ti) / 2) - this.DistanceCalculator.GetLength(ti.GetLineB())),
        //        Id = "IB"
        //    };
        //    this.M = new Circle {
        //        Center = la.CutsWith(lb),
        //        Radius = ti.GetArea() / ((this.CircumferenceCalculator.GetCircumference(ti) / 2) - this.DistanceCalculator.GetLength(ti.GetLineC())),
        //        Id = "IC"
        //    };
        //}


        public override string ToString()
        {
            return $"{base.ToString()} => {this.I},{this.K},{this.L},{this.M}";
        }


        //public new static void Main(string[] args)
        //{
        //    var ti = new TriangleIABC(new Triangle(332, 383, 528, 303, 485, 193));
        //    Console.WriteLine(ti);
        //    ti = new TriangleIABC(new Triangle(346, 343, 495, 358, 537, 250));
        //    Console.WriteLine(ti);
        //}
    }
}