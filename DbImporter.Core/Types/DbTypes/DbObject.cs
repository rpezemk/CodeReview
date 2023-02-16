namespace DbImporter.Core.Types.DbTypes
{

    /// <summary>
    /// General db object (abstract)
    /// </summary>
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
