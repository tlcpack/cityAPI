using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "admin@co.com";
        private string _mailFrom = "noreply@co.com";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"From {_mailFrom} to {_mailTo}");
            Debug.WriteLine($"Subject {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
