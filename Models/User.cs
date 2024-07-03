using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LoginAPI.Models
{
    public class User
    {
        [DynamoDBHashKey("UserId")]
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public required string Email { get; set; } 

        public required string Address { get; set; }

        public required int PinCode { get; set; }
    }
}
