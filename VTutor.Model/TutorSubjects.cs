using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class TutorSubjects
    {
        public Guid Id { get; set; }
        public Guid TutorId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid GradeId { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public AppUsers CreatedByNavigation { get; set; }
        public Grades Grade { get; set; }
        public AppUsers ModifiedByNavigation { get; set; }
        public Subjects Subject { get; set; }
        public Tutors Tutor { get; set; }
    }
}
