using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    public class _1492087459_CreateStudentClassHistoryTable : BaseMigration
    {
        public _1492087459_CreateStudentClassHistoryTable(string table) : base(table)
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
                .WithColumn("student_id").AsInt32()
                .WithColumn("class_id").AsInt32()
                .WithTimeStamps();
        }
    }
}
