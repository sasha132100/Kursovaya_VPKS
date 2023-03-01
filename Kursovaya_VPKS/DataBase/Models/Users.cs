using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class Users
    {
        public Users()
        {
            Items = new HashSet<Items>();
            Template = new HashSet<Template>();
            UserTemplate = new HashSet<UserTemplate>();
        }

        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PremiumStatus { get; set; }
        public string Syncing { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Template> Template { get; set; }
        public virtual ICollection<UserTemplate> UserTemplate { get; set; }
    }
}
