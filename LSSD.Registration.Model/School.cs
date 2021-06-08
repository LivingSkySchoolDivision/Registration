using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class School : IGUIDable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Communities { get; set; }
        public string WebsiteURL { get; set; }
        public  string EmailAddress { get; set; }
        public Address MailingAddress { get; set; }
        public Address PhysicalAddress { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string DAN { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool HasGradePK { get; set; }
        public bool HasGradeK { get; set; }
        public bool HasGrade1 { get; set; }
        public bool HasGrade2 { get; set; }
        public bool HasGrade3 { get; set; }
        public bool HasGrade4 { get; set; }
        public bool HasGrade5 { get; set; }
        public bool HasGrade6 { get; set; }
        public bool HasGrade7 { get; set; }
        public bool HasGrade8 { get; set; }
        public bool HasGrade9 { get; set; }
        public bool HasGrade10 { get; set; }
        public bool HasGrade11 { get; set; }
        public bool HasGrade12 { get; set; }
        public bool IsAvailableForRegistration { get; set; }
        public int SchoolLogicSchoolID { get; set; }
        public bool ShowStVitalExtraRequirements { get; set; }

        public void SetGradesOffered(
            bool PK,
            bool K,
            bool Gr1,
            bool Gr2,
            bool Gr3,
            bool Gr4,
            bool Gr5,
            bool Gr6,
            bool Gr7,
            bool Gr8,
            bool Gr9,
            bool Gr10,
            bool Gr11,
            bool Gr12
            )
        {
            this.HasGradePK = PK;
            this.HasGradeK = K;
            this.HasGrade1 = Gr1;
            this.HasGrade2 = Gr2;
            this.HasGrade3 = Gr3;
            this.HasGrade4 = Gr4;
            this.HasGrade5 = Gr5;
            this.HasGrade6 = Gr6;
            this.HasGrade7 = Gr7;
            this.HasGrade8 = Gr8;
            this.HasGrade9 = Gr9;
            this.HasGrade10 = Gr10;
            this.HasGrade11 = Gr11;
            this.HasGrade12 = Gr12;
        }

        public List<string> GetGradesOffered()
        {
            List<string> returnMe = new List<string>();
            if (this.HasGradePK) { returnMe.Add(FormDefaults.Language_Grade_PK); }
            if (this.HasGradeK) { returnMe.Add(FormDefaults.Language_Grade_K); }
            if (this.HasGrade1) { returnMe.Add(FormDefaults.Language_Grade_1); }
            if (this.HasGrade2) { returnMe.Add(FormDefaults.Language_Grade_2); }
            if (this.HasGrade3) { returnMe.Add(FormDefaults.Language_Grade_3); }
            if (this.HasGrade4) { returnMe.Add(FormDefaults.Language_Grade_4); }
            if (this.HasGrade5) { returnMe.Add(FormDefaults.Language_Grade_5); }
            if (this.HasGrade6) { returnMe.Add(FormDefaults.Language_Grade_6); }
            if (this.HasGrade7) { returnMe.Add(FormDefaults.Language_Grade_7); }
            if (this.HasGrade8) { returnMe.Add(FormDefaults.Language_Grade_8); }
            if (this.HasGrade9) { returnMe.Add(FormDefaults.Language_Grade_9); }
            if (this.HasGrade10) { returnMe.Add(FormDefaults.Language_Grade_10); }
            if (this.HasGrade11) { returnMe.Add(FormDefaults.Language_Grade_11); }
            if (this.HasGrade12) { returnMe.Add(FormDefaults.Language_Grade_12); }
            return returnMe;
        }

        public string GetGradesOfferedShort()
        {
            List<string> gradesOffered = this.GetGradesOffered();
            if (gradesOffered.Count > 0)
            {
                // Since we add them in order in the above method, we can just grab the 
                // first and last items in the list
                string lowGrade = gradesOffered[0];
                string highGrade = gradesOffered[gradesOffered.Count-1];

                return lowGrade + " to " + highGrade;
            } else
            {
                return "None";
            }
        }


    }
}
