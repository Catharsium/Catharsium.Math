import javax.swing.* ;
import java.awt.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>DemoH.java</B><BR>
 * DemoH is een demonstratie van het H probleem; naast de driehoek die de
 * gebruiker invoert door op 3 punten te klikken (zie documentatie bij
 * DemoPanel), worden ook de hoogtelijnen met hulp-punten A', B' en C' naar
 * het scherm getekend. Het hoogtepunt dat wordt uitgerekend door de klasse
 * TriangleH zal daarnaast expliciet worden aangegeven met zijn
 * co-ordinaten.<BR><BR>
 *
 * Wanneer nieuwe hoekpunten door de gebruiker worden toegevoegd zal dit naast
 * het onmiddelijk naar het scherm tekenen ervan, ook duidelijk worden gemaakt
 * met een bericht naar System.out. Wanneer de drie hoekpunten zijn ingevoerd
 * zal hier ook een bevestiging dat het H punt is berekend naar toe
 * gaan.<BR><BR>
 *
 * NB: Het label van het extra punt wordt altijd weergegeven op het scherm door
 * de co-ordinaten van het punt, zonder bijbehorende naam (letter). Het bericht
 * naar System.out bevat wel altijd alle informatie.<BR>
 * 
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version DemoH.java v1.0 --- (08-05-2002)
 */
public class DemoH extends DemoPanel {

    /** Default constructor; initialiseert het DemoPanel en registreert de
     *  MouseListener voor het verkrijgen van de 3 hoekpunten
     */
    public DemoH() {
        super() ;
    }


    /** toString methode om een beschrijving van de klasse te kunnen geven
     * @return description - Beschrijving van de demonstratie als String
     */
    public String toString() {
        return ("DemoH (hoogtepunt en hoogtelijnen)") ;
    }


    /** paintComponent tekent de beschikbare informatie (lijnen en punten) van
     *  de driehoek naar het scherm
     */
    public void paintComponent(Graphics g) {
        // Teken alles dat we al kunnen tekenen
        super.paintComponent(g) ;
        if(counter == 3) {
            // Driehoek ingevoerd; bereken de punten H, A', B' en C'
            TriangleH t = new TriangleH(p[0], p[1], p[2]) ;
            Point ac = t.getLineA().cutsWith(new Line(t.getA(), t.getH())) ;
            Point bc = t.getLineB().cutsWith(new Line(t.getB(), t.getH())) ;
            Point cc = t.getLineC().cutsWith(new Line(t.getC(), t.getH())) ;

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
            int x = (int)Math.round(t.getH().getX()) - POINT_RADIUS ;
            int y = (int)Math.round(t.getH().getY()) - POINT_RADIUS;
            g.fillOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
            Point h = t.getH() ; h.setID("H") ;
            g.drawString("[" +Math.round(h.getX())+
                         "," +Math.round(h.getY())+ "]",
                         (int)Math.round(t.getH().getX() + 10),
                         (int)Math.round(t.getH().getY() + 20)) ;

            // Schrijf het nieuwe resultaat naar System.out
            if(!b) {
                System.out.println("Extra punt berekend: " +t.getH()) ;
                b = true ;
            }
        }
    }
}