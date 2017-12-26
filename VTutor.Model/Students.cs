using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class Students
    {
        public Students()
        {
            Appointments = new HashSet<Appointments>();
        }

        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public AppUsers AppUser { get; set; }
        public AppUsers CreatedByNavigation { get; set; }
        public AppUsers ModifiedByNavigation { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
    }
}
