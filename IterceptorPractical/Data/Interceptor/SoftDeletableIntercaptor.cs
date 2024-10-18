using IterceptorPractical.Entities.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterceptorPractical.Data.Interceptor
{
    internal class SoftDeletableIntercaptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null) return result;

            foreach(var entry in eventData.Context.ChangeTracker.Entries())
            {
                //if (entry is null
                //    || entry.State != EntityState.Deleted
                //    || !(entry.Entity is ISoftDeletable deletable)
                //  ) continue; 

                //Anothr Way 
                if (entry is not { State: EntityState.Deleted, Entity: ISoftDeletable deletable })
                    continue;
                //==>
                entry.State = EntityState.Modified;

                deletable.Delete();

            }
            return result;
        }
    }
}
