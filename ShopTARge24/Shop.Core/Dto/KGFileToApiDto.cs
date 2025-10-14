using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dto
{
    public class KGFileToApiDto
    {
        public Guid ImageId { get; set; }
        public string? ExistingFilePath { get; set; }
  
        public Guid? KindergartenId { get; set; }
    }
}
