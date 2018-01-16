using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class Tutor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }



        public ApplicationUser User { get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}

