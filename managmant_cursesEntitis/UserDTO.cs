using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managmant_cursesEntitis
{
  
        public class UserDTO
        {
            public string? Name { get; set; }

            public string? Password { get; set; }

            public string Email { get; set; } = null!;

            public string? Phone { get; set; }

            public decimal? PayLesson { get; set; }

            public int? Role { get; set; }

            public string? Adress { get; set; }

    }

}
