namespace DbImporter.Core.Types.DbTypes
{
    public abstract class DbObject
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public DbObject(CsvLineModel line)
        {
            Name = line.Name;
            Type = line.Type;
        }
    }

}
