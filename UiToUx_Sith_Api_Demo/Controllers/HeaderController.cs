using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UitoUx.AppD.DTO.HederMenu;
using UitoUx.DataAccess.Common;
using UitoUx.Domain.Models;

namespace UiToUx_Sith_Api_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public HeaderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("ListofHeaders")]
        public async Task<ActionResult> GetHeders()
        {
            var heder = await _dbContext.HederMenu.ToListAsync();
            return Ok(heder);
        }
        [HttpPost]
        [Route("CreateHeaders")]
        public async Task<ActionResult> CreateHeaders(CreatehederMenu createhederMenu)
        {
            HederMenu hederMenu = new HederMenu
            {
                HederName = createhederMenu.HederName

            };
            _dbContext.HederMenu.Add(hederMenu);
            await _dbContext.SaveChangesAsync();
            return Ok("Header Added SuccessFully");
           
        }
    }
}
