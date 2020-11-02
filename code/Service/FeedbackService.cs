﻿using bolnica.Model.Users;
using bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository = new FeedbackRepository();

        public FeedbackService()
        {
            
        }

        public List<Feedback> GetAllFeedback()
        {
            return (List<Feedback>)_feedbackRepository.GetAll();
        }

        public Feedback GetFeedback(long id)
        {
            return _feedbackRepository.Get(id);
        }

        public Feedback LeaveFeedback(Feedback feedback)
        {
            return _feedbackRepository.Save(feedback);
        }

        public void PublishFeedback(Feedback feedback)
        {
            _feedbackRepository.Edit(feedback);
        }
    }
}
