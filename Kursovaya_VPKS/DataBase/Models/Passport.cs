using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class Passport
    {
        public long Id { get; set; }
        public string SeriaNumber { get; set; }
        public string Fio { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string ResidencePlace { get; set; }
        public string ByWhom { get; set; }
        public string DivisionCode { get; set; }
        public string GiveDate { get; set; }
        public string FacePhoto { get; set; }
        public string PhotoPage1 { get; set; }
        public string PhotoPage2 { get; set; }

        public virtual Items IdNavigation { get; set; }
    }
}
