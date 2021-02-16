﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public CloudMailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"From {_configuration["mailSettings:mailFromAddress"]} to {_configuration["mailSettings:mailToAddress"]}");
            Debug.WriteLine($"Subject {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
