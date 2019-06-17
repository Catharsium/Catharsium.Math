import javax.swing.* ;
import java.awt.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>DemoI.java</B><BR>
 * DemoI is een demonstratie van het I probleem; naast de driehoek die de
 * gebruiker invoert door op 3 punten te klikken (zie documentatie bij
 * DemoPanel), worden ook de binnenhoekdeellijnen, de ingeschreven cirkel en de
 * hulp-punten A', B' en C' naar het scherm getekend. Het middelpunt van de
 * ingeschreven cirkel dat wordt uitgerekend door de klasse TriangleI zal
 * daarnaast expliciet worden aangegeven met zijn co-ordinaten.<BR><BR>
 *
 * Wanneer nieuwe hoekpunten door de gebruiker worden toegevoegd zal dit naast
 * het onmiddelijk naar het scherm tekenen ervan, ook duidelijk worden gemaakt
 * met een bericht naar System.out. Wanneer de drie hoekpunten zijn ingevoerd
 * zal hier ook een bevestiging dat het I punt is berekend naar toe
 * gaan.<BR><BR>
 *
 * NB: Het label van het extra punt wordt altijd weergegeven op het scherm door
 * de co-ordinaten van het punt, zonder bijbehorende naam (letter). Het bericht
 * naar System.out bevat wel altijd alle informatie.<BR>
 * 
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version DemoI.java v1.0 --- (08-05-2002)
 */
public class DemoI extends DemoPanel {

    /** Default constructor; initialiseert het DemoPanel en registreert de
     * MouseListener voor het verkrijgen van de 3 hoekpunten
     */
    public DemoI() {
        super() ;
    }


    /** toString methode om een beschrijving van de klasse te kunnen geven
     * @return description - Beschrijving van de demonstratie als String
     */
    public String toString() {
        return ("DemoI (binnenhoekdeellijnen en ingeschreven cirkel)") ;
    }


    /** paintComponent tekent de beschikbare informatie (lijnen en punten) van
     *  de driehoek naar het scherm
     */
    public void paintComponent(Graphics g) {
        // Teken alles dat we al kunnen tekenen
        super.paintComponent(g) ;

        if(counter == 3) {
            // Driehoek ingevoerd; bereken de punten I, A', B' en C'
            TriangleI t = new TriangleI(p[0], p[1], p[2]) ;
            Circle i = t.getI() ; i.getP().setID("I") ;
            Point ac = t.getLineA().cutsWith(new Line(t.getA(), i.getP())) ;
            Point bc = t.getLineB().cutsWith(new Line(t.getB(), i.getP())) ;
            Point cc = t.getLineC().cutsWith(new Line(t.getC(), i.getP())) ;

            // Teken de lijnen IA, IB en IC
            g.setColor(Color.yellow) ;
            g.drawLine((int)Math.round(i.getP().getX()),
                       (int)Math.round(i.getP().getY()),
                       (int)Math.round(t.getA().getX()),
                       (int)Math.round(t.getA().getY())) ;
            g.drawLine((int)Math.round(i.getP().getX()),
                       (int)Math.round(i.getP().getY()),
                       (int)Math.round(t.getB().getX()),
                       (int)Math.round(t.getB().getY())) ;
            g.drawLine((int)Math.round(i.getP().getX()),
                       (int)Math.round(i.getP().getY()),
                       (int)Math.round(t.getC().getX()),
                       (int)Math.round(t.getC().getY())) ;
            
            // En teken tenslotte de cirkel I met label
            g.setColor(Color.yellow) ;
            int x = (int)Math.round(i.getP().getX()) - POINT_RADIUS ;
            int y = (int)Math.round(i.getP().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawString("[" +Math.round(i.getP().getX())+
                         "," +Math.round(i.getP().getY())+ "]",
                         (int)Math.round(i.getP().getX() + 10),
                         (int)Math.round(i.getP().getY() + 20)) ;
            int r = (int)Math.round(i.getR()) ;
            g.drawOval((int)Math.round(i.getP().getX()) - r,
                       (int)Math.round(i.getP().getY()) - r, 2*r, 2*r) ;
            

            // Schrijf het nieuwe resultaat naar System.out
            if(!b) {
                Circle c = new Circle(i) ; c.getP().setID("I") ;
                System.out.println("Extra punt & straal berekend: " +c) ;
                b = true ;
            }
        }
    }
}