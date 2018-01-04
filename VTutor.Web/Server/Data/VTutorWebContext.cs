//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

//namespace VTutor.Web.Server.Data
//{
//    public class VTutorWebContext : DbContext
//    {
//        public VTutorWebContext (DbContextOptions<VTutorWebContext> options)
//            : base(options)
//        {
//        }

//    public DbSet<VTutor.Model.Subject> Subjects { get; set; }

//    public DbSet<VTutor.Model.Appointment> Appointments { get; set; }

//    public DbSet<VTutor.Model.Grade> Grades { get; set; }

//    public DbSet<VTutor.Model.ScheduleBlock> ScheduleBlocks { get; set; }

//    public DbSet<VTutor.Model.Student> Students { get; set; }

//    public DbSet<VTutor.Model.Tutor> Tutors { get; set; }

//    public DbSet<VTutor.Model.TutorSchedule> TutorSchedules { get; set; }

//  }
//}
