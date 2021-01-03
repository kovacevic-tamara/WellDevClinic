﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Controller;
using bolnica.Model.Adapters;
using bolnica.Model.dtos;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using WellDevCore.Model.Dto;
using WellDevCore.Model.dtos;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationController _examinationController;
        private readonly IBusinessDayController _businessDayController;

        public ExaminationController(IExaminationController examinationController, IBusinessDayController businessDayController)
        {
            _examinationController = examinationController;
            _businessDayController = businessDayController;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetFinishedExaminations()
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationController.GetAllPrevious();
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return Ok(resultDto);
        }

        [HttpPut]
        [Route("{id?}")]
        public void FillSurvey(long id)
        {
            Examination entity = _examinationController.GetPrevious(id);
            entity.FilledSurvey = true;
            _examinationController.EditPrevious(entity);

        }

        [HttpPut]
        [Route("canceled/{id?}")]
        public void CancelExamination(long id)
        {
            Examination entity = _examinationController.Get(id);
            entity.Canceled = true;
            entity.CanceledDate = DateTime.Now;
            _examinationController.Edit(entity);
        }

        [HttpGet]
        [Route("{id?}")]
        public List<ExaminationDto> GetFinishedExaminationsByUser(long id)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationController.GetFinishedExaminationsByUser(id);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationPreviousToExaminationDto(examination));
            }
            return resultDto;
        }

        [HttpGet]
        [Route("upcoming/{id?}")]
        public List<ExaminationDto> GetUpcomingExaminationsByUser(long id)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationController.GetUpcomingExaminationsByUser(id);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationUpcomingToExaminationDto(examination));
            }
            return resultDto;
        }
        /// <summary>
        ///  calls GetFinishedExaminationsByUser(User user) method from class ExaminationService so  
        /// it can get examinations of specified user
        /// </summary>
        /// <param name="user">specified user</param>
        /// <returns>status 200 OK response with a list of examinations mapped to ExaminationDto</returns>
        [HttpGet]
        [Route("getByUser/{id?}")]
        public List<ExaminationDto> GetFinishedExaminationDocumentsByUser(long id)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationController.GetFinishedExaminationsByUser(id);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return resultDto;
        }

        [HttpPost]
        [Route("newExamination")]
        public Examination NewExamination([FromBody] ExaminationDTO examination) 
        {
            Examination retVal = _examinationController.NewExamination(examination.Doctor.Id, examination.Period, examination.Patient.Id);
            List<Period> peridos = new List<Period>();
            peridos.Add(examination.Period);
            BusinessDay day = _businessDayController.GetExactDay(examination.Doctor, examination.Period.StartDate);
            _businessDayController.MarkAsOccupied(peridos, day);
            return retVal;
        }

        /*[HttpPost]
        [Route("newExamination")]
        public Examination NewExamination([FromBody] ExaminationIdsDTO examination)
        {
            Examination retVal = _examinationController.NewExamination(examination.DoctorId, examination.Period, examination.PatientId);
           
            return retVal;
        }*/

        [HttpGet]
        [Route("getAllUpcoming")]
        public List<Examination> GetAllUpcomingExaminations()
        {
            List<Examination> result = (List<Examination>)_examinationController.GetAllUpcomingExaminations();

            return result;
        }
    }
}
