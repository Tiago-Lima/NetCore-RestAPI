﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Hypermedia.Abstract
{
    public interface ISuportHyperMediaLink
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
