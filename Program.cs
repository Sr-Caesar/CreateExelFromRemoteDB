using ExelFlightSheet;
using ExelFlightSheet.Builder;
using ExelFlightSheet.Gateway;
using ExelFlightSheet.Models;
using System;
using System.IO;

try
{
    Luncher.Run();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"An error occurred: {ex.Message}");
}
