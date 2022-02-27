using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GamblingApi.Models
{
    public class OrderModel
    {
        [JsonIgnore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Range(minimum: 1, maximum: 20)]
        public int BetTimes {get; set;}
        [Range(minimum: 1, maximum: 200)]
        public int Points {get; set;}
        [JsonIgnore]
        public Status Status { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public UserModel UserModel { get; set; }
    }

    public enum Status 
    {
        CONTINUE,
        WON,
        LOST
    }
    public enum DiceType
    {
        SNAKE_EYES = 2,
        TREY = 3,
        SEVEN = 7,
        ELEVEN = 11,
        BOX_CARS = 12
    }
}
