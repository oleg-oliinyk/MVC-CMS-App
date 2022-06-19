using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_CMS_App.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Patients = new HashSet<Patients>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string Specialist { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }

        public virtual ICollection<Patients> Patients { get; set; }
    }
}
