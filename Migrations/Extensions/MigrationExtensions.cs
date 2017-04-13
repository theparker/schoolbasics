using FluentMigrator.Builders.Create.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Extensions
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithIDColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string id = "id")
        {
            return tableWithColumnSyntax
                .WithColumn(id)
                .AsInt32()
                .NotNullable()
                .PrimaryKey()
                .Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithTimeStamps(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("created_at").AsDateTime().NotNullable()
                .WithColumn("modified_at").AsDateTime().NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithSoftDeletes(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("deleted_at").AsDateTime().Nullable();
        }
    }
}
