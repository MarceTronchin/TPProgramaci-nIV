namespace trabajoPracticoProgramacion4.Helpers
{
    public static class GeneradorCupon
    {
        public static string GenerarCupon()
        {
            Random codRandom = new Random();

            int part1 = random.Next(100, 1000);
            int part2 = random.Next(100, 1000);
            int part3 = random.Next(100, 1000);

            return $"{part1}-{part2}-{part3}";
        }
    }
}

