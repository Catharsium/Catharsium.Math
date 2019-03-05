import javax.swing.* ;
import java.awt.* ;
import java.awt.event.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>Display.java</B><BR>
 * Display is een eenvoudige klasse dat in principe slechts een JFrame omvat,
 * maar waarin de inhoud reeks bij de constructie in de vorm van een JPanel
 * wordt toegevoegd. Daarnaast wordt een Display object automatisch bij de
 * start van het programma gecentreerd op het scherm weergegeven en bevat de
 * de benodigde WindowListener om het scherm en tevens het gehele programma af
 * te kunnen sluiten wanneer de gebruiker dit wil.<BR><BR>
 *
 * De klasse is oorspronkelijk bedoeld als onderdeel van het programma
 * Opgave13.java, maar is zo algemeen opgesteld dat het ook door andere
 * programma's te gebruiken is.<BR>
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version Display.java v1.0 --- (08-05-2002)
 */
public class Display extends CenteredFrame { 

    // Knoppen om acties uit te voeren
    private JButton clear, other ;
    // De inhoud van het venster
    private JPanel demo, topMenu ;
    // Het aanroepende programma object
    private final Opgave13 caller ;


    /** Constructor die een nieuw Display object maakt; een gecentreerd JFrame
     *  met een gegeven titel, hoogte, breedte en inhoud
     * @param title - De titel van het venster
     * @param width - De breedte van het venster
     * @param height - De hoogte van het venster
     * @param jp - Het JPanel met de inhoud van het venster
     */
    public Display(String title, int width, int height, JPanel jp, Opgave13 c) {
        // Verander de grootte, titel, kleur en inhoud van het object
        super(title, width, height) ;
        this.caller = c ;
        demo = jp ;
        demo.setBackground(Color.gray) ;
        demo.setLayout(new BorderLayout()) ;

        // De knoppenbalk
        topMenu = new JPanel() ;
        topMenu.setLayout(new FlowLayout()) ;

        // Knop om opnieuw te beginnen in de huidige demonstratie
        clear = new JButton("Maak leeg") ;
        clear.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                clearDemo() ;
            }
        }) ;
        topMenu.add(clear) ;

        // Knop om een andere demo te kunnen kiezen
        other = new JButton("Nieuwe demo") ;
        other.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                caller.changeDemo() ;
            }
        }) ;
        topMenu.add(other) ;

        // Voeg de knoppenbalk en demo toe aan het scherm en licht de gebruiker
        // in
        this.getContentPane().add(topMenu, BorderLayout.NORTH) ;
        this.getContentPane().add(demo, BorderLayout.CENTER) ;
        this.setVisible(true) ;
        System.out.print("Klaar met laden!\n\n\n" +
            "===================================================\n" +
            title+ "\n" +
            "===================================================\n\n" +
            "Klik in het venster om hoekpunten te maken\n\n") ;
    }


    /** clearDemo verwijderd alle ingevoerde punten zodat er opnieuw punten
     *  kunnen worden gekozen door de gebruiker
     */
    public void clearDemo() {
        ((DemoPanel)this.demo).clear() ;
        ((DemoPanel)this.demo).repaint() ;
        System.out.println("Invoer verwijderd!\n") ;
    }

}