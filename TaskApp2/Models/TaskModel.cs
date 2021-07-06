using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskApp2.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }

       
        [Display(Name = "Название задачи*")]
        public string TaskName { get; set; }

        [Display(Name = "Описание задачи")]
        [DataType(DataType.MultilineText)]
        public string TaskDescription { get; set; }

        public int TaskLeigth { get; set; }

      
        [Display(Name = "Дата начала задачи")]
        [DataType(DataType.Date)]
        public DateTime TaskBegin { get; set; }

        [Display(Name = "Дата окончания задачи")]
        [DataType(DataType.Date)]
        public DateTime TaskEnd { get; set; }



    }
}