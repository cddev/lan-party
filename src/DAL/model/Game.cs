using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAL.model
{
 
        public partial class GameResponse
        {
            [JsonProperty("Games", NullValueHandling = NullValueHandling.Ignore)]
            public List<Game> Games { get; set; }
        }

            public partial class Game
            {
                [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
                public string Id { get; set; }

                [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
                public int? GameId { get; set; }

                [JsonProperty("isActive", NullValueHandling = NullValueHandling.Ignore)]
                public bool? IsActive { get; set; }

                [JsonProperty("picture", NullValueHandling = NullValueHandling.Ignore)]
                public string Picture { get; set; }

                [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
                public string Title { get; set; }

                [JsonProperty("torrentUrl", NullValueHandling = NullValueHandling.Ignore)]
                public string TorrentUrl { get; set; }

                [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
                public string Description { get; set; }

                [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
                public string Size { get; set; }

                [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
                public bool? Selected { get; set; }

                
        }   
        public partial class GameResponse
        {
            public static GameResponse FromJson(string json) => JsonConvert.DeserializeObject<GameResponse>(json, Converter.Settings);
        }
        public static partial class Serialize
        {
            public static string ToJson(this GameResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        public static partial class Serialize
        {
            public static string ToJson(this Game self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    
}
