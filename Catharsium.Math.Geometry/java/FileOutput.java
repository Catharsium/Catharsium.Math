import java.io.* ;



/** Class FileOut; de bruikbare gedeeltes van FileOutput
 */
public class FileOutput {

    private String filename = "" ;
    public  String getFileName() {return(filename) ;}
    public  void   setFileName(String filename) {this.filename = filename ;}

    private BufferedWriter writer = null ;

    public FileOutput(String filename) {
        this.filename = filename ;
        try {writer = new BufferedWriter(new FileWriter(filename)) ;}
        catch(IOException e) {error("cannot open " +filename) ;}
    }
    public FileOutput(File file) {
        this(file.getName()) ;
    }

    public final void close() {
        try {writer.close() ;}
        catch(IOException e) {error("cannot close " +filename) ;}
    }

    public final void write(String s) {
        if (s == null) return ;
        try {writer.write(s) ;}
        catch (IOException e) {error("cannot write "+s+" to " +filename) ;}
    }

    public final void nl() {write("\n") ;}

    private void error(String ermsg) {
        System.err.println(ermsg) ;
        System.err.println("cannot continue execution: exit!") ;
        System.exit(0) ;
    }

}