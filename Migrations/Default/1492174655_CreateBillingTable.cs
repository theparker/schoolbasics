using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    public class _1492174655_CreateBillingTable : BaseMigration
    {
        public _1492174655_CreateBillingTable(string table) : base(table)
        {
        }

        public override void Up()
        {
            this.Create.Table(this._table)
                .WithIDColumn()
                .WithColumn("billing_template_id").AsInt32().Nullable()
                .WithColumn("academic_year_id").AsInt32()
                .WithColumn("utility_id").AsInt32() //Description
                .WithColumn("class_id").AsInt32()
                .WithColumn("student_id").AsInt32()
                .WithColumn("unit_amount").AsDecimal()
                .WithColumn("quantity").AsInt32()
                .WithColumn("comments").AsString(int.MaxValue).Nullable()
                .WithTimeStamps()
                .WithSoftDeletes();
        }
    }
}
