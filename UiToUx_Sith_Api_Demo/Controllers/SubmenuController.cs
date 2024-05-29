using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UitoUx.AppD.DTO.HederMenu;
using UitoUx.AppD.DTO.SubMenu;
using UitoUx.DataAccess.Common;
using UitoUx.Domain.Models;

namespace UiToUx_Sith_Api_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmenuController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public SubmenuController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("ListofSubmen")]
        public async Task<ActionResult> GetHeders()
        {
            var heder = await _dbContext.supMenus.ToListAsync();
            return Ok(heder);
        }
        [HttpPost]
        [Route("CreateSubMenu")]
        public async Task<ActionResult> CreateHeaders(CreateSubmenu createSubmenu)
        {
            SupMenu supMenu = new SupMenu
            {
                SubMenuName = createSubmenu.SubMenuName,
                HeaderId = createSubmenu.HeaderId,


            };
            _dbContext.supMenus.Add(supMenu);
            await _dbContext.SaveChangesAsync();
            return Ok("Submenu Added SuccessFully");
           
        }
    }
}
