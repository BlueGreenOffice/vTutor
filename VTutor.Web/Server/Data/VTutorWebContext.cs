using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VTutor.Model;

namespace VTutor.Web.Server.Data
{
    public class VTutorWebContext : DbContext
    {
        public VTutorWebContext (DbContextOptions<VTutorWebContext> options)
            : base(options)
        {
        }

        public DbSet<VTutor.Model.Subject> Subject { get; set; }

        public DbSet<VTutor.Model.Appointment> Appointment { get; set; }

        public DbSet<VTutor.Model.Grade> Grade { get; set; }

        public DbSet<VTutor.Model.ScheduleBlock> ScheduleBlock { get; set; }

        public DbSet<VTutor.Model.Student> Student { get; set; }

        public DbSet<VTutor.Model.Tutor> Tutor { get; set; }

        public DbSet<VTutor.Model.TutorSchedule> TutorSchedule { get; set; }

        public DbSet<VTutor.Model.TutorSubject> TutorSubject { get; set; }
    }
}
