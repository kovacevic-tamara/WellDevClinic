﻿using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class DirectorAppService : IDirectorAppService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorAppService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void Delete(Director entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Director entity)
        {
            throw new NotImplementedException();
        }

        public Director Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetAll()
        {
            throw new NotImplementedException();
        }

        public Director Save(Director entity)
        {
            return _directorRepository.Save(entity);
        }
    }
}
