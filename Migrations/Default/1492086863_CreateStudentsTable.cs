using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    public class _1492086863_CreateStudentsTable : BaseMigration
    {
        public _1492086863_CreateStudentsTable() : base("students")
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
                .WithColumn("first_name").AsString()
                .WithColumn("middle_name").AsString()
                .WithColumn("last_name").AsString()
                .WithColumn("date_of_birth").AsDate()
                .WithColumn("photo").AsString();
        }
    }
}
