﻿using NetApiWithDocker.Hypermedia;
using NetApiWithDocker.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Data.VO
{
    public class PersonVO : ISuportHyperMediaLink
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string Address { get; set; }

        
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
