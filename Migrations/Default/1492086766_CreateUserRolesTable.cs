using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    public class _1492086766_CreateUserRolesTable : BaseMigration
    {
        public _1492086766_CreateUserRolesTable() : base("user_roles")
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
                .WithColumn("user_id").AsInt32()
                .WithColumn("role_id").AsInt32();
        }
    }
}
