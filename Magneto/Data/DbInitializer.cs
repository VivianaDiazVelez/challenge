using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Magneto.Data
{
    public class DbInitializer : IDbInitializer
    {
        public readonly ApplicationDBContext _db;

        public DbInitializer( ApplicationDBContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
