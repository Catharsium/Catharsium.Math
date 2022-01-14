import javax.swing.* ;
import java.awt.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>DemoM.java</B><BR>
 * DemoM is een demonstratie van het M probleem; naast de driehoek die de
 * gebruiker invoert door op 3 punten te klikken (zie documentatie bij
 * DemoPanel), worden ook de middelloodlijnen, de omgeschreven cirkel en de
 * hulp-punten A', B' en C' naar het scherm getekend. Het middelpunt van de
 * omgeschreven cirkel dat wordt uitgerekend door de klasse TriangleM zal
 * daarnaast expliciet worden aangegeven met zijn co-ordinaten.<BR><BR>
 *
 * Wanneer nieuwe hoekpunten door de gebruiker worden toegevoegd zal dit naast
 * het onmiddelijk naar het scherm tekenen ervan, ook duidelijk worden gemaakt
 * met een bericht naar System.out. Wanneer de drie hoekpunten zijn ingevoerd
 * zal hier ook een bevestiging dat het M punt is berekend naar toe
 * gaan.<BR><BR>
 *
 * NB: Het label van het extra punt wordt altijd weergegeven op het scherm door
 * de co-ordinaten van het punt, zonder bijbehorende naam (letter). Het bericht
 * naar System.out bevat wel altijd alle informatie.<BR>
 * 
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version DemoM.java v1.0 --- (08-05-2002)
 */
public class DemoM extends DemoPanel {

    /** Default constructor; initialiseert het DemoPanel en registreert de
     * MouseListener voor het verkrijgen van de 3 hoekpunten
     */
    public DemoM() {
        super() ;
    }


    /** toString methode om een beschrijving van de klasse te kunnen geven
     * @return description - Beschrijving van de demonstratie als String
     */
    public String toString() {
        return ("DemoM (middelloodlijnen en omgeschreven cirkel)") ;
    }


    /** paintComponent tekent de beschikbare informatie (lijnen en punten) van
     *  de driehoek naar het scherm
     */
    public void paintComponent(Graphics g) {
        // Teken alles dat we al kunnen tekenen
        super.paintComponent(g) ;

        if(counter == 3) {
            // Driehoek ingevoerd; bereken de punten M, A', B' en C'
            TriangleM t = new TriangleM(p[0], p[1], p[2]) ;
            Point m = t.getM() ; m.setID("M") ;
            Point ac = t.getLineA().cutsWith(new Line(t.getA(), t.getM())) ;
            Point bc = t.getLineB().cutsWith(new Line(t.getB(), t.getM())) ;
            Point cc = t.getLineC().cutsWith(new Line(t.getC(), t.getM())) ;

            // Teken de lijnen MA', MB' en MC'
            g.setColor(Color.green) ;
            g.drawLine((int)Math.round(m.getX()), (int)Math.round(m.getY()),
                       (int)Math.round(t.getLineA().getPoint(1,1).getX()),
                       (int)Math.round(t.getLineA().getPoint(1,1).getY())) ;
            g.drawLine((int)Math.round(m.getX()), (int)Math.round(m.getY()),
                       (int)Math.round(t.getLineB().getPoint(1,1).getX()),
                       (int)Math.round(t.getLineB().getPoint(1,1).getY())) ;
            g.drawLine((int)Math.round(m.getX()), (int)Math.round(m.getY()),
                       (int)Math.round(t.getLineC().getPoint(1,1).getX()),
                       (int)Math.round(t.getLineC().getPoint(1,1).getY())) ;

            // Teken de lijnen AM, BM en CM
            g.setColor(Color.blue) ;
            g.drawLine(ax, ay, (int)Math.round(m.getX()),
                               (int)Math.round(m.getY())) ;
            g.drawLine(bx, by, (int)Math.round(m.getX()),
                               (int)Math.round(m.getY())) ;
            g.drawLine(cx, cy, (int)Math.round(m.getX()),
                               (int)Math.round(m.getY())) ;
            
            // Teken de punten A', B' en C'
            g.setColor(Color.green) ;
            g.drawOval((int)Math.round(t.getLineA().getPoint(1,1).getX())
                                       - POINT_RADIUS,
                       (int)Math.round(t.getLineA().getPoint(1,1).getY())
                                       - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)Math.round(t.getLineB().getPoint(1,1).getX())
                                       - POINT_RADIUS,
                       (int)Math.round(t.getLineB().getPoint(1,1).getY())
                                       - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)Math.round(t.getLineC().getPoint(1,1).getX())
                                       - POINT_RADIUS,
                       (int)Math.round(t.getLineC().getPoint(1,1).getY())
                                       - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;

            // En teken tenslotte de cirkel M met label
            g.setColor(Color.blue) ;
            int x = (int)Math.round(t.getM().getX()) - POINT_RADIUS ;
            int y = (int)Math.round(t.getM().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawString("[" +Math.round(m.getX())+
                         "," +Math.round(m.getY())+ "]",
                         (int)Math.round(m.getX() + 10),
                         (int)Math.round(m.getY() + 20)) ;
            int r = (int)Math.round(m.distanceTo(t.getA())) ;
            g.drawOval((int)Math.round(m.getX()) - r,
                       (int)Math.round(m.getY()) - r, 2*r, 2*r) ;
            

            // Schrijf het nieuwe resultaat naar System.out
            if(!b) {
                Circle c = new Circle(m, r) ; c.getP().setID("M") ;
                System.out.println("Extra punt & straal berekend: " +c) ;
                b = true ;
            }
        }
    }
}