using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class MoneyDto
    {
       public  float Money { get; set; }
        public MoneyDto()
        {
            this.Money = 0f;
        }
    }
}
