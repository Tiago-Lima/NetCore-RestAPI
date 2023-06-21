using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Data.Converter.Contract
{
    public interface IParser<O, D> //Origem e Destino
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
