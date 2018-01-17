using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VTutor.Model
{
    public class VTutorContext : IdentityDbContext<ApplicationUser>
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
