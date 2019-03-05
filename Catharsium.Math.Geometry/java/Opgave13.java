import javax.swing.* ;


/**
 * NAAM   : T.W. Brachthuizer<BR>
 * CKNUM  : 0105821<BR>
 * GROEP  : INF2<BR>
 * LOGIN  : tbrachth<BR><BR><BR>
 *
 * <B>Opgave13.java</B><BR>
 * Het hoofdprogramma dat bij aanvang de gebruiker vraagt om een demo te kiezen
 * en deze vervolgens laadt. Het programma roept de methode
 * JOptionPane.showInputDialog aan en geeft naast alle andere benodigde
 * parameters een reeks van DemoPanels mee, waarvan degene die de gebruiker
 * kiest wordt geladen in het venster. Dit venster wordt zelf weer in elkaar
 * gezet in de klasse Display, die een gecentreerd JFrame maakt (zie
 * documentatie CenteredFrame) en in het venster het meegegeven DemoPanel
 * plaatst. Als toevoeging buiten de opdracht voegt de klasse Display nog een
 * knop toe om de demo te wissen (om opnieuw te kunnen beginnen) en een knop
 * waarmee ook de hele demo kan worden vervangen door een andere.<BR><BR>
 *
 * <B>Model:</B><BR>
 * Opgave13 vormt de centrale klasse van dit programma; het zorgt in eerste
 * instantie voor het maken van een nieuw gecentreerd frame met daarin de demo
 * die door de gebruiker is gekozen. De klasse Display wordt door Opgave13
 * aangeroepen met enkele parameters en veranderd het JFrame (zichzelf) zoals
 * gevraagd; hij centreert zich automatisch en geeft zich de juiste afmetingen
 * en titel. Daarnaast wordt het meegegeven JPanel in het venster gezet (in dit
 * programma altijd een DemoPanel object).<BR>
 * Display objecten bevatten naast de inhoud altijd knoppen voor het
 * 'schoonmaken' van de demo om andere punten in te kunnen voeren en om een
 * geheel andere demonstratie te kunnen kiezen. Display objecten kunnen worden
 * afgesloten; een WindowAdapter is toegevoegd en ge-implementeerd.<BR>
 * De klasse Opgave13 gebruik ik als een object omdat dit voordelen biedt met
 * betrekking tot het veranderen van demonstratie.<BR><BR>
 *
 * DemoPanel objecten zijn JPanels waarin de werking van de demo's zelf al is
 * ge-implementeerd; het luisteren naar MouseEvents en het tekenen van de
 * punten A, B en C en de lijnen van de driehoek zelf gebeurt al in DemoPanel.
 * De andere demo's zoals DemoZ en DemoH tekenen slechts de extra lijnen en
 * punten die ontstaan wanneer de drie hoekpunten zijn ingevoerd. Ze maken
 * gebruik van de gelijknamige Triangle# klassen om de extra punten uit te
 * rekenen. De driehoek zelf wordt altijd getekend door super.paintComponent(g)
 * aan te roepen.<BR>
 *
 * Bij opdracht 13 is de klasse DemoEF toegevoegd die de lijnen van Euler en de
 * cirkel van Feuerbach tekent, samen met de lijnen die ook te vinden zijn in
 * DemoZ, DemoH en DemoM. Daarnaast is de klasse DemoPanel aangepast zodat deze
 * dynamisch gebruikt kan worden; het eerste punt kan worden vastgezet met een
 * mouseClicked event, punt B met een mousPressed event en C door te slepen
 * (mouseDragged).
 *
 * @author <A HREF="mailto:omnikefka@yahoo.com">T.W.Brachthuizer</A>
 * @version Opgave13.java v1.0 --- (08-05-2002)
 */
public class Opgave13 { 

    // De standaard titel van het programma
    public final static String TITLE = "PRACTICUM 13" ;
    // De hoogte en breedte van het centrale venster
    private int width = 800, height = 600 ;
    // Het centrale venster
    private CenteredFrame cf ;
    // De demonstratie
    private DemoPanel dp ;


    /** Default constructor om een Opgave13 object te maken; een Opgave13
     *  object omvat een CenteredFrame (als Display gebruikt) en een DemoPanel
     *  dat de door de gebruiker gevraagde demonstratie bevat
     */
    public Opgave13() {
    }


    /** chooseDemo toont een input dialog aan de gebruiker, waarin een lijst
     *  met de beschikbare demo's staat
     * @return demo - Het DemoPanel object dat de gebruiker wil starten
     */
    public DemoPanel chooseDemo() {
        // De beschikbare demo objecten waaruit de gebruiker kan kiezen
        DemoPanel[] options = new DemoPanel[] {
            new DemoPanel(),
            new DemoH(),
            new DemoZ(),
            new DemoM(),
            new DemoI(),
            new DemoIABC(),
            new DemoEF()
        } ;

        // Gebruik een invoer scherm om de kezue van de gebruiker te verkrijgen
        // en geef de benodigde parameters mee
        // NB: Wanneer de DemoPanel's rechtstreeks worden meegegeven hoeft de
        // de keuze van de gebruiker niet te worden vertaalt naar een DemoPanel
        // object zoals bij het meegeven van Strings, maar IS de keuze van de
        // gebruiker al het gevraagde DemoPanel object!
        DemoPanel selectedOption = (DemoPanel)JOptionPane.showInputDialog(
            null, TITLE+ "; demonstratie selectie",
            "Selecteer een demonstratie uit de lijst",
            JOptionPane.QUESTION_MESSAGE,
            null, options, options[0]
        ) ;

        return selectedOption ;
    }


    /** changeDemo is een methode om de demo in het Opgave13 object te kunnen
     *  wijzigen; een eventuele demonstratie die al wordt uigevoerd wordt
     *  afgesloten en de gebruiker krijgt de keuze om een nieuwe te kiezen
     */
    public void changeDemo() {
        // Sluit een eventueel bestand venster netjes af; voornamelijk bedoeld
        // bij gebruik van de other knop in het Display object
        if(cf != null) {
            cf.setVisible(false) ;
            cf.dispose() ;
        }

        // Laadt de gebruiker een demo kiezen en houd hem/ haar op de hoogte
        // van de status
        System.out.println("\nKies een van de beschikbare demo's...") ;
        dp = this.chooseDemo() ;
        if(dp != null) {
            System.out.println("OK, " +dp.getTitle()+ "wordt nu geladen") ;
            System.out.println(".........................") ;
            cf = new Display(TITLE, width, height, dp, this) ;
        }
        // Geen demo geselecteerd (bv Cancel-knop gebruikt); meldt de fout aan
        // de gebruiker en het programma loopt ten einde
        else {
            System.err.println("\nFOUT! Geen demo geselecteerd") ;
            System.err.println("Herstart het programma om het nogmaals" +
                               " te proberen") ;
            System.exit(0) ;
        }
    }


    /** Main methode van dit project; start het programma
     */
    public static void main(String [] args) {
        // Maak een nieuw Opgave13 object waarmee gewerkt zal worden
        Opgave13 program = new Opgave13() ;

        // Vraag de gebruiker om de demonstratie te kiezen en start de demo
        System.out.println(program.TITLE+ " wordt gestart") ;
        program.changeDemo() ;
    }

}