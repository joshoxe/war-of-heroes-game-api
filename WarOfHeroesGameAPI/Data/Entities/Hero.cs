namespace WarOfHeroesGameAPI.Data.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ability Ability { get; set; }
        public string Description { get; set; }
    }
}