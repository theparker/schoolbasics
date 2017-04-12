namespace DatabaseMigrator.Dtos
{
    public class MigrationNamespace
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
