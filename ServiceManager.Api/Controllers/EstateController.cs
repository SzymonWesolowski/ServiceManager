using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly IEstateOperations _estateOperations;

        public EstateController(IEstateOperations estateOperations)
        {
            _estateOperations = estateOperations;
        }

        [HttpGet]
        public ActionResult<List<Estate>> GetEstates()
        {
            return Ok(_estateOperations.GetEstateList());
        }

        [HttpPost]
        public ActionResult PostEstate([FromBody] Estate estate)
        {
            _estateOperations.AddEstate(estate);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteEstate([FromBody] Estate estate)
        {
            _estateOperations.DeleteEstate(estate);
            return Ok();
        }

    }
}