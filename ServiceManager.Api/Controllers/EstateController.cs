using System;
using System.Collections.Generic;
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

        [HttpGet("{estateId}")]
        public ActionResult<Estate> GetEstate([FromRoute]Guid estateId)
        {
            return Ok(_estateOperations.GetEstate(estateId));
        }

        [HttpPost]
        public ActionResult PostEstate([FromBody] Estate estate)
        {
            _estateOperations.AddEstate(estate);
            return Created(new Uri("http://localhost:49460/api/values/" + estate.EstateId), _estateOperations.GetEstate(estate.EstateId));
        }

        [HttpDelete]
        public ActionResult DeleteEstate([FromBody] Guid estateId)
        {
            _estateOperations.DeleteEstate(estateId);
            return NoContent();
        }

        [HttpPut]
        public ActionResult ModifyEstate([FromBody] Estate estate)
        {
            _estateOperations.ModifyEstate(estate);
            return NoContent();
        }


    }
}