using Migrations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Default
{
    class _1492174181_CreateBillingTemplateTable : BaseMigration
    {
        public _1492174181_CreateBillingTemplateTable() : base("billing_templates")
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
                .WithColumn("academic_year_id").AsInt32()
                .WithColumn("utility_id").AsInt32() //Description
                .WithColumn("class_id").AsInt32()
                .WithColumn("unit_amount").AsDecimal()
                .WithColumn("quantity").AsInt32()
                .WithColumn("comments").AsString(int.MaxValue).Nullable()
                .WithTimeStamps()
                .WithSoftDeletes();
        }
    }
}
