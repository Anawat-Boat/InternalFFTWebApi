using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InternalWebApi.Models
{
    public partial class demodatabaseContext : DbContext
    {
        public demodatabaseContext()
        {
        }

        public demodatabaseContext(DbContextOptions<demodatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Section> Sections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Database=demodatabase; Server=192.168.2.99; Uid=usrrw; Pwd=activerw;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.UserName, "USER_NAME_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId, "fk_ACCOUNT_ROLE1_idx");

                entity.Property(e => e.AccountId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ACCOUNT_ROLE1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.DepartmentName, "DEPARTMENT_NAME_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.LastUser)
                    .HasMaxLength(10)
                    .HasColumnName("LAST_USER");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.Email, "EMAIL_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.EmployeeCode, "EMPLOYEE_CODE_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PositionId, "fk_EMPLOYEE_POSITION1_idx");

                entity.HasIndex(e => e.SectionId, "fk_EMPLOYEE_SECTION1_idx");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("EMPLOYEE_CODE");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LastUser)
                    .HasMaxLength(10)
                    .HasColumnName("LAST_USER");

                entity.Property(e => e.PositionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("POSITION_ID");

                entity.Property(e => e.SectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SECTION_ID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EMPLOYEE_POSITION1");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EMPLOYEE_SECTION1");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.HasIndex(e => e.PositionName, "POSITION_NAME_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PositionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("POSITION_ID");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.LastUser)
                    .HasMaxLength(10)
                    .HasColumnName("LAST_USER");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("POSITION_NAME");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.RoleName, "ROLE_NAME_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.HasIndex(e => e.SectionName, "SECTION_NAME_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.DepartmentId, "fk_SECTION_DEPARTMENT1_idx");

                entity.Property(e => e.SectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SECTION_ID");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.LastUser)
                    .HasMaxLength(10)
                    .HasColumnName("LAST_USER");

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SECTION_NAME");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SECTION_DEPARTMENT1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
