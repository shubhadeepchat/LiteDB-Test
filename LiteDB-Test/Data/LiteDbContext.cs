﻿using LiteDB;
using Microsoft.Extensions.Options;

namespace LiteDB_Test.Data
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(IOptions<LiteDbOptions> options) {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }
    }
}
