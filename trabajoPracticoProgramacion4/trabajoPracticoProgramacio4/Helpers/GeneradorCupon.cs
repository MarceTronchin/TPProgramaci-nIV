using System;

namespace trabajoPracticoProgramacion4.Helpers
{
    public static class GeneradorCupon
    {
        public static string GenerarCupon()
        {
            var codRandom = new Random();

            return $"{codRandom.Next(100, 999)}-{codRandom.Next(100, 999)}-{codRandom.Next(100, 999)}";
        }
    }
}