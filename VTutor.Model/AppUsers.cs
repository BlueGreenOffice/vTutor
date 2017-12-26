using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class AppUsers
    {
        public AppUsers()
        {
            AppUserPasswordsCreatedByNavigation = new HashSet<AppUserPasswords>();
            AppUserPasswordsModifiedByNavigation = new HashSet<AppUserPasswords>();
            AppointmentsCreatedByNavigation = new HashSet<Appointments>();
            AppointmentsModifiedByNavigation = new HashSet<Appointments>();
            GradesCreatedByNavigation = new HashSet<Grades>();
            GradesModifiedByNavigation = new HashSet<Grades>();
            InverseCreatedByNavigation = new HashSet<AppUsers>();
            InverseModifiedByNavigation = new HashSet<AppUsers>();
            ScheduleBlocksCreatedByNavigation = new HashSet<ScheduleBlocks>();
            ScheduleBlocksModifiedByNavigation = new HashSet<ScheduleBlocks>();
            StudentsAppUser = new HashSet<Students>();
            StudentsCreatedByNavigation = new HashSet<Students>();
            StudentsModifiedByNavigation = new HashSet<Students>();
            SubjectsCreatedByNavigation = new HashSet<Subjects>();
            SubjectsModifiedByNavigation = new HashSet<Subjects>();
            TutorSchedulesCreatedByNavigation = new HashSet<TutorSchedules>();
            TutorSchedulesModifiedByNavigation = new HashSet<TutorSchedules>();
            TutorSubjectsCreatedByNavigation = new HashSet<TutorSubjects>();
            TutorSubjectsModifiedByNavigation = new HashSet<TutorSubjects>();
            TutorsAppUser = new HashSet<Tutors>();
            TutorsCreatedByNavigation = new HashSet<Tutors>();
            TutorsModifiedByNavigation = new HashSet<Tutors>();
        }

        public Guid Id { get; set; }
        public Guid AppUserPasswordId { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public AppUserPasswords AppUserPassword { get; set; }
        public AppUsers CreatedByNavigation { get; set; }
        public AppUsers ModifiedByNavigation { get; set; }
        public ICollection<AppUserPasswords> AppUserPasswordsCreatedByNavigation { get; set; }
        public ICollection<AppUserPasswords> AppUserPasswordsModifiedByNavigation { get; set; }
        public ICollection<Appointments> AppointmentsCreatedByNavigation { get; set; }
        public ICollection<Appointments> AppointmentsModifiedByNavigation { get; set; }
        public ICollection<Grades> GradesCreatedByNavigation { get; set; }
        public ICollection<Grades> GradesModifiedByNavigation { get; set; }
        public ICollection<AppUsers> InverseCreatedByNavigation { get; set; }
        public ICollection<AppUsers> InverseModifiedByNavigation { get; set; }
        public ICollection<ScheduleBlocks> ScheduleBlocksCreatedByNavigation { get; set; }
        public ICollection<ScheduleBlocks> ScheduleBlocksModifiedByNavigation { get; set; }
        public ICollection<Students> StudentsAppUser { get; set; }
        public ICollection<Students> StudentsCreatedByNavigation { get; set; }
        public ICollection<Students> StudentsModifiedByNavigation { get; set; }
        public ICollection<Subjects> SubjectsCreatedByNavigation { get; set; }
        public ICollection<Subjects> SubjectsModifiedByNavigation { get; set; }
        public ICollection<TutorSchedules> TutorSchedulesCreatedByNavigation { get; set; }
        public ICollection<TutorSchedules> TutorSchedulesModifiedByNavigation { get; set; }
        public ICollection<TutorSubjects> TutorSubjectsCreatedByNavigation { get; set; }
        public ICollection<TutorSubjects> TutorSubjectsModifiedByNavigation { get; set; }
        public ICollection<Tutors> TutorsAppUser { get; set; }
        public ICollection<Tutors> TutorsCreatedByNavigation { get; set; }
        public ICollection<Tutors> TutorsModifiedByNavigation { get; set; }
    }
}
