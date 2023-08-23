using ExelFlightSheet.Dto;
using ExelFlightSheet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExelFlightSheet.Gateway
{
    public class GatewayFlight : IGateway
    {
        private readonly TestContext _context;
        private readonly StringBuilder _logBuilder;
        public GatewayFlight(TestContext context)
        {
            _context = context;
            _logBuilder = new StringBuilder();
        }
        public IEnumerable<ExelDto>? GetFlightFromItatoDeus()
        {
            Log("Getting flights from Italy to Germany...");
            try
            {
                var flights = _context.Volo
                    .Include(x => x.CittapartNavigation)
                    .Include(x => x.CittaarrNavigation)
                    .Where(x => x.CittapartNavigation.Nazione == "ITA" && x.CittaarrNavigation.Nazione == "DEU")
                    .Join(
                        _context.Aereo,
                        volo => volo.Tipoaereo,
                        aereo => aereo.Tipoaereo,
                        (volo, aereo) => new ExelDto
                        {
                            idVolo = volo.Id,
                            oraArrivo = volo.Oraarr,
                            cittaPartenza = volo.Cittapart,
                            cittaArrivo = volo.Cittaarr,
                            TipoAereo = volo.Tipoaereo,
                            NumPasseggeri = aereo.Numpasseggeri
                        })
                    .ToList();
                Log($"Found {flights.Count()} flights.");
                return flights;
            }
            catch (System.InvalidOperationException ex)
            {
                Log($"Invalid Operation Exception occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log($"Generic Exception occurred: {ex.Message}");
            }
            return null;
        }
        private void Log(string message)
        {
            Console.WriteLine(message);
            _logBuilder.AppendLine(message);
        }
        public string GetLog()
        {
            return _logBuilder.ToString();
        }
    }
}
