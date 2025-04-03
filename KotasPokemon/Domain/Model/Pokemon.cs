namespace Domain.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Variation> Variations { get; set; }
        public string Link { get; set; }
        public bool Captured { get; set; }
    }

    public class Stats
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpeedAttack { get; set; }
        public int SpeedDefense { get; set; }
        public int Speed { get; set; }
    }

    public class Variation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageBase64 { get; set; }
        public List<string> Types { get; set; }
        public string Specie { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public List<string> Abilities { get; set; }
        public Stats Stats { get; set; }
        public List<string> Evolutions { get; set; }
    }
}
