using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryQuest.Models
{
    public class LessonsResponse
    {
        public Guid Id { get; set; }


        public string Title { get; set; }

        public string Content { get; set; }

       

        public Guid ClassHistoryId { get; set; }

     
        
    }

}
