﻿using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface ITenderService
    {
        public List<Tender> GetAllTenders();
        public Tender AddTender(Tender tender);
        public Tender GetTender(long id);
        public List<Medication> GetTenderMedications(long id);
		public Tender UpdateWinner(long idWinner);
        public Tender DeleteTender(long id);
    }
}
