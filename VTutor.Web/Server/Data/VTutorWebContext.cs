using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VTutor.Web.Server.Data
{
    public class VTutorWebContext : DbContext
    {
        public VTutorWebContext (DbContextOptions<VTutorWebContext> options)
            : base(options)
        {
        }

    public DbSet<VTutor.Model.Subjects> Subjects { get; set; }

    public DbSet<VTutor.Model.Appointments> Appointments { get; set; }

    public DbSet<VTutor.Model.Grades> Grades { get; set; }

    public DbSet<VTutor.Model.ScheduleBlocks> ScheduleBlocks { get; set; }

    public DbSet<VTutor.Model.Students> Students { get; set; }

    public DbSet<VTutor.Model.Tutors> Tutors { get; set; }

    public DbSet<VTutor.Model.TutorSchedules> TutorSchedules { get; set; }

    public DbSet<VTutor.Model.TutorSubjects> TutorSubjects { get; set; }
  }
}
