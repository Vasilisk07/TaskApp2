using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskApp2.Models
{
    public class ChangesTaskModel
    {
        [HiddenInput]
        public int IdChengTask { get; set; }
        [Display(Name = "Затраченое время")]
        [DataType(DataType.Duration)]
        public int Time { get; set; }
        [Display(Name = "Коментарий")]
        [DataType(DataType.MultilineText)]
        public string Comit { get; set; }




    }
}