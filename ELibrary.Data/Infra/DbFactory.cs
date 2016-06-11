using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data.Infra
{
    public class DbFactory : Disposable, IDbFactory
    {
        ELibraryEntities dbContext;

        public ELibraryEntities Init()
        {
            return dbContext ?? (dbContext = new ELibraryEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
