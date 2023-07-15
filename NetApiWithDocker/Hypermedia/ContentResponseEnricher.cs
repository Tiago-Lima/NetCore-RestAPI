using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using NetApiWithDocker.Hypermedia.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Hypermedia
{
    public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISuportHyperMediaLink
    {
        public ContentResponseEnricher()
        {

        }
        public bool canEnrich(Type contentType)
        {
            return contentType == typeof(T) || contentType==typeof(List<T>);
        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

        bool IResponseEnricher.canEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult oKobjectResult)
            {
                return canEnrich(oKobjectResult.Value.GetType());
            }
            return false;
        }
        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is OkObjectResult oKobjectResult)
            {
                if (oKobjectResult.Value is T model)
                {
                    await EnrichModel(model, urlHelper);
                }

                else if (oKobjectResult.Value is List<T> collection)
                {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                    Parallel.ForEach(bag, (element) =>
                     {
                         EnrichModel(element, urlHelper);
                     });

                }
            }
            await Task.FromResult<object>(null);
        }

    }
}
