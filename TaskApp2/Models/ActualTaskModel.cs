using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskApp2.Models
{
    public class ActualTaskModel
    {
        [Key]
        public int ActualTaskId { get; set; }
        [Display(Name = "Затраченное время")]
        [DataType(DataType.Duration)]
        public int ActTaskLeigth { get; set; }
        [Display(Name = "Коментарий")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string UserName { get; set; }
        public string TaskName { get; set; }
        public int TaskId { get; set; }
    }
}