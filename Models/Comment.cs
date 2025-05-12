using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APITestingRestWithRestSharp.Models
{
    public class Comment
    {
        [JsonPropertyName("postId")]
        public int commentId { get; set; }

        [JsonPropertyName("id")]

        public int commentid { get; set; }

        [JsonPropertyName("name")]
        public string commentName { get; set; }

        [JsonPropertyName("email")]
        public string commentEmail { get; set; }

        [JsonPropertyName("body")]
        public string commentBody { get; set; }
    }
}
