﻿using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.System.Application.Interfaces
{
    interface IRemoveCustomerByIdCommand : IHandler<RemoveCustomerByIdRequest, RemoveCustomerByIdResponse>
    {
    
    }
}
