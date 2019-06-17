import javax.swing.* ;
import java.awt.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>DemoZ.java</B><BR>
 * DemoZ is een demonstratie van het Z probleem; naast de driehoek die de
 * gebruiker invoert door op 3 punten te klikken (zie documentatie bij
 * DemoPanel), worden ook de zwaartelijnen met hulp-punten A', B' en C' naar
 * het scherm getekend. Het zwaartepunt dat wordt uitgerekend door de klasse
 * TriangleZ zal daarnaast expliciet worden aangegeven met zijn
 * co-ordinaten.<BR><BR>
 *
 * Wanneer nieuwe hoekpunten door de gebruiker worden toegevoegd zal dit naast
 * het onmiddelijk naar het scherm tekenen ervan, ook duidelijk worden gemaakt
 * met een bericht naar System.out. Wanneer de drie hoekpunten zijn ingevoerd
 * zal hier ook een bevestiging dat het Z punt is berekend naar toe
 * gaan.<BR><BR>
 *
 * NB: Het label van het extra punt wordt altijd weergegeven op het scherm door
 * de co-ordinaten van het punt, zonder bijbehorende naam (letter). Het bericht
 * naar System.out bevat wel altijd alle informatie.<BR>
 * 
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version DemoZ.java v1.0 --- (08-05-2002)
 */
public class DemoZ extends DemoPanel {

    /** Default constructor; initialiseert het DemoPanel en registreert de
     * MouseListener voor het verkrijgen van de 3 hoekpunten
     */
    public DemoZ() {
        super() ;
    }


    /** toString methode om een beschrijving van de klasse te kunnen geven
     * @return description - Beschrijving van de demonstratie als String
     */
    public String toString() {
        return ("DemoZ (zwaartepunt en zwaartelijnen)") ;
    }


    /** paintComponent tekent de beschikbare informatie (lijnen en punten) van
     *  de driehoek naar het scherm
     */
    public void paintComponent(Graphics g) {
        // Teken alles dat we al kunnen tekenen
        super.paintComponent(g) ;

        if(counter == 3) {
            // Driehoek ingevoerd; bereken de punten Z, A', B' en C'
            TriangleZ t = new TriangleZ(p[0], p[1], p[2]) ;
            Point ac = t.getLineA().cutsWith(new Line(t.getA(), t.getZ())) ;
            Point bc = t.getLineB().cutsWith(new Line(t.getB(), t.getZ())) ;
            Point cc = t.getLineC().cutsWith(new Line(t.getC(), t.getZ())) ;

            // Teken de lijnen AA', BB' en CC'
            g.setColor(Color.magenta) ;
            g.drawLine(ax, ay, (int)ac.getX(), (int)ac.getY()) ;
            g.drawLine(bx, by, (int)bc.getX(), (int)bc.getY()) ;
            g.drawLine(cx, cy, (int)cc.getX(), (int)cc.getY()) ;

            // Teken de punten A', B' en C'
            g.drawOval((int)Math.round(ac.getX()) - POINT_RADIUS,
                       (int)Math.round(ac.getY()) - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)Math.round(bc.getX()) - POINT_RADIUS,
                       (int)Math.round(bc.getY()) - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)Math.round(cc.getX()) - POINT_RADIUS,
                       (int)Math.round(cc.getY()) - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;

            // En teken tenslotte het punt Z met label
            int x = (int)Math.round(t.getZ().getX()) - POINT_RADIUS ;
            int y = (int)Math.round(t.getZ().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            Point z = t.getZ() ; z.setID("Z") ;
            g.drawString("[" +Math.round(z.getX())+
                         "," +Math.round(z.getY())+ "]",
                         (int)Math.round(z.getX() + 10),
                         (int)Math.round(z.getY() + 20)) ;

            // Schrijf het nieuwe resultaat naar System.out
            if(!b) {
                System.out.println("Extra punt berekend: " +t.getZ()) ;
                b = true ;
            }
        }
    }
}