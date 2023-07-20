using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesProject.Models
{
    class MarketResponse
    {
        [JsonProperty("data")]
        public List<MarketInfo> Data { get; set; }
    }

    class MarketInfo
    {
        [JsonProperty("exchangeId")]
        public string ExchangeId { get; set; }

        [JsonProperty("baseId")]
        public string BaseId { get; set; }

        [JsonProperty("quoteId")]
        public string QuoteId { get; set; }

        [JsonProperty("volumeUsd")]
        public decimal VolumeUsd { get; set; }
    }
}
