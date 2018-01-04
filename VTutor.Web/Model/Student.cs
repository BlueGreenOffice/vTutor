using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class Student
    {
        public Guid Id { get; set; }

        
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
