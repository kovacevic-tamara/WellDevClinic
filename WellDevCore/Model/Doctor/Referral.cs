

using Model.PatientSecretary;
using Repository;
using System;

namespace Model.Doctor
{
   public class Referral : IIdentifiable<long>
   {
        public long Id { get; set; }
        public virtual Period Period { get; set; }
        public virtual Model.Users.Doctor Doctor { get; set; }
        public String Text { get; set; }

        public Referral() { }

        public Referral(long id)
        {
            Id = id;
        }

        public Referral(long id,Period period, Users.Doctor doctor)
        {
            Period = period;
            Doctor = doctor;
            Id = id;
        }

        public Referral(Period period, Users.Doctor doctor)
        {
            Period = period;
            Doctor = doctor;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}