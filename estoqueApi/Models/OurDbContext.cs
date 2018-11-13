using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace estoqueApi.Models
{
    public class OurDbContext :DbContext
    {
        public DbSet<UserAccount>UserAccounts { get; set; }
    }
}