﻿using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository.Abstract
{
    public interface IExaminationRepository : ICRUD<Examination,long> 
    {
    }
}
