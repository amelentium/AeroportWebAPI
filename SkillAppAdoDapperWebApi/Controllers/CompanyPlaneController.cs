using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AeroportWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes =
   JwtBearerDefaults.AuthenticationScheme)]
    public class CompanyPlaneController : ControllerBase
    {
        #region Properties
        private readonly ICompanyPlaneService _companyPlaneService;
        #endregion

        #region Constructors
        public CompanyPlaneController(ICompanyPlaneService companyPlaneService)
        {
            _companyPlaneService = companyPlaneService;
        }
        #endregion

        #region APIs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyPlane plane)
        {
            await _companyPlaneService.AddCompanyPlane(plane);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _companyPlaneService.GeCompanyPlaneById(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _companyPlaneService.GetAllCompanyplanes();
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] CompanyPlane plane, int Id)
        {
            plane.Id = Id;
            await _companyPlaneService.UpdateCompanyPlane(plane);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _companyPlaneService.DeleteCompanyPlane(Id);
            return Ok();
        }
        #endregion
    }
}
