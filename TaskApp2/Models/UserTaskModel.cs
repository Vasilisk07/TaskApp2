using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskApp2.Models
{
    public class UserTaskModel
    {
        public int myTaskId { get; set; }

        [Display(Name = "Название задачи")]
        public string TaskName { get; set; }
        [Display(Name = "Коментарии")]
        public string TaskInfo { get; set; }
        [Display(Name = "Затрачено часов")]
        public string TaskTime { get; set; }


    }
}