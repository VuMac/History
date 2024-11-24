using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryQuest.HTTP
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        public CustomHttpClientHandler()
        {
            // Bỏ qua xác minh chứng chỉ
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        }
    }
}
