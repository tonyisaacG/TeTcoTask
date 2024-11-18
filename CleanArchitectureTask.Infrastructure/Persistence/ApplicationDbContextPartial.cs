using CleanArchitectureTask.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace CleanArchitectureTask.Infrastructure.Persistence
{
    public partial class ApplicationDbContext
    {

        protected static IList<Type> _entityTypeCache;
        protected static IList<Type> GetEntityTypes()
        {
            if( _entityTypeCache != null )
            {
                return _entityTypeCache.ToList();
            }
            var assembly = Assembly.Load(new AssemblyName("CleanArchitectureTask.Domain"));

            _entityTypeCache = new List<Type>();
            foreach( var t in assembly.GetTypes().Where(obj=>!obj.IsAbstract) )
            {
                if( typeof(IBaseEntity).IsAssignableFrom(t) && t.Name != nameof(IBaseEntity) )
                    _entityTypeCache.Add(t);
            }
            return _entityTypeCache;
        }
      
        public void SetGlobalQueryMethodForBaseEntity<T>(ModelBuilder builder) where T :class, new()
        {
            builder.Entity<T>().HasQueryFilter(filter => !( (IBaseEntity)filter ).IsDeleted);
        }
        static readonly MethodInfo SetGlobalQueryForBaseEntity =
        typeof(ApplicationDbContext)
        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
        .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQueryMethodForBaseEntity");

        protected void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach( var entry in entries )
            {
                if( entry.Entity is IBaseEntity trackable )
                {
                    var now = DateTime.UtcNow;
                    switch( entry.State )
                    {
                        case EntityState.Modified:
                            trackable.UpdatedAt = now;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.UpdatedAt = now;
                            trackable.IsDeleted = false;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            trackable.UpdatedAt = now;
                            trackable.IsDeleted = true;
                            break;
                    }
                }

            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
