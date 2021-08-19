using System.ComponentModel.DataAnnotations.Schema;

namespace WarOfHeroesGameAPI.Data.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AbilityId { get; set; }
        public virtual Ability Ability { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}