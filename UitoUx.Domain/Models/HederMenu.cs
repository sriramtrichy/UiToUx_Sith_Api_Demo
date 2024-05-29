using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitoUx.Domain.Models
{
    public class HederMenu
    {
        public int ID { get; set; }
        [Required]
        public string HederName { get; set; }

        public virtual ICollection<SupMenu> SupMenus { get; set; }
    }
}
