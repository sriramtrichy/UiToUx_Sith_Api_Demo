using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitoUx.AppD.DTO.SubMenu
{
    public class CreateSubmenu
    {
        [Required]
        public int HeaderId { get; set; }
        [Required]
        public string SubMenuName { get; set; }
    }
}
