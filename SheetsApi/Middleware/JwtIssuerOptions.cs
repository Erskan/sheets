using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace SheetsApi.Middleware
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }
        
        public string Subject { get; set; }
        
        public string Audience { get; set; }
        
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        
        public DateTime NotBefore => DateTime.UtcNow;
        
        public DateTime IssuedAt => DateTime.UtcNow;
        
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);



        /// <summary>
        /// "jti" (JWT ID) Claim (default ID is a GUID)
        /// </summary>
        public Func<Task<string>> JtiGenerator =>
          () => Task.FromResult(Guid.NewGuid().ToString());
        
        public SigningCredentials SigningCredentials { get; set; }
    }
}
