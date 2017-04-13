using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    public class _1492087704_CreateAcademicYearTable : BaseMigration
    {
        public _1492087704_CreateAcademicYearTable() : base("academic_year")
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
                .WithColumn("name").AsString();
        }
    }
}
