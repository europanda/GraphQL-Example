using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseInsensitiveGraphQL.Db
{
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
