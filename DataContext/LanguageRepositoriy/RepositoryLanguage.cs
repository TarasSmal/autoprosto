using DataContext.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repository
{
    public class LanguageRepository<TEntity> : Repository<TEntity, long> where TEntity : class, ILanguage, IOriginal, ITrackeble, IStatable, IPrimary<long> 
    {
        public static IEnumerable<TEntity> GetAll(byte IdLanguage)
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().AsNoTracking().Where(f=>f.IdLanguage == IdLanguage).ToList();
            }
        }

        public static TEntity GetOne(int OriginalId, byte IdLanguage)
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().AsNoTracking().FirstOrDefault(f => f.OriginalId == OriginalId && f.IdLanguage == IdLanguage);
            }
        }
    }
}
