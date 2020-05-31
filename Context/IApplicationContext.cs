using CQRSWithMediatRPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSWithMediatRPattern.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}