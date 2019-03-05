import javax.swing.* ;
import java.awt.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>DemoEF.java</B><BR>
 * Deze demonstratie tekent naast de hoogtelijnen, zwaartelijnen en
 * middelloodlijnen samen met de omgeschreven cirkel, de lijn van Euler en de
 * cirkel van Feuerbach nadat 3 punten zijn ingevoerd. Het tekenen van de
 * driehoek zelf gebeurt door de superklasse DemoPanel, de overige lijnen
 * worden in deze klasse afgehandeld. Tot slot worden in deze klasse ook alle
 * bijzondere snijpunten met de cirkel van Feuerbach zichtbaar gemaakt en zijn
 * alle lijnen herkenbaar door hun eigen kleur zoals in de opdracht stond
 * aangegeven.
 * 
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version DemoEF.java v1.0 --- (18-05-2002)
 */
public class DemoEF extends DemoPanel {

    /** Default constructor; initialiseert het DemoPanel en registreert de
     * MouseListener voor het verkrijgen van de 3 hoekpunten
     */
    public DemoEF() {
        super() ;
    }


    /** toString methode om een beschrijving van de klasse te kunnen geven
     * @return description - Beschrijving van de demonstratie als String
     */
    public String toString() {
        return ("DemoEF (lijn van Euler & cirkel van Feuerbach)") ;
    }


