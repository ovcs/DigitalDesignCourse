using System.Runtime.Serialization;
using System.Text;
using UniqueWordCounter.Models.Repo;

namespace UniqueWordCounter.IO
{
    internal class FileSaver : ISaver
    {
        IWordRepoManager repManager;
        Encoding encoding;
        FileStreamOptions options = new();
        string fileFormatSerialization = "desc value count";
        string defaultFileName = "noname";

        public FileSaver(IWordRepoManager data,
                         Encoding encoding,
                         FileStreamOptions options)
        {
            this.repManager = data;
            this.encoding = encoding;
            this.options = options;
        }

        public FileSaver (IWordRepoManager data)
        {
            this.repManager = data;
            this.encoding = Encoding.UTF8;
            this.options = new();
            options.Access = FileAccess.Write;
            options.Mode = FileMode.OpenOrCreate;
        }

        public void Save(string directory, string filename, ISerializator format)
        {
            if (!Directory.Exists(directory))
            {
                throw new IOException("Directory doesn't exist");
            }

            if (string.IsNullOrEmpty(filename))
                filename = defaultFileName;

            string path = Path.Combine(directory, filename);

            List<string> files = repManager.Query(fileFormatSerialization);
            string tofile = format.Serialize(files);
            using (StreamWriter sr = new(path, encoding, options))
                sr.Write(tofile);
        }
    }
}
