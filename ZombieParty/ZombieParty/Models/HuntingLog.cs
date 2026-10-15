namespace ZombieParty.Models
{
    public class HuntingLog
    {
        public int Id { get; set; }

        public List<Zombie> Zombies { get; set; } = new();
    }
}
