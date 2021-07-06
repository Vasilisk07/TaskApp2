using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskApp2.Models
{
    public class CurentTaskModel
    {
        [Display(Name = "Название задачи")]
        public string TaskName { get; set; }

        [Display(Name = "Краткое описание")]
        public string TasDesc { get; set; }

        [Display(Name = "Дата начала")]
        public string TaskBegin { get; set; }

        [Display(Name = "Дата окончания")]
        public string TaskEnd { get; set; }

        [Display(Name = "Затраченое время")]
        public string TaskLeight { get; set; }

        [Display(Name = "Исполнители")]
        public List<string> users { get; set; }






    }
}