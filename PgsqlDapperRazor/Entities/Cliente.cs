using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PgsqlDapperRazor.Entities
{
    public class Cliente
    {
        public int Id { get; }
        public string Name { get; }        
        public string Email { get; }
        public string Phone { get; }
        public string Address { get; }
    }
}
