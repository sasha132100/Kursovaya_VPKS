using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class Items
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public long Priority { get; set; }
        public long IsHiden { get; set; }
        public long IsSelected { get; set; }
        public string DateCreation { get; set; }
        public long? FolderId { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual Inn Inn { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual Polis Polis { get; set; }
        public virtual Snils Snils { get; set; }
    }
}
