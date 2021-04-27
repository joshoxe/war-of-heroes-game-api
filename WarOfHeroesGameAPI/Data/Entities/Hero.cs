namespace WarOfHeroesGameAPI.Data.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttackDamage { get; set; }
        public string UltimateAttackName { get; set; }
        public int UltimateAttackDamage { get; set; }
        public string Description { get; set; }
    }
}