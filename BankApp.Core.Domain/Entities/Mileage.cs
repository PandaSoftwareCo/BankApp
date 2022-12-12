using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Mileage
    {
        public int MileageId { get; set; }
        public int Value { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
