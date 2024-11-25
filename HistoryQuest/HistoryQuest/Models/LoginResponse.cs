using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryQuest.Models
{
    public class LoginResponse
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public object data { get; set; }
    }
}
