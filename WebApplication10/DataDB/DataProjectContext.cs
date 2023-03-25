using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gproject.DataDB
{
    public partial class DataProjectContext : DbContext
    {
        public DataProjectContext()
        {
        }

        public DataProjectContext(DbContextOptions<DataProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblAppointment> TblAppointments { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }
        public virtual DbSet<TblInquiry> TblInquiries { get; set; }
        public virtual DbSet<TblLaser> TblLasers { get; set; }
        public virtual DbSet<TblRoom> TblRooms { get; set; }
        public virtual DbSet<TblSpecialEvent> TblSpecialEvents { get; set; }
        public virtual DbSet<TblTreat> TblTreats { get; set; }
        public virtual DbSet<TblWorkHour> TblWorkHours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Initial Catalog=DataProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=DataProject;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.IdContacts)
                    .HasName("PK__Contacts__86C6BBA370C5FA70");

                entity.Property(e => e.IdContacts)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Contacts");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(50)
                    .HasColumnName("home _phone");

                entity.Property(e => e.HowComeUs)
                    .IsRequired()
                    .HasColumnName("how_comeUs");

                entity.Property(e => e.IdTreat).HasColumnName("id_treat");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(50)
                    .HasColumnName("mobile_phone");

                entity.Property(e => e.NumberPhone)
                    .HasMaxLength(50)
                    .HasColumnName("number_phone ");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("remark");

                entity.Property(e => e.Sem).HasColumnName("sem");
            });

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.IdAccount)
                    .HasName("PK__tbl_acco__741F0A2BBECAC350");

                entity.ToTable("tbl_account");

                entity.Property(e => e.IdAccount)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_account");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.IdContacts).HasColumnName("Id_Contacts");

                entity.Property(e => e.IdTreat).HasColumnName("Id_treat");
            });

            modelBuilder.Entity<TblAppointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__tbl_appo__D0F3704DB63FEDD6");

                entity.ToTable("tbl_appointments");

                entity.Property(e => e.IdAppointment)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_appointment");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IdContacts).HasColumnName("Id_Contacts");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_employee");

                entity.Property(e => e.IdTreat).HasColumnName("Id_treat");

                entity.Property(e => e.Remark).HasColumnType("text");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__tbl_empl__285BF3F77F8FC4CA");

                entity.ToTable("tbl_employees");

                entity.Property(e => e.IdEmployee)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_employee");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.IdTreat).HasColumnName("Id_treat");

                entity.Property(e => e.NameEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name_employee");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("permission");
            });

            modelBuilder.Entity<TblInquiry>(entity =>
            {
                entity.HasKey(e => e.IdInquirie)
                    .HasName("PK__tbl_inqu__57640B01E7A2A766");

                entity.ToTable("tbl_inquiries");

                entity.Property(e => e.IdInquirie)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_inquirie");

                entity.Property(e => e.IdAppointment).HasColumnName("Id_appointment");

                entity.Property(e => e.Remark).HasColumnType("text");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLaser>(entity =>
            {
                entity.HasKey(e => e.IdLaser)
                    .HasName("PK__tbl_lase__87E2B0625B449B8E");

                entity.ToTable("tbl_laser");

                entity.Property(e => e.IdLaser)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_laser");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdContacts).HasColumnName("Id_Contacts");

                entity.Property(e => e.Ms).HasMaxLength(50);

                entity.Property(e => e.Reaction).HasColumnType("text");

                entity.Property(e => e.SpotSize)
                    .HasMaxLength(50)
                    .HasColumnName("Spot_size");
            });

            modelBuilder.Entity<TblRoom>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK__tbl_room__46CA677C95FF13E0");

                entity.ToTable("tbl_room");

                entity.Property(e => e.IdRoom)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_room");

                entity.Property(e => e.NameRoom)
                    .HasMaxLength(50)
                    .HasColumnName("Name_room");
            });

            modelBuilder.Entity<TblSpecialEvent>(entity =>
            {
                entity.HasKey(e => e.IdSpecialEvents)
                    .HasName("PK__tbl_spec__77988C6AD112F0B5");

                entity.ToTable("tbl_special_events");

                entity.Property(e => e.IdSpecialEvents)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_special_events");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_employee");
            });

            modelBuilder.Entity<TblTreat>(entity =>
            {
                entity.HasKey(e => e.IdTreat)
                    .HasName("PK__tbl_trea__C3F330BCB802BCFA");

                entity.ToTable("tbl_treat");

                entity.Property(e => e.IdTreat)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_treat");

                entity.Property(e => e.NameTreat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nameTreat");
            });

            modelBuilder.Entity<TblWorkHour>(entity =>
            {
                entity.HasKey(e => e.IdWorkHours)
                    .HasName("PK__tbl_work__66F155F508FA8686");

                entity.ToTable("tbl_work_hours");

                entity.Property(e => e.IdWorkHours)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_work_hours");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
