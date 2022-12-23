using System.Text.Json.Serialization;

namespace TaskApi.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public ICollection<Todo>? Tasks { get; set; }

    }
}
