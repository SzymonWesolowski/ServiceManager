using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorController : ControllerBase
    {
        private readonly IInspectorOperations _inspectorOperations;
        public InspectorController(IInspectorOperations inspectorOperations)
        {
            _inspectorOperations = inspectorOperations;
        }

        [HttpGet]
        public ActionResult<List<Inspector>> GetInspectorList()
        {
            return Ok(_inspectorOperations.GetInspectorList());
        }

        [HttpDelete]
        public ActionResult DeleteInspector(Guid inspectorId)
        {
            _inspectorOperations.RemoveInspector(inspectorId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddInspector(Inspector inspector)
        {
            _inspectorOperations.AddInspector(inspector);
            return Created(new Uri("http://localhost:49460/api/values/" + inspector.InspectorId),
                _inspectorOperations.GetInspector(inspector.InspectorId));
        }

        [HttpPut]
        public ActionResult ModifyInspector(Inspector inspector)
        {
            _inspectorOperations.ModifyInspector(inspector);
            return NoContent();
        }
    }
}