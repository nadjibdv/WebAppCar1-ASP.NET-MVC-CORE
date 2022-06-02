using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCar1.Models
{
    public class Person
    {
        [Key]
        [DisplayName("ID")]
        public int person_ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("FirstName")]
        public string person_FName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("LastName")]
        public string person_LName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Phone")]
        public string person_Phone { get; set; }
    }
}
