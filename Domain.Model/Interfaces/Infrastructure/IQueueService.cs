﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Infrastructure
{
    public  interface IQueueService
    {
        Task SendAsync(string messageText);
    }
}
