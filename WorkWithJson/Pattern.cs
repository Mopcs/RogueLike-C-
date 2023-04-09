using Newtonsoft.Json;

namespace Game_Zodiac._Pattern
{
    public class Pattern
    {

        [JsonProperty("Art")]

        public string[] Art { get; set; }

        [JsonProperty("Fire")]

        public string[] Fire { get; set; }

        [JsonProperty("Libra")]

        public string[] Libra { get; set; }

        [JsonProperty("Aquarius")]

        public string[] Aquarius { get; set; }


        [JsonProperty("Arias")]
        public string[] Arias { get; set; }

        [JsonProperty("Cancer")]
        public string[] Cancer { get; set; }

        [JsonProperty("Capricorn")]
        public string[] Capricorn { get; set; }

        [JsonProperty("Earth")]
        public string[] Earth { get; set;}

        [JsonProperty("Gemini")]
        public string[] Gemini { get; set;}

        [JsonProperty("Leo")]
        public string[] Leo { get; set; }

        [JsonProperty("Pisces")]
        public string[] Pisces { get; set;}

        [JsonProperty("Sagittarius")]
        public string[] Sagittarius { get; set; }

        [JsonProperty("Scorpio")]
        public string[] Scorpio { get; set; }

        [JsonProperty("Taurus")]
        public string[] Taurus { get; set; }

        [JsonProperty("Virgo")]
        public string[] Virgo { get; set; }

        [JsonProperty("Water")]
        public string[] Water { get; set; }

        [JsonProperty("Wind")]
        public string[] Wind { get; set; }
    }
}
