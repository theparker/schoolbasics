#region usings




#endregion

/*
 * Help for the command https://github.com/schambers/fluentmigrator/wiki/Fluent-Interface
 * 
 *  public override void Up()
        {
            Execute.Sql(@"
            ALTER TABLE [dbo].[tbl_LabCompany] ADD [ExternalIdTypeCode] VARCHAR(5) NULL;
            ALTER TABLE [dbo].[tbl_LabCompany] ADD [DirectorExternalIdTypeCode] VARCHAR(5) NULL;"
                        );
        }

        public override void Down()
        {
            Execute.Sql(@"
            ALTER TABLE [dbo].[tbl_LabCompany]   ADD [ExternalIdTypeCode] VARCHAR(5) NULL;
            ALTER TABLE [dbo].[tbl_LabCompany] ADD [DirectorExternalIdTypeCode] VARCHAR(5) NULL;"
                         );
        }
 * */
using FluentMigrator;

namespace Migrations.Default
{
    [Migration(1, "Author: Glushak Stanislav; Examlpe")]
    public class Migration_1: Migration
    {
        public override void Up()
        {
          
        }

        public override void Down()
        {

        }
    }
}
