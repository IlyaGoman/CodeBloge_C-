using System;
using System.Data.Entity;

namespace EntityApp
{
    public class MyDbContext: DbContext
    {
        protected MyDbContext() : base("DbConnectionString")
        {

        }
    }
}
