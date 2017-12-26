using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class Subjects
    {
        public Subjects()
        {
            TutorSubjects = new HashSet<TutorSubjects>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public AppUsers CreatedByNavigation { get; set; }
        public AppUsers ModifiedByNavigation { get; set; }
        public ICollection<TutorSubjects> TutorSubjects { get; set; }
    }
}
