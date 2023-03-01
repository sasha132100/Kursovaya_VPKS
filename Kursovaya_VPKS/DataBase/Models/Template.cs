using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class Template
    {
        public Template()
        {
            TemplateDocument = new HashSet<TemplateDocument>();
            TemplateObject = new HashSet<TemplateObject>();
            UserTemplate = new HashSet<UserTemplate>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<TemplateDocument> TemplateDocument { get; set; }
        public virtual ICollection<TemplateObject> TemplateObject { get; set; }
        public virtual ICollection<UserTemplate> UserTemplate { get; set; }
    }
}
