//public class DemoPanel : JPanel {

//    // Teller van het aantal reeds ingevoerde hoekpunten
//    protected int counter = 0 ;
//    // Reeks die de ingevoerde Point objecten bevat
//    protected Point[] p ;
//    // De straal waarmee ieder Point wordt getekend (grafisch tekenen we een
//    // Point als een cirkel om deze beter zichtbaar te laten zijn
//    protected final static int POINT_RADIUS = 3 ;
//    // Variabele of het extra al is geprint naar System.out    
//    protected boolean b = false ;
//    // De co-ordinaten van de punten A, B en C
//    protected int ax, ay, bx, by, cx, cy ;


//    /** Default constructor; initialiseert het DemoPanel en registreert de
//     *  MouseListener voor het verkrijgen van de 3 hoekpunten
//     */
//    public DemoPanel() {
//        p = new Point[3] ;
//        this.addMouseListener(this) ;
//        this.addMouseMotionListener(this) ;
//    }


//    public void clear() {
//        this.counter = 0 ;
//        this.b = false ;
//        this.p = new Point[3] ;
//    }


//    public override string ToString() {
//        return "DemoPanel (eenvoudige driehoeken)" ;
//    }


//    /** getTitle geeft de titel van de demonstratie terug
//     * @return title - De titel van de demonstratie
//     */
//    public string getTitle() {
//        StringTokenizer st = new StringTokenizer(this.toString(), "(") ;
//        return st.nextToken() ;
//    }


//    /** paintComponent tekent de reeds ingevoerde hoekpunten en de bijbehorende
//     *  lijnen naar het scherm
//     */
//    public void paintComponent(Graphics g) {
//        super.paintComponent(g) ;

//        // Counter wordt niet opgehoogd door mouseMoved waardoor de
//        // onderstaande for loop dit punt niet zal tekenen nadat punt A is
//        // ingevoerd; hier tekenen we hem alsnog
//        if((counter == 1) && (p[1] != null)) {
//            int x = (int)Math.round(p[1].getX()) - POINT_RADIUS ;
//            int y = (int)Math.round(p[1].getY()) - POINT_RADIUS;
//            g.drawOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
//            g.drawString(p[1].toString(), (int)Math.round(p[1].getX() + 10),
//                                          (int)Math.round(p[1].getY() + 20)) ;
//        }

//        // Teken de beschikbare punten
//        for(int i = 0; i < counter; i++) {
//            int x = (int)Math.round(p[i].getX()) - POINT_RADIUS ;
//            int y = (int)Math.round(p[i].getY()) - POINT_RADIUS;
//            g.drawOval(x, y, 2*POINT_RADIUS, 2*POINT_RADIUS) ;
//            g.drawString(p[i].toString(), (int)Math.round(p[i].getX() + 10),
//                                          (int)Math.round(p[i].getY() + 20)) ;
//        }

//        // Als alle drie de punten zijn ingevoerd kunnen de lijnen worden
//        // getekend tussen deze punten
//        if(counter == 3) {
//            ax = (int)Math.round(p[0].getX()) ;
//            ay = (int)Math.round(p[0].getY()) ;
//            bx = (int)Math.round(p[1].getX()) ;
//            by = (int)Math.round(p[1].getY()) ;
//            cx = (int)Math.round(p[2].getX()) ;
//            cy = (int)Math.round(p[2].getY()) ;
//            g.setColor(Color.black) ;
//            g.drawLine(ax, ay, bx, by) ;
//            g.drawLine(bx, by, cx, cy) ;
//            g.drawLine(cx, cy, ax, ay) ;
//        }
//    }


//    /** mouseClicked; uit de interface MouseListener. Slaat, zolang er nog geen
//     *  3 punten zijn ingevoerd de positie waarop is geklikt op als nieuw
//     *  hoekpunt van de Triangle in de array p
//     */
//    public void mouseClicked(MouseEvent e) {
//        // Controle of er al drie punten zijn ingevoerd
//        if(counter == 0) {
//            int x = e.getX() ;
//            int y = e.getY() ;
//            // Sla het nieuwe punt op
//            p[counter] = new Point(x, y) ;
//            p[counter].setID("" + (char)('A' +counter++)) ;
//        }
//        this.repaint() ;
//    }


//    /** mouseMove; uit de interface MouseMotionListener. Wanneer het punt A is
//     *  opgeslagen slaat deze methode de nieuwe positie het punt B op, totdat
//     *  dit punt wordt vastgezet
//     */
//    public void mouseMoved(MouseEvent e) {
//        if(counter == 1) {
//            int x = e.getX() ;
//            int y = e.getY() ;
//            // Sla het nieuwe punt op
//            p[1] = new Point(x, y) ;
//            p[1].setID("" + (char)('B')) ;
//        }
//        this.repaint() ;
//    }


//    /** mousPressed; uit de inteface MouseListener. Zet het punt B vast mits
//     *  punt A is ingevoerd op de muis waarop werd gedrukt en slaat het punt
//     *  op
//     */
//    public void mousePressed(MouseEvent e) {
//        if(counter == 1) {
//            int x = e.getX() ;
//            int y = e.getY() ;
//            // Sla het nieuwe punt op
//            p[counter] = new Point(x, y) ;
//            p[counter].setID("" + (char)('A' +counter++)) ;
//        }
//        this.repaint() ;
//    }


//    /** mouseMove; uit de interface MouseMotionListener. Slaat het punt C op
//     *  wanneer deze nog niet was getekend
//     */
//    public void mouseDragged(MouseEvent e) {
//        if(counter >= 2) {
//            int x = e.getX() ;
//            int y = e.getY() ;
//            // Sla het nieuwe punt op
//            p[2] = new Point(x, y) ;
//            p[2].setID("" + (char)('C')) ;
//            if(counter == 2) {counter++;}
//        }
//        repaint() ;
//    }


//    /** Ongebruikte methode */
//    public void mouseReleased(MouseEvent e) {;}
//    /** Ongebruikte methode */
//    public void mouseEntered(MouseEvent e) {;}
//    /** Ongebruikte methode */
//    public void mouseExited(MouseEvent e) {;}

//}