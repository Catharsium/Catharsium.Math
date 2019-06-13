import javax.swing.* ;
import java.awt.* ;
import java.awt.event.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>CenteredFrame.java</B><BR>
 * CenteredFrame is een programma dat een JFrame voorstelt, met als uitbreiding
 * dat het venster bij openen automatisch gecentreerd op het scherm wordt.
 * Daarnaast wordt een WindowAdapter toegevoegd zodat het venster kan worden
 * afgesloten; het sluiten van het venster resulteert tevens in het stopppen
 * van het gehele programma!<BR>
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version CenteredFrame.java v1.0 --- (08-05-2002)
 */
public class CenteredFrame extends JFrame {

    /** Contructor die een nieuw gecentreerd JFrame maakt met een gegeven
     *  titel, breedte en hoogte
     * @param title - De titel van het venster
     * @param width - De breedte van het venster
     * @param height - De hoogte van het venster
     * @return CenteredFrame - Het JFrame met de gegeven eigenschappen
     */
    public CenteredFrame(String title, int width, int height) {
        super(title) ;
        // Voeg de WindowAdepter toe om het sluiten van het venster te kunnen
        // regelen
        this.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                setVisible(false) ;
                dispose() ;
                System.exit(0) ;
            }
        });

        // Verander de grootte en positie van het venster
        this.setSize(width, height) ;
        Dimension screen = Toolkit.getDefaultToolkit().getScreenSize() ;
        int x = (screen.width - width) / 2 ;
        int y = (screen.height - height) / 2 ;
        this.setLocation(x, y) ;
        this.setVisible(true) ;
    }

}