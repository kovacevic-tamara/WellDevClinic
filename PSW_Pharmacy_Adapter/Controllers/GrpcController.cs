﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController : ControllerBase
    {
        private readonly GrpcClientService _serviceGrpc;

        public GrpcController() 
        {
            _serviceGrpc = new GrpcClientService();
        }

        [HttpGet]          
        [Route("available/{medicationName?}/{pharmacyName?}")]
        public async Task<IActionResult> IsAvailableMedication(string medicationName, string pharmacyName)
        {
            int amount = await _serviceGrpc.SendMessage(medicationName, pharmacyName);
            if(amount >= -1)
                return Ok(amount);
            return StatusCode(408, Global.ErrorMessage);
        }
            

        [HttpGet]
        [Route("medications/{pharmacyname?}")]
        public async Task<IActionResult> GetMedications(string pharmacyname)
        {
            List<Medication> meds = await _serviceGrpc.GetMedications(pharmacyname);
            if(meds != null)
                return Ok(meds);
            return StatusCode(408, Global.ErrorMessage);
        }
            

    }
}
