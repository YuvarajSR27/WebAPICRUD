using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YuvarajAPI.Models;

namespace YuvarajAPI.Data
{
    public class YuvarajAPIDBContext : DbContext
    {
        public YuvarajAPIDBContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Yuvaraj> Yuvarajs { get; set; }
    }
}
