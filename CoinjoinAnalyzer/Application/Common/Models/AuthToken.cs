using System.Text.Json.Serialization;

namespace Application.Common.Models
{
    public class AuthToken
    {
        public string UserId { get; set; }

        [JsonIgnore]
        public string AccessToken { get; set; }
    }

    public interface IAuthToken
    {
        [JsonIgnore]
        public string AccessToken { get; set; }
    }
}
