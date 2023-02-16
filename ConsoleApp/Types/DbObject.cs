namespace ConsoleApp
{
    public abstract class DbObject
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public DbObject(CsvModel line)
        {
            Name = line.Name;
            Type = line.Type;
        }
    }

}
