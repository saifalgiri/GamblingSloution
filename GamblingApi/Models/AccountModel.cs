using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GamblingApi.Models
{
    public class AccountModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AccountId { get; set; }
        public Decimal Balance { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public UserModel UserModel { get; set; }
    }
}
