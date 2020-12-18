﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/grpc")]
    public class GrpcController : ControllerBase
    {
        ClientService serviceGrpc;
        public GrpcController() 
        {
            serviceGrpc = new ClientService();
        }

        [HttpPost]
        [Route("{name?}")]
        public async Task<IActionResult> ExistMedicationByName(string name)
            => Ok(await serviceGrpc.SendMessage(name));

    }
}
