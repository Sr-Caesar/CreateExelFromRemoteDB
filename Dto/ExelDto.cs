using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExelFlightSheet.Dto
{
    public class ExelDto
    {
        public int idVolo { set; get; }
        public DateTime oraArrivo { set; get; }
        public string cittaPartenza { set; get; }
        public string cittaArrivo { set; get; }
        public string TipoAereo { set; get; }
        public int NumPasseggeri { set; get; }
    }
}
