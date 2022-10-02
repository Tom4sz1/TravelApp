using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
    }
}
