namespace Mickey
{
    public class File
    {
        public string Name { get; private set; }
        public double Size { get; private set; }

        public File(string name, double size)
        {
            Name = name;
            Size = size;
        }
    }
}
