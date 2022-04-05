namespace Mickey
{
    public class File
    {
        public string Name { get; private set; }
        public string Extension { get; private set; }
        public double Size { get; private set; }

        public File(string name, string extension, double size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }
    }
}
