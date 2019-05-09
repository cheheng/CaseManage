using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestCase.Infrastructure.Data
{
    public partial class CasemanaContext : DbContext
    {
        public CasemanaContext()
        {
        }

        public CasemanaContext(DbContextOptions<CasemanaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Casedetail> Casedetail { get; set; }
        public virtual DbSet<Employ> Employ { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Thecase> Thecase { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Userdetail> Userdetail { get; set; }
        public virtual DbSet<Userrelation> Userrelation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=root;database=casemana;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Casedetail>(entity =>
            {
                entity.ToTable("casedetail");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Previous)
                    .HasColumnName("previous")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Prior)
                    .HasColumnName("prior")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Employ>(entity =>
            {
                entity.HasKey(e => e.Eid)
                    .HasName("PRIMARY");

                entity.ToTable("employ");

                entity.Property(e => e.Eid)
                    .HasColumnName("eid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ename)
                    .HasColumnName("ename")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PRIMARY");

                entity.ToTable("plan");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PStorage)
                    .HasColumnName("p_storage")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Pretime)
                    .HasColumnName("pretime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Proid)
                    .HasColumnName("proid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Realtime)
                    .HasColumnName("realtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Proid)
                    .HasName("PRIMARY");

                entity.ToTable("project");

                entity.Property(e => e.Proid)
                    .HasColumnName("proid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pretime)
                    .HasColumnName("pretime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Proname)
                    .HasColumnName("proname")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Realtime)
                    .HasColumnName("realtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Thecase>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PRIMARY");

                entity.ToTable("thecase");

                entity.HasIndex(e => e.Ctitle)
                    .HasName("ctitle_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ctitle)
                    .HasColumnName("ctitle")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Proid)
                    .HasColumnName("proid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Toname)
                    .HasColumnName("toname")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Unid)
                    .HasColumnName("unid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.Unid)
                    .HasName("PRIMARY");

                entity.ToTable("unit");

                entity.Property(e => e.Unid)
                    .HasColumnName("unid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pretime)
                    .HasColumnName("pretime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Realtime)
                    .HasColumnName("realtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnName)
                    .HasColumnName("un_name")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.UnStorage)
                    .HasColumnName("un_storage")
                    .HasColumnType("varchar(400)");
            });

            modelBuilder.Entity<Userdetail>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("userdetail");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .HasColumnType("date");

                entity.Property(e => e.Passwod)
                    .HasColumnName("passwod")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Uname)
                    .HasColumnName("uname")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Userrelation>(entity =>
            {
                entity.HasKey(e => e.Urid)
                    .HasName("PRIMARY");

                entity.ToTable("userrelation");

                entity.Property(e => e.Urid)
                    .HasColumnName("URId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Eid)
                    .HasColumnName("eid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Proid)
                    .HasColumnName("proid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");
            });
        }
    }
}
