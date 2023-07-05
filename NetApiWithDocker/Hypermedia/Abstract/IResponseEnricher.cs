﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool canEnrich(ResultExecutedContext context);
        Task Enrich(ResultExecutedContext context);
    }
}
