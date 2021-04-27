using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WarOfHeroesGameAPI
{
    public class HeroesRequest
    {
        [JsonPropertyName("heroIds")] public IEnumerable<int> HeroIds { get; set; }
    }
}