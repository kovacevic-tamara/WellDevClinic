﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WellDevCore.Model.Adapters;
using WellDevCore.Model.dtos;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("{id?}")]
        public Patient GetPatientById(long id)
        {
            Patient patient = _patientService.Get(id);
            patient.Id = id;
            return patient;
        }

        [HttpGet]
        [Route("patients_for_blocking")]
        public List<PatientDTO> GetPatientsForBlocking()
        {
            List<Patient> patients = _patientService.GetPatientsForBlocking();
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                result.Add(PatientAdapter.PatientToPatientDTO(patient));
            }
            return result;
        }

        [HttpGet]
        [Route("blocked_patients")]
        public List<PatientDTO> GetBlockedPatients()
        {
            List<Patient> patients = _patientService.GetBlockedPatients();
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                result.Add(PatientAdapter.PatientToPatientDTO(patient));
            }
            return result;
        }

        [HttpPut]
        [Route("{id?}")]
        public void BlockPatient(long id)
        {
            Patient patient = _patientService.Get(id);
            patient.Blocked = true;
            _patientService.Edit(patient);
        }

    }
}
