using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitoUx.Domain.Models
{
    public class SupMenu
    {
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(HederMenu))]
        public int HeaderId { get; set; }
        public HederMenu HederMenu { get; set; }
        [Required]
        public string SubMenuName { get; set; }
    }
}
