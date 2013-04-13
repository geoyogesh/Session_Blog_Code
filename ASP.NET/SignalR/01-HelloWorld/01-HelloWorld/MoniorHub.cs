﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace _01_HelloWorld
{
    [HubName("Monitor")]
    public class MoniorHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}