using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApiWithDocker.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }

        private string href; 
        public string Href { // O dotnet tende a substituir o cractere "/" por %2f . O link funcionaria mas ficaria um pouco estranho, por isso criei a propriedade href para fazer esse tratamento
            get
            {
                object _lock = new object();
                lock(_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set
            {
                href = value;
            }
        }
        public string Type { get; set; }
        public string Action { get; set; }

    }
}
