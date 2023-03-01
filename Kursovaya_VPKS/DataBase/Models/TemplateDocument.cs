using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class TemplateDocument
    {
        public TemplateDocument()
        {
            TemplateDocumentData = new HashSet<TemplateDocumentData>();
        }

        public long Id { get; set; }
        public long TemplateId { get; set; }

        public virtual Template Template { get; set; }
        public virtual ICollection<TemplateDocumentData> TemplateDocumentData { get; set; }
    }
}
