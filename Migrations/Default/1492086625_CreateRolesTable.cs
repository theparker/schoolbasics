using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    public class _1492086625_CreateRolesTable : BaseMigration
    {
        public _1492086625_CreateRolesTable() : base("roles")
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
                .WithColumn("role_name").AsInt32();
        }
    }
}
