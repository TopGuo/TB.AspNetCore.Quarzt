using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TB.AspNetCore.Data.Entity
{
    public partial class ggb_offlinebetaContext : DbContext
    {
        public ggb_offlinebetaContext()
            
        {
        }
        public ggb_offlinebetaContext(DbContextOptions<ggb_offlinebetaContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<ScheduleInfo> ScheduleInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("%%%%;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ScheduleInfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasColumnName("AppID")
                    .HasColumnType("varchar(40)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreateAuthr).HasColumnType("varchar(30)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CromExpress)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DataStatus).HasColumnType("int(11)");

                entity.Property(e => e.EndRunTime).HasColumnType("datetime");

                entity.Property(e => e.InterfaceCode).HasColumnType("varchar(40)");

                entity.Property(e => e.JobGroup)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NextRunTime).HasColumnType("datetime");

                entity.Property(e => e.RunStatus)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ServiceCode).HasColumnType("varchar(40)");

                entity.Property(e => e.StarRunTime).HasColumnType("datetime");

                entity.Property(e => e.TaskDescription).HasColumnType("varchar(200)");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasDefaultValueSql("''");
            });
            
        }
    }
}
