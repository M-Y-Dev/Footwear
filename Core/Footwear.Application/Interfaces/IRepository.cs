using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; } // tek tek db set yapmamak için
        Task<int> SaveChanges();

        //Read Repository
        Task<List<T>?> GetAllAsync(); // listeleme
        Task<List<T>?> GetAllAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes); // filtreli listeleme
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter); // filtreli tek veri alma
        Task<T> GetSingleByIdAsync(int id); // idye göre tek veri alma
        Task<int> GetCountAsync(); // veri sayısı
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter); // filtreli veri sayısı

        //Write Repository
        Task<bool> DeleteAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
