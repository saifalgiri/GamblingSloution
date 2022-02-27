using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GamblingApi.Models
{
    public class UserModel
    {
        [JsonIgnore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public AccountModel Account { get; set; }
        [JsonIgnore]
        public List<OrderModel> Orders { get; set; }
    }
}
