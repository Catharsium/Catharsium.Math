using System.IO;
using Catharsium.Util.IO.Interfaces;

public class FileOutput
{
    private readonly IFile file;
    private readonly StreamWriter writer;


    public FileOutput(IFileFactory fileFactory, string fileName) : this(fileFactory.CreateFile(fileName))
    {
        if (!this.file.Exists)
        {
            this.writer = this.file.CreateText();
        }
    }


    public FileOutput(IFile file)
    {
        this.file = file;
    }


    public void Write(string text)
    {
        this.writer.WriteLine(text);
    }
}