using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class TemplateDocumentData
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public long TemplateObjectId { get; set; }
        public long TemplateDocumentId { get; set; }

        public virtual TemplateDocument TemplateDocument { get; set; }
        public virtual TemplateObject TemplateObject { get; set; }
    }
}
