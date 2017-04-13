using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    public class _1492086107_CreateUserTable : BaseMigration
    {
        public _1492086107_CreateUserTable() : base("users")
        {
        }

        public override void Down()
        {
            this.Delete.Table(this._table);
        }

        public override void Up()
        {
            this.Create.Table(this._table)
               .WithIDColumn()
               .WithColumn("username").AsString().NotNullable().Unique()
               .WithColumn("password").AsString().Nullable()
               .WithColumn("notes").AsString(int.MaxValue).Nullable(); //Use in.MaxValue to make it varchar(max)
        }
    }
}
