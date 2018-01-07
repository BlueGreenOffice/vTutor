using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VTutor.Model
{
    public class VTutorContext : DbContext
    {
        public VTutorContext(DbContextOptions<VTutorContext> options)
            :base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ScheduleBlock> ScheduleBlocks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<TutorSchedule> TutorSchedules { get; set; }
    }

  public class VTutorContextFactory : IDesignTimeDbContextFactory<VTutorContext>
  {
    public VTutorContext CreateDbContext(string[] args)
    {
      var builder = new DbContextOptionsBuilder<VTutorContext>();
      builder.UseSqlServer("Server=ISAACSPC;Database=vtutor;Trusted_connection=true;");
      return new VTutorContext(builder.Options);
    }
  }
}

//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace VTutor.Model
//{
//    public partial class dev_vtutorContext : DbContext
//    {
//        public virtual DbSet<Appointment> Appointments { get; set; }
//        public virtual DbSet<AppUserPassword> AppUserPasswords { get; set; }
//        public virtual DbSet<AppUser> AppUsers { get; set; }
//        public virtual DbSet<Grade> Grades { get; set; }
//        public virtual DbSet<ScheduleBlock> ScheduleBlocks { get; set; }
//        public virtual DbSet<Student> Students { get; set; }
//        public virtual DbSet<Subject> Subjects { get; set; }
//        public virtual DbSet<Tutor> Tutors { get; set; }
//        public virtual DbSet<TutorSchedule> TutorSchedules { get; set; }
//        public virtual DbSet<TutorSubject> TutorSubjects { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=tcp:dev-vtutor.database.windows.net,1433;Initial Catalog=dev_vtutor;Persist Security Info=False;User ID=isaac;Password=I1m9a9n3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Appointment>(entity =>
//            {
//                entity.ToTable("appointments");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.EndTime)
//                    .HasColumnName("end_time")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.StartTime)
//                    .HasColumnName("start_time")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.StudentId).HasColumnName("student_id");

//                entity.Property(e => e.TutorId).HasColumnName("tutor_id");

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.AppointmentsCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_appointments_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.AppointmentsModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_appointments_modified_by");

//                entity.HasOne(d => d.Student)
//                    .WithMany(p => p.Appointments)
//                    .HasForeignKey(d => d.StudentId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_appointments_student_id");

//                entity.HasOne(d => d.Tutor)
//                    .WithMany(p => p.Appointments)
//                    .HasForeignKey(d => d.TutorId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_appointments_tutor_id");
//            });

//            modelBuilder.Entity<AppUserPassword>(entity =>
//            {
//                entity.ToTable("app_user_passwords");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.PasswordHash)
//                    .HasColumnName("password_hash")
//                    .HasMaxLength(1000)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.AppUserPasswordsCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_app_user_passwords_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.AppUserPasswordsModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_app_user_passwords_modified_by");
//            });

//            modelBuilder.Entity<AppUser>(entity =>
//            {
//                entity.ToTable("app_users");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.AppUserPasswordId).HasColumnName("app_user_password_id");

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.FirstName)
//                    .IsRequired()
//                    .HasColumnName("first_name")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.LastName)
//                    .IsRequired()
//                    .HasColumnName("last_name")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.UserName)
//                    .IsRequired()
//                    .HasColumnName("user_name")
//                    .HasMaxLength(250)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.AppUserPassword)
//                    .WithMany(p => p.AppUsers)
//                    .HasForeignKey(d => d.AppUserPasswordId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_app_users_app_user_password");

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.InverseCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_app_users_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.InverseModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_app_users_modified_by");
//            });

//            modelBuilder.Entity<Grade>(entity =>
//            {
//                entity.ToTable("grades");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasColumnName("name")
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.GradesCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_grades_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.GradesModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_grades_modified_by");
//            });

//            modelBuilder.Entity<ScheduleBlock>(entity =>
//            {
//                entity.ToTable("schedule_blocks");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.ScheduleBlocksCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_schedule_blocks_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.ScheduleBlocksModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_schedule_blocks_modified_by");
//            });

//            modelBuilder.Entity<Student>(entity =>
//            {
//                entity.ToTable("students");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.AppUserId).HasColumnName("app_user_id");

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.HasOne(d => d.AppUser)
//                    .WithMany(p => p.StudentsAppUser)
//                    .HasForeignKey(d => d.AppUserId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_students_app_user");

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.StudentsCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_students_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.StudentsModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_students_modified_by");
//            });

//            modelBuilder.Entity<Subject>(entity =>
//            {
//                entity.ToTable("subjects");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Name)
//                    .HasColumnName("name")
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.SubjectsCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_subjects_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.SubjectsModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_subjects_modified_by");
//            });

//            modelBuilder.Entity<Tutor>(entity =>
//            {
//                entity.ToTable("tutors");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.AppUserId).HasColumnName("app_user_id");

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.HasOne(d => d.AppUser)
//                    .WithMany(p => p.TutorsAppUser)
//                    .HasForeignKey(d => d.AppUserId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutors_app_user");

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.TutorsCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutors_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.TutorsModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutors_modified_by");
//            });

//            modelBuilder.Entity<TutorSchedule>(entity =>
//            {
//                entity.ToTable("tutor_schedules");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.TutorId).HasColumnName("tutor_id");

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.TutorSchedulesCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutor_schedules_created_by");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.TutorSchedulesModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutor_schedules_modified_by");
//            });

//            modelBuilder.Entity<TutorSubject>(entity =>
//            {
//                entity.ToTable("tutor_subjects");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

//                entity.Property(e => e.CreatedDate)
//                    .HasColumnName("created_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.GradeId).HasColumnName("grade_id");

//                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

//                entity.Property(e => e.ModifiedDate)
//                    .HasColumnName("modified_date")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

//                entity.Property(e => e.TutorId).HasColumnName("tutor_id");

//                entity.HasOne(d => d.CreatedByNavigation)
//                    .WithMany(p => p.TutorSubjectsCreatedByNavigation)
//                    .HasForeignKey(d => d.CreatedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutor_subjects_created_by");

//                entity.HasOne(d => d.Grade)
//                    .WithMany(p => p.TutorSubjects)
//                    .HasForeignKey(d => d.GradeId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutor_subjects_grade");

//                entity.HasOne(d => d.ModifiedByNavigation)
//                    .WithMany(p => p.TutorSubjectsModifiedByNavigation)
//                    .HasForeignKey(d => d.ModifiedBy)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutor_subjects_modified_by");

//                entity.HasOne(d => d.Subject)
//                    .WithMany(p => p.TutorSubjects)
//                    .HasForeignKey(d => d.SubjectId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutor_subjects_subject");

//                entity.HasOne(d => d.Tutor)
//                    .WithMany(p => p.TutorSubjects)
//                    .HasForeignKey(d => d.TutorId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tutor_subjects_tutor");
//            });
//        }
//    }
//}