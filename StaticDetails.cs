namespace SignalRSample
{
    public static class StaticDetails
    {
        static StaticDetails()
        {
            DeathlyHollowRace = new Dictionary<string, int>();
            DeathlyHollowRace.Add(Cloak, 0);
            DeathlyHollowRace.Add(Wand, 0);
            DeathlyHollowRace.Add(Stone, 0);
        }

        public const string Wand = "wand";
        public const string Stone = "stone";
        public const string Cloak = "cloak";
        public static Dictionary<string, int> DeathlyHollowRace;
    }
}
