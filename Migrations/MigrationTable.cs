using FluentMigrator.VersionTableInfo;

namespace Migrations
{
    [VersionTableMetaData]
    public class MigrationTable : DefaultVersionTableMetaData
    {
        public override string TableName
        {
            get { return "_migrations"; }
        }
    }

}
