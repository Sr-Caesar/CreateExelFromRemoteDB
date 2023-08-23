using ExelFlightSheet.Dto;
using ExelFlightSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExelFlightSheet.Gateway
{
    public interface IGateway
    {
        public IEnumerable<ExelDto> GetFlightFromItatoDeus();
        public string GetLog();
    }
}
