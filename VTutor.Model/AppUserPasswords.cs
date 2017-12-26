using System;
using System.Collections.Generic;

namespace VTutor.Model
{
    public partial class AppUserPasswords
    {
        public AppUserPasswords()
        {
            AppUsers = new HashSet<AppUsers>();
        }

        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public AppUsers CreatedByNavigation { get; set; }
        public AppUsers ModifiedByNavigation { get; set; }
        public ICollection<AppUsers> AppUsers { get; set; }
    }
}
