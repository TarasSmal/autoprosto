using DataContext.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repository
{
    public abstract class Repository<TEntity, TKey> where TEntity : class, ITrackeble, IStatable, IPrimary<TKey>
    {
        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public static TEntity GetOne(TKey id)
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="predicate">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        public static TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().SingleOrDefault(predicate.Compile());
            }

        }

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public static async Task<TEntity> GetOneAsync(TKey id)
        {
            using (var db = new DataContextProvider())
            {
                return await db.Set<TEntity>().FindAsync(id);
            }
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public static List<TEntity> GetAll()
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().AsNoTracking()./*Where(f=>f.IsDeleted == false).*/ToList();
            }
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="predicate">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public static ICollection<TEntity> GetAll(Expression<System.Func<TEntity, bool>> predicate)
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().AsNoTracking().Where(predicate.Compile())./*Where(f=>f.IsDeleted == false).*/ToList();
            }
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public static async Task<IList<TEntity>> GetAllAsync()
        {
            using (var db = new DataContextProvider())
            {
                return await db.Set<TEntity>().AsNoTracking()./*Where(f=>f.IsDeleted == false).*/ToListAsync();

            }
        }

        public static async Task<ICollection<TEntity>> GetAllAsync(Expression<System.Func<TEntity, bool>> predicate)
        {
            using (var db = new DataContextProvider())
            {
                return await db.Set<TEntity>().AsNoTracking().Where(predicate)/*.Where(f => f.IsDeleted == false)*/.ToListAsync();
            }
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entity">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public static void Add(TEntity entity)
        {
            Initial(ref entity);
            using (var db = new DataContextProvider())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }

        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entity">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public static async void AddAsync(TEntity entity)
        {
            using (var db = new DataContextProvider())
            {
                db.Set<TEntity>().Add(entity);
                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entityList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public static void AddAll(IEnumerable<TEntity> entityList)
        {
            using (var db = new DataContextProvider())
            {
                db.Set<TEntity>().AddRange(entityList);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entityList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public static async void AddAllAsync(IEnumerable<TEntity> entityList)
        {
            using (var db = new DataContextProvider())
            {
                db.Set<TEntity>().AddRange(entityList);
                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public void Update(TEntity updated, int key)
        {
            if (updated != null)
                using (var db = new DataContextProvider())
                {
                    TEntity existing = db.Set<TEntity>().Find(key);
                    if (existing != null)
                    {
                        db.Entry(existing).CurrentValues.SetValues(updated);
                        db.SaveChanges();
                    }

                }
        }


        public static void Update(TEntity entity)
        {
            Initial(ref entity);
            using (var db = new DataContextProvider())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static async Task UpdateAsync(TEntity entity)
        {
            Initial(ref entity);

            using (var db = new DataContextProvider())
            {
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            using (var dm = new DataContextProvider())
            {
                dm.Set<TEntity>().Attach(entity);
                DbEntityEntry<TEntity> entry = dm.Entry(entity);

                foreach (var selector in properties)
                    entry.Property(selector).IsModified = true;
            }
        }

        public static void Delete(TKey id)
        {
            using (var db = new DataContextProvider())
            {
                var entity = GetOne(id);
                var entry = db.Entry(entity);

                if (entry.State == EntityState.Detached)
                    db.Set<TEntity>().Attach(entity);

                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }

        public static void Delete(TEntity entity)
        {
            using (var db = new DataContextProvider())
            {
                var entry = db.Entry(entity);

                if (entry.State == EntityState.Detached)
                    db.Set<TEntity>().Attach(entity);

                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public int Count()
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().Count();
            }
        }

        public static int Count(Expression<System.Func<TEntity, bool>> predicate)
        {
            using (var db = new DataContextProvider())
            {
                return db.Set<TEntity>().Count(predicate.Compile());
            }
        }

        public static async Task<int> CountAsync(Expression<System.Func<TEntity, bool>> predicate)
        {
            using (var db = new DataContextProvider())
            {
                return await db.Set<TEntity>().CountAsync(predicate);
            }
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public async Task<int> CountAsync()
        {
            using (var db = new DataContextProvider())
            {
                return await db.Set<TEntity>().CountAsync();
            }
        }

        /// <summary>
        /// Set Required properties
        /// </summary>
        /// <param name="entity"></param>
        static void Initial(ref TEntity entity)
        {
            entity.IsActive = true;
            
            entity.CreatedOn = (entity.CreatedOn >= (DateTime)SqlDateTime.MinValue) ? DateTime.Now : entity.CreatedOn;
            entity.UpdatedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
            try
            {
                //entity.IdUpdatedBy = FormsAuthenticationService.User.Id;
            }
            catch
            {
                entity.IdUpdatedBy = 0;

            }
        }
    }
}