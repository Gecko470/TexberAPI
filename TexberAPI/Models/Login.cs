using System;
using System.Collections.Generic;

#nullable disable

namespace TexberAPI.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
