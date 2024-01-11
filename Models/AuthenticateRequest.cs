using System.ComponentModel;

namespace Auth_Jwt.Models;

public class AuthenticateRequest
{
        [DefaultValue("System")]
        public required string Username { get; set; }

        [DefaultValue("System")]
        public required string Password { get; set; }
}
