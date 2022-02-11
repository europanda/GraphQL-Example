using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseInsensitiveGraphQL.Db
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public bool IsPrimary { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
