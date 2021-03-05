using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LeNghia.SQL
{
    public partial class KetNoi_SQL : DbContext
    {
        public KetNoi_SQL()
            : base("name=KetNoi_SQL")
        {
        }

        public virtual DbSet<LienLac> LienLacs { get; set; }
        public virtual DbSet<Nhom> Nhoms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
