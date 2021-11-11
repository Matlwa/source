using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class ProvinceLookpmodel
    {
        public int Id { get; set; }
        public string Province { get; set; }

        public ProvinceLookpmodel()
        {
            Province = string.Empty;
            Id = 0;
        }
    }
}
