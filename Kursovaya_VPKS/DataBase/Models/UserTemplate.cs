using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class UserTemplate
    {
        public long Id { get; set; }
        public long? TemplateId { get; set; }
        public long? UserId { get; set; }

        public virtual Template Template { get; set; }
        public virtual Users User { get; set; }
    }
}