    /** paintComponent tekent de beschikbare informatie (lijnen en punten) van
     *  de driehoek naar het scherm
     */
    public void paintComponent(Graphics g) {
        super.paintComponent(g) ;

        if(counter == 3) {
            // Driehoek ingevoerd; bereken de punten Z, A', B' en C'
            TriangleZ tz = new TriangleZ(p[0], p[1], p[2]) ;
            Point ac = tz.getLineA().cutsWith(new Line(tz.getA(), tz.getZ())) ;
            Point bc = tz.getLineB().cutsWith(new Line(tz.getB(), tz.getZ())) ;
            Point cc = tz.getLineC().cutsWith(new Line(tz.getC(), tz.getZ())) ;

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
            int x = (int)Math.round(tz.getZ().getX()) - POINT_RADIUS ;
            int y = (int)Math.round(tz.getZ().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            Point z = tz.getZ() ; z.setID("Z") ;
            g.drawString("Z", (int)Math.round(z.getX() + 10),
                              (int)Math.round(z.getY() + 20)) ;

            // Driehoek ingevoerd; bereken de punten H, A', B' en C'
            TriangleH t = new TriangleH(p[0], p[1], p[2]) ;
            ac = t.getLineA().cutsWith(new Line(t.getA(), t.getH())) ;
            bc = t.getLineB().cutsWith(new Line(t.getB(), t.getH())) ;
            cc = t.getLineC().cutsWith(new Line(t.getC(), t.getH())) ;

            // Trek de lijnen a, b en c door wanneer dat nodig is
            g.setColor(Color.darkGray) ;
            double dta, dtb, dtc ;
            Point p, q ;

            // De hulplijn tot A':
            // We willen niet over de driehoek zelf gaan tekenen dus zoek uit
            // vanuit welk punt (B of C) we moeten beginnen tot ac; ofwel,
            // welke lengte BA' of CA' is het kleinst
            dtb = ac.distanceTo(t.getB()) ;
            dtc = ac.distanceTo(t.getC()) ;
            p = (dtb < dtc) ? t.getB() : t.getC() ;
            // Alleen als de afstand van A' tot B + de afstand van A' tot C
            // groter is dan de lengte moeten we een hulp lijn tekenen, anders
            // ligt A' tussen B en C in
            if((dtb + dtc) > t.getB().distanceTo(t.getC())) {
                g.drawLine((int)ac.getX(), (int)ac.getY(),
                           (int)p.getX(), (int)p.getY()) ;
            }

            // Hulplijn tot B', zie uitleg bij A'
            dta = bc.distanceTo(t.getA()) ;
            dtc = bc.distanceTo(t.getC()) ;
            p = (dta < dtc) ? t.getA() : t.getC() ;
            if((dta + dtc) > t.getA().distanceTo(t.getC())) {
                g.drawLine((int)bc.getX(), (int)bc.getY(),
                           (int)p.getX(), (int)p.getY()) ;
            }

            // Hulplijn tot C', zie uitleg bij A'
            dta = cc.distanceTo(t.getA()) ;
            dtb = cc.distanceTo(t.getB()) ;
            p = (dta < dtb) ? t.getA() : t.getB() ;
            if((dta + dtb) > t.getA().distanceTo(t.getB())) {
                g.drawLine((int)cc.getX(), (int)cc.getY(),
                           (int)p.getX(), (int)p.getY()) ;
            }

            // Teken de lijn AHA'; de volgorde van de punten op de lijn kan
            // verschillen dus ik controleer alle mogelijke gevallen en vind
            // de twee eindpunten van de lijn
            g.setColor(Color.green) ;
            if(t.getA().distanceTo(ac) > t.getA().distanceTo(t.getH())) {
                if(t.getA().distanceTo(ac) > ac.distanceTo(t.getH())) {
                    p = t.getA() ; q = ac ;
                }
                else {p = ac ; q = t.getH() ;}
            }
            else {
                if(t.getA().distanceTo(t.getH()) > ac.distanceTo(t.getH())) {
                    p = t.getA() ; q = t.getH() ;
                }
                else {p = ac ; q = t.getH() ;}
            }
            Line aha = new Line(p, q) ;
            aha.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)aha.getP().getX(), (int)aha.getP().getY(),
                       (int)aha.getQ().getX(), (int)aha.getQ().getY()) ;

            // Teken de lijn BHB'; de volgorde van de punten op de lijn kan
            // verschillen dus ik controleer alle mogelijke gevallen en vind
            // de twee eindpunten van de lijn
            if(t.getB().distanceTo(bc) > t.getB().distanceTo(t.getH())) {
                if(t.getB().distanceTo(bc) > bc.distanceTo(t.getH())) {
                    p = t.getB() ; q = bc ;
                }
                else {p = bc ; q = t.getH() ;}
            }
            else {
                if(t.getB().distanceTo(t.getH()) > bc.distanceTo(t.getH())) {
                    p = t.getB() ; q = t.getH() ;
                }
                else {p = bc ; q = t.getH() ;}
            }
            Line bhb = new Line(p, q) ;
            bhb.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)bhb.getP().getX(), (int)bhb.getP().getY(),
                       (int)bhb.getQ().getX(), (int)bhb.getQ().getY()) ;

            // Teken de lijn CHC'; de volgorde van de punten op de lijn kan
            // verschillen dus ik controleer alle mogelijke gevallen en vind
            // de twee eindpunten van de lijn
            if(t.getC().distanceTo(cc) > t.getC().distanceTo(t.getH())) {
                if(t.getC().distanceTo(cc) > cc.distanceTo(t.getH())) {
                    p = t.getC() ; q = cc ;
                }
                else {p = cc ; q = t.getH() ;}
            }
            else {
                if(t.getC().distanceTo(t.getH()) > cc.distanceTo(t.getH())) {
                    p = t.getC() ; q = t.getH() ;
                }
                else {p = cc ; q = t.getH() ;}
            }
            Line chc = new Line(p, q) ;
            chc.normalize(this.getWidth(), this.getHeight()) ;
            g.drawLine((int)chc.getP().getX(), (int)chc.getP().getY(),
                       (int)chc.getQ().getX(), (int)chc.getQ().getY()) ;

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

            // En teken tenslotte het punt H met label
            x = (int)Math.round(t.getH().getX()) - POINT_RADIUS ;
            y = (int)Math.round(t.getH().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            Point h = t.getH() ; h.setID("H") ;
            g.drawString("H", (int)Math.round(t.getH().getX() + 10),
                              (int)Math.round(t.getH().getY() + 20)) ;

            // Driehoek ingevoerd; bereken de punten M, A', B' en C'
            TriangleM tm = new TriangleM(this.p[0], this.p[1], this.p[2]) ;
            Point m = tm.getM() ; m.setID("M") ;
            ac = tm.getLineA().cutsWith(new Line(tm.getA(), tm.getM())) ;
            bc = tm.getLineB().cutsWith(new Line(tm.getB(), tm.getM())) ;
            cc = tm.getLineC().cutsWith(new Line(tm.getC(), tm.getM())) ;

            // Teken de lijnen MA', MB' en MC'
            g.setColor(Color.green) ;
            g.drawLine((int)Math.round(m.getX()), (int)Math.round(m.getY()),
                       (int)Math.round(tm.getLineA().getPoint(1,1).getX()),
                       (int)Math.round(tm.getLineA().getPoint(1,1).getY())) ;
            g.drawLine((int)Math.round(m.getX()), (int)Math.round(m.getY()),
                       (int)Math.round(tm.getLineB().getPoint(1,1).getX()),
                       (int)Math.round(tm.getLineB().getPoint(1,1).getY())) ;
            g.drawLine((int)Math.round(m.getX()), (int)Math.round(m.getY()),
                       (int)Math.round(tm.getLineC().getPoint(1,1).getX()),
                       (int)Math.round(tm.getLineC().getPoint(1,1).getY())) ;

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
            g.drawOval((int)Math.round(tm.getLineA().getPoint(1,1).getX())
                                       - POINT_RADIUS,
                       (int)Math.round(tm.getLineA().getPoint(1,1).getY())
                                       - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)Math.round(tm.getLineB().getPoint(1,1).getX())
                                       - POINT_RADIUS,
                       (int)Math.round(tm.getLineB().getPoint(1,1).getY())
                                       - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)Math.round(tm.getLineC().getPoint(1,1).getX())
                                       - POINT_RADIUS,
                       (int)Math.round(tm.getLineC().getPoint(1,1).getY())
                                       - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;

            // En teken tenslotte de cirkel M met label
            g.setColor(Color.blue) ;
            x = (int)Math.round(tm.getM().getX()) - POINT_RADIUS ;
            y = (int)Math.round(tm.getM().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawString("M", (int)Math.round(m.getX() + 10),
                              (int)Math.round(m.getY() + 20)) ;
            int r = (int)Math.round(m.distanceTo(t.getA())) ;
            g.drawOval((int)Math.round(m.getX()) - r,
                       (int)Math.round(m.getY()) - r, 2*r, 2*r) ;

            // Teken de lijn van Euler en de cirkel van 
            Line euler = new Line(h, m) ;
            g.setColor(new Color(225,0,0)) ;
            g.drawLine((int)h.getX(), (int)h.getY(),
                       (int)m.getX(), (int)m.getY()) ;

            Point middle = euler.getPoint(1,1) ;
            g.drawOval((int)Math.round(middle.getX()) - POINT_RADIUS,
                       (int)Math.round(middle.getY()) - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawString("N", (int)middle.getX() + 10,
                              (int)middle.getY() + 20) ;
            r /= 2 ;  // r was al de straal van M
            Circle feuerbach = new Circle(middle, r) ;
            g.drawOval((int)Math.round(middle.getX()) - r,
                       (int)Math.round(middle.getY()) - r, 2*r, 2*r) ;

            // Teken de resterende snijpunten
            Line e1 = new Line(h, new Point(ax, ay)) ;
            Line e2 = new Line(h, new Point(bx, by)) ;
            Line e3 = new Line(h, new Point(cx, cy)) ;
            g.setColor(Color.green) ;
            g.drawOval((int)e1.getPoint(1,1).getX() - POINT_RADIUS,
                       (int)e1.getPoint(1,1).getY() - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)e2.getPoint(1,1).getX() - POINT_RADIUS,
                       (int)e2.getPoint(1,1).getY() - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
            g.drawOval((int)e3.getPoint(1,1).getX() - POINT_RADIUS,
                       (int)e3.getPoint(1,1).getY() - POINT_RADIUS,
                       2*POINT_RADIUS, 2*POINT_RADIUS) ;
        }
    }

}