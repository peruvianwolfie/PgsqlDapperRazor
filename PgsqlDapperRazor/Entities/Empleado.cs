using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PgsqlDapperRazor.Entities
{
    public class Empleado
    {
        public int ID { get; }
        public string Name { get; }
        public decimal Salary { get; }
        public string Address { get; }
        public string Office { get; }
        public string Field { get; }
    }
}
