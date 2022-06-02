using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCar1.Models.ViewModels
{
    public class CarViewMoels2
    {
        [Key]
        [DisplayName("ID")]
        public int car_ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Name Car")]
        public string car_Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Plate Car")]
        public string car_Plate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Photo")]
        public string car_ImageUrl { get; set; }

     



        public List<Person> car_Person_List;



        [DisplayName("List Person")]
        public int person_ID { get; set; }


       
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile car_File { get; set; }

       

    }
}
