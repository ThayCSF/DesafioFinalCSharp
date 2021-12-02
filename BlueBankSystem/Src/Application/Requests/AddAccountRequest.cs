﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.System.Application.Requests
{
    public class AddAccountRequest
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}
