using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShanaiKanri.Models
{
    public class AAAKimTestViewModel
    {
        public int EngId { get; set; }

        public string CompCode { get; set; }

        public int EmployeeId { get; set; }

        public string EngName { get; set; }

        public string EngInitial { get; set; }

        public List<AAAKimTestViewModel> aAAKimTestViewModel { get; set; }

    }
}
