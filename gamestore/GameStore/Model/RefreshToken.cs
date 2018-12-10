using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string Token { get; set; }
        public DateTime Expire { get; set; }
        public RefreshToken()
        {
            Id = Guid.NewGuid();
        }
    }
}
