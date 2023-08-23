using ExelFlightSheet.Dto;
using ExelFlightSheet.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExelFlightSheet.Builder
{
    public static class ExelBuilder
    {
        private static StringBuilder _logBuilder = new();
        public static void BuildInThisLocation(string filePath, IEnumerable<ExelDto> myFlights)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage();
                var sheet = package.Workbook.Worksheets.Add("Sheet1");
                sheet.Cells["A1"].Value = "Id Del Volo";
                sheet.Cells["B1"].Value = "Ora Di Arrivo";
                sheet.Cells["C1"].Value = "Città Di Partenza";
                sheet.Cells["D1"].Value = "Città Di Arrivo";
                sheet.Cells["E1"].Value = "Tipologia Di Aereo";
                sheet.Cells["F1"].Value = "Numero Di Passeggeri";
                int row = 2;
                foreach (var flight in myFlights)
                {
                    sheet.Cells[$"A{row}"].Value = flight.idVolo;
                    sheet.Cells[$"B{row}"].Style.Numberformat.Format = "yyyy-mm-dd";
                    sheet.Cells[$"B{row}"].Value = GetExcelDecimalValueForDate(flight.oraArrivo);
                    sheet.Cells[$"C{row}"].Value = flight.cittaPartenza;
                    sheet.Cells[$"D{row}"].Value = flight.cittaArrivo;
                    sheet.Cells[$"E{row}"].Value = flight.TipoAereo;
                    sheet.Cells[$"F{row}"].Value = flight.NumPasseggeri;
                    row++;
                }
                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                sheet.Cells.AutoFitColumns();
                var finalLocation = filePath;
                package.SaveAs(new FileInfo(filePath));
                Log($"Excel file successfully created at: {finalLocation}");
            }
            catch (Exception ex)
            {
                LogError($"Error while creating Excel file: {ex.Message}");
            }
        }
        private static decimal GetExcelDecimalValueForDate(DateTime date)
        {
            DateTime start = new DateTime(1900, 1, 1);
            TimeSpan diff = date - start;
            return diff.Days + 2;
        }
        private static void Log(string message)
        {
            Console.WriteLine(message);
            _logBuilder.AppendLine(message);
        }
        private static void LogError(string errorMessage)
        {
            Console.Error.WriteLine(errorMessage);
            _logBuilder.AppendLine($"ERROR: {errorMessage}");
        }
        public static string GetLog()
        {
            return _logBuilder.ToString();
        }
    }
}
