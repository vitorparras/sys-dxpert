using Domain.Model.Bases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    public static class ContextExtension
    {
        public static void SeedWithAutoIncrement<TEntity>(ModelBuilder modelBuilder, IEnumerable<TEntity> data) where TEntity : BaseEntity
        {
            int idCounter = 1; 
            foreach (var item in data)
            {
                item.Id = idCounter++; 
            }

            modelBuilder.Entity<TEntity>().HasData(data);
        }
    }
}
