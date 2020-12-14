﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Allergy
    {
     

        public long Id { set; get; }
        public string Name { set; get; }

        public Allergy(){}
        public Allergy(long id, string name)
        {
            Id = id;
            Name = name;
        }

        
    }
}
