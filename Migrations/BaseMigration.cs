using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations
{
    public abstract class BaseMigration: Migration
    {
        public string _prefix { get; set; }
        public string _table { get; set; }

        public BaseMigration(string table)
        {
            this._table = ! string.IsNullOrWhiteSpace(this._prefix)? $"{_prefix}_{_table}": table;
        }
    }
}
