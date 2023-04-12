using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_Console_App
{
     class tasks
    {
        public int taskId;
        public string Title { get; set;}
        public string Description { get; set; }
        public bool isCompleted { get; set; }
        public int UserId { get; set; }




        private static int task_id = 0;
        public tasks(string title, string description, bool isCompleted, user assignedUser)
        {
            Title = title;
            Description = description;
            this.isCompleted = isCompleted;
            UserId = assignedUser.UserId;
            taskId = ++task_id ;
        }
    }
}
