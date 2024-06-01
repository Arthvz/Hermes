using System;
using System.ComponentModel.DataAnnotations;

namespace Hermes.Models {
    public class User
    {
        public long Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public short Role { get; set; }
    }
}