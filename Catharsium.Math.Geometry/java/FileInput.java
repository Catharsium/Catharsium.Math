import java.io.* ;


/** Class FileIn; de bruikbare gedeeltes van FileInput
 */
public class FileInput {

    private String filename = "" ;
    public  String getFileName() {return(filename) ;}
    public  void setFileName(String filename) {this.filename = filename ;}

    private BufferedReader reader = null ;

    private boolean eof = false ;
    public  boolean eof() {return(eof) ;}

    public FileInput(String filename) {
        this.filename = filename ;
        try {reader = new BufferedReader(new FileReader(filename)) ;}
        catch(FileNotFoundException e) {error("cannot open " +filename) ;}
    }
    public FileInput(File file) {
        this(file.getName()) ;
    }

    public final void close() {
        try {reader.close() ;}
        catch(IOException e) {error("cannot close " +filename) ;}
    }

    public final String readln() {
        String input = null ;
        try {
            input = reader.readLine() ;
        }
        catch (IOException e) {
            error("cannot read string from " +filename) ;
        }
        if (input == null)
            eof = true ;
        return(input) ;
    }

    private void error(String ermsg) {
        System.err.println(ermsg) ;
        System.err.println("cannot continue execution: exit!") ;
        System.exit(0) ;
    }

}