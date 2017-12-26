using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class ScheduleBlocks
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public AppUsers CreatedByNavigation { get; set; }
        public AppUsers ModifiedByNavigation { get; set; }
    }
}
