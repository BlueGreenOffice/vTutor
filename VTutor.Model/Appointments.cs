using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class Appointments
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid TutorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public AppUsers CreatedByNavigation { get; set; }
        public AppUsers ModifiedByNavigation { get; set; }
        public Students Student { get; set; }
        public Tutors Tutor { get; set; }
    }
}
