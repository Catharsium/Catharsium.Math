using System.IO;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Math.Geometry.Ui.Console.FileStorage
{
    public class FileInput
    {
        private readonly IFile file;
        private readonly StreamReader reader;


        public FileInput(IFileFactory fileFactory, string fileName) : this(fileFactory.CreateFile(fileName))
        {
            if (!this.file.Exists) {
                this.reader = this.file.OpenText();
            }
        }


        public FileInput(IFile file)
        {
            this.file = file;
        }


        public string Write()
        {
            return this.reader.ReadLine();
        }
    }
}