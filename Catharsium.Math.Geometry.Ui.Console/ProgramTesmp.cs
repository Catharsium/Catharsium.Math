//using System;

//public class ProgramTesmp { 
//    public readonly string Title = "Geometry Demo" ;

//    private int width = 800, height = 600 ;
//    // Het centrale venster
//    //private CenteredFrame cf ;
//    // De demonstratie
//    //private DemoPanel dp ;


//    public DemoPanel chooseDemo() {
//        DemoPanel[] options = new DemoPanel[] {
//            new DemoPanel(),
//            new DemoH(),
//            new DemoZ(),
//            new DemoM(),
//            new DemoI(),
//            new DemoIABC(),
//            new DemoEF()
//        } ;

//        // Gebruik een invoer scherm om de kezue van de gebruiker te verkrijgen
//        // en geef de benodigde parameters mee
//        // NB: Wanneer de DemoPanel's rechtstreeks worden meegegeven hoeft de
//        // de keuze van de gebruiker niet te worden vertaalt naar een DemoPanel
//        // object zoals bij het meegeven van Strings, maar IS de keuze van de
//        // gebruiker al het gevraagde DemoPanel object!
//        DemoPanel selectedOption = (DemoPanel)JOptionPane.showInputDialog(
//            null, TITLE+ "; demonstratie selectie",
//            "Selecteer een demonstratie uit de lijst",
//            JOptionPane.QUESTION_MESSAGE,
//            null, options, options[0]
//        ) ;

//        return selectedOption ;
//    }


//    /** changeDemo is een methode om de demo in het Opgave13 object te kunnen
//     *  wijzigen; een eventuele demonstratie die al wordt uigevoerd wordt
//     *  afgesloten en de gebruiker krijgt de keuze om een nieuwe te kiezen
//     */
//    public void changeDemo() {
//        // Sluit een eventueel bestand venster netjes af; voornamelijk bedoeld
//        // bij gebruik van de other knop in het Display object
//        if(cf != null) {
//            cf.setVisible(false) ;
//            cf.dispose() ;
//        }

//        // Laadt de gebruiker een demo kiezen en houd hem/ haar op de hoogte
//        // van de status
//        Console.WriteLine("\nKies een van de beschikbare demo's...") ;
//        dp = this.chooseDemo() ;
//        if(dp != null) {
//            Console.WriteLine("OK, " +dp.getTitle()+ "wordt nu geladen") ;
//            Console.WriteLine(".........................") ;
//            cf = new Display(this.Title, width, height, dp, this) ;
//        }
//        // Geen demo geselecteerd (bv Cancel-knop gebruikt); meldt de fout aan
//        // de gebruiker en het programma loopt ten einde
//        else {
//            Console.WriteLine("\nFOUT! Geen demo geselecteerd") ;
//            Console.WriteLine("Herstart het programma om het nogmaals" +
//                               " te proberen") ;
//            System.exit(0) ;
//        }
//    }


//    public static void main(String [] args) {
//        Console.WriteLine(program.TITLE+ " wordt gestart") ;
//        program.changeDemo() ;
//    }

//}