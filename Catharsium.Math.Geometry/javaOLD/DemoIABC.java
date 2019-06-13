import javax.swing.* ;
import java.awt.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>DemoIABC.java</B><BR>
 * DemoIABC is een demonstratie van het IABC probleem; naast de driehoek die de
 * gebruiker invoert door op 3 punten te klikken (zie documentatie bij
 * DemoPanel), worden ook de buitnenhoekdeellijnen, de aangeschreven cirkels,
 * de ingeschreven cirkel en de hulp-lijnen zoals AIA, BIB en CIC naar het
 * scherm getekend. De middelpunten van de cirkels dat wordt uitgerekend door
 * de klasse TriangleIABC zullen daarnaast expliciet worden aangegeven met hun
 * naam.<BR><BR>
 *
 * Wanneer nieuwe hoekpunten door de gebruiker worden toegevoegd zal dit naast
 * het onmiddelijk naar het scherm tekenen ervan, ook duidelijk worden gemaakt
 * met een bericht naar System.out. Wanneer de drie hoekpunten zijn ingevoerd
 * zal hier ook een bevestiging dat de cirkels I, IA, IB en IC zijn berekend
 * naar toe gaan.<BR><BR>
 *
 * NB: Het labels van de extra punten worden in deze demo weergegeven op het
 * scherm door de namen van de punten, zonder bijbehorende co-ordinaten. Het
 * bericht naar System.out bevat wel altijd alle informatie.<BR>
 * 
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version DemoIABC.java v1.0 --- (08-05-2002)
 */
public class DemoIABC extends DemoPanel {

    /** Default constructor; initialiseert het DemoPanel en registreert de
     * MouseListener voor het verkrijgen van de 3 hoekpunten
     */
    public DemoIABC() {
        super() ;
    }


    /** toString methode om een beschrijving van de klasse te kunnen geven
     * @return description - Beschrijving van de demonstratie als String
     */
    public String toString() {
        return ("DemoIABC (buitenhoekdeellijnen en aangeschreven cirkels)") ;
    }


    /** paintComponent tekent de beschikbare informatie (lijnen en punten) van
     *  de driehoek naar het scherm
     */
    public void paintComponent(Graphics g) {
        // Teken alles dat we al kunnen tekenen
        super.paintComponent(g) ;

        if(counter == 3) {
            TriangleIABC t = new TriangleIABC(p[0], p[1], p[2]) ;
            double dx, dy ;
            Line ll ;

            // Trek de lijnen a,b en c door:
            // Voor grotere flexibiliteit ga ik uit van tweemaal de grootte van
            // de diameter het venster en niet een statische variabele. We
            // nemen twee punten op de lijn a dat precies bovenstaand getal
            // maal van het punt B en het punt C vandaan ligt.
            g.setColor(Color.darkGray) ;
            double width = this.getSize().getWidth() ;
            double height = this.getSize().getHeight() ;
            double dist = 2 * Math.sqrt(((width * width) + (height* height))) ;
            dx = t.getLineA().toVector().getQ().getX() * dist ;
            dy = t.getLineA().toVector().getQ().getY() * dist ;
            ll = new Line(bx, by, (int)(bx - dx), (int)(by - dy)) ;
            ll.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)ll.getP().getX(), (int)ll.getP().getY(),
                       (int)ll.getQ().getX(), (int)ll.getQ().getY()) ;
            ll = new Line(cx, cy, (int)(cx + dx), (int)(cy + dy)) ;
            ll.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)ll.getP().getX(), (int)ll.getP().getY(),
                       (int)ll.getQ().getX(), (int)ll.getQ().getY()) ;
          //g.drawLine(bx, by, (int)(bx - dx), (int)(by - dy)) ;//Werkt alleen
          //g.drawLine(cx, cy, (int)(cx + dx), (int)(cy + dy)) ;//met Java1.4.0

            dx = t.getLineB().toVector().getQ().getX() * dist ;
            dy = t.getLineB().toVector().getQ().getY() * dist ;
            ll = new Line(ax, ay, (int)(ax - dx), (int)(ay - dy)) ;
            ll.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)ll.getP().getX(), (int)ll.getP().getY(),
                       (int)ll.getQ().getX(), (int)ll.getQ().getY()) ;
            ll = new Line(cx, cy, (int)(cx + dx), (int)(cy + dy)) ;
            ll.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)ll.getP().getX(), (int)ll.getP().getY(),
                       (int)ll.getQ().getX(), (int)ll.getQ().getY()) ;
          //g.drawLine(ax, ay, (int)(ax - dx), (int)(ay - dy)) ;//Werkt alleen
          //g.drawLine(cx, cy, (int)(cx + dx), (int)(cy + dy)) ;//met Java1.4.0

            dx = t.getLineC().toVector().getQ().getX() * dist ;
            dy = t.getLineC().toVector().getQ().getY() * dist ;
            ll = new Line(ax, ay, (int)(ax - dx), (int)(ay - dy)) ;
            ll.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)ll.getP().getX(), (int)ll.getP().getY(),
                       (int)ll.getQ().getX(), (int)ll.getQ().getY()) ;
            ll = new Line(bx, by, (int)(bx + dx), (int)(by + dy)) ;
            ll.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)ll.getP().getX(), (int)ll.getP().getY(),
                       (int)ll.getQ().getX(), (int)ll.getQ().getY()) ;
          //g.drawLine(ax, ay, (int)(ax - dx), (int)(ay - dy)) ;//Werkt alleen
          //g.drawLine(bx, by, (int)(bx + dx), (int)(by + dy)) ;//met Java1.4.0

            // Driehoek ingevoerd; bereken de noodzakelijke punten en lijnen
            Point dir ;
            Circle i = t.getI() ; i.getP().setID("I") ;
            Circle k = t.getK() ; k.getP().setID("IA") ;
            Circle l = t.getL() ; l.getP().setID("IB") ;
            Circle m = t.getM() ; m.getP().setID("IC") ;
            Point ac = t.getLineA().cutsWith(new Line(t.getA(), i.getP())) ;
            Point bc = t.getLineB().cutsWith(new Line(t.getB(), i.getP())) ;
            Point cc = t.getLineC().cutsWith(new Line(t.getC(), i.getP())) ;

            Line la = new Line(i.getP(), t.getA()) ;
            Line lb = new Line(i.getP(), t.getB()) ;
            Line lc = new Line(i.getP(), t.getC()) ;
            dir = la.toVector().getQ() ;
            la = new Line(t.getA(), new Point(-dir.getY() + t.getA().getX(),
                                               dir.getX() + t.getA().getY())) ;
            la.normalize(this.getWidth(), this.getHeight()) ;
            dir = lb.toVector().getQ() ;
            lb = new Line(t.getB(), new Point(-dir.getY() + t.getB().getX(),
                                               dir.getX() + t.getB().getY())) ;
            lb.normalize(this.getWidth(), this.getHeight()) ;
            dir = lc.toVector().getQ() ;
            lc = new Line(t.getC(), new Point(-dir.getY() + t.getC().getX(),
                                               dir.getX() + t.getC().getY())) ;
            lc.normalize(this.getWidth(), this.getHeight()) ;

            // Een voor mij nog onbekende bug in Java 1.3.1 resulteert in het
            // vastlopen van het programma wanneer met deze java versie het
            // derde punt tussen beide anderen wordt doorgesleept. Het
            // normaliseren van onderstaande lijnen verergert dit probleem.
            // Onder Java 1.4.0 werkt het programma perfect, op welke pc's ook.

            // Teken de lijnen AIA, BIB en CIC
            g.setColor(Color.yellow) ;
            g.drawLine((int)Math.round(t.getA().getX()),
                       (int)Math.round(t.getA().getY()),
                       (int)Math.round(k.getP().getX()),
                       (int)Math.round(k.getP().getY())) ;
            g.drawLine((int)Math.round(t.getB().getX()),
                       (int)Math.round(t.getB().getY()),
                       (int)Math.round(l.getP().getX()),
                       (int)Math.round(l.getP().getY())) ;
            g.drawLine((int)Math.round(t.getC().getX()),
                       (int)Math.round(t.getC().getY()),
                       (int)Math.round(m.getP().getX()),
                       (int)Math.round(m.getP().getY())) ;

            // Teken de lijnen IAIB, IBIC en ICIA
            g.setColor(Color.blue) ;
            g.drawLine((int)Math.round(k.getP().getX()),
                       (int)Math.round(k.getP().getY()),
                       (int)Math.round(l.getP().getX()),
                       (int)Math.round(l.getP().getY())) ;
            g.drawLine((int)Math.round(l.getP().getX()),
                       (int)Math.round(l.getP().getY()),
                       (int)Math.round(m.getP().getX()),
                       (int)Math.round(m.getP().getY())) ;
            g.drawLine((int)Math.round(m.getP().getX()),
                       (int)Math.round(m.getP().getY()),
                       (int)Math.round(k.getP().getX()),
                       (int)Math.round(k.getP().getY())) ;

            // Teken de middelpunten van IA, IB en IC
            g.setColor(Color.red) ;
            int r = POINT_RADIUS ;
            g.drawOval((int)Math.round(k.getP().getX()) - r,
                       (int)Math.round(k.getP().getY()) - r,
                       2*r, 2*r) ;
            g.drawOval((int)Math.round(l.getP().getX()) - r,
                       (int)Math.round(l.getP().getY()) - r,
                       2*r, 2*r) ;
            g.drawOval((int)Math.round(m.getP().getX()) - r,
                       (int)Math.round(m.getP().getY()) - r,
                       2*r, 2*r) ;

            // Teken de cirkels IA, IB en IC
            r = (int)Math.round(k.getR()) ;
            g.setColor(Color.red) ;
            g.drawOval((int)Math.round(k.getP().getX()) - r,
                       (int)Math.round(k.getP().getY()) - r,
                       2*r, 2*r) ;
            g.setColor(Color.black) ;
            g.drawString("IA", (int)Math.round(k.getP().getX() + 10),
                               (int)Math.round(k.getP().getY() + 20)) ;
            r = (int)Math.round(l.getR()) ;
            g.setColor(Color.red) ;
            g.drawOval((int)Math.round(l.getP().getX()) - r,
                       (int)Math.round(l.getP().getY()) - r,
                       2*r, 2*r) ;
            g.setColor(Color.black) ;
            g.drawString("IB", (int)Math.round(l.getP().getX() + 10),
                               (int)Math.round(l.getP().getY() + 20)) ;
            r = (int)Math.round(m.getR()) ;
            g.setColor(Color.red) ;
            g.drawOval((int)Math.round(m.getP().getX()) - r,
                       (int)Math.round(m.getP().getY()) - r,
                       2*r, 2*r) ;
            g.setColor(Color.black) ;
            g.drawString("IC", (int)Math.round(m.getP().getX() + 10),
                               (int)Math.round(m.getP().getY() + 20)) ;


            // En teken tenslotte de cirkel I
            g.setColor(new Color(255, 70, 0)) ;
            int x = (int)Math.round(i.getP().getX()) - POINT_RADIUS ;
            int y = (int)Math.round(i.getP().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.setColor(Color.black) ;
            g.drawString("I", (int)Math.round(i.getP().getX() + 10),
                         (int)Math.round(i.getP().getY() + 20)) ;
            r = (int)Math.round(i.getR()) ;
            g.setColor(new Color(255, 70, 0)) ;
            g.drawOval((int)Math.round(i.getP().getX()) - r,
                       (int)Math.round(i.getP().getY()) - r, 2*r, 2*r) ;

            // Schrijf het nieuwe resultaat naar System.out
            if(!b) {
                System.out.println("Extra cirkels berekend: " +
                                    i+ ", " +k+ ", " +l+ ", " +m) ;
                b = true ;
            }
        }
    }
}