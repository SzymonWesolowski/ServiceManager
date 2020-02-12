using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionProtocolController : ControllerBase
    {
        private readonly IInspectionProtocolOperations _inspectionProtocolOperations;

        public InspectionProtocolController(IInspectionProtocolOperations inspectionProtocolOperations)
        {
            _inspectionProtocolOperations = inspectionProtocolOperations;
        }

        [HttpGet]
        public ActionResult<List<InspectionProtocol>> GetInspectionProtocolList([FromBody]Guid deviceId)
        {
            return Ok(_inspectionProtocolOperations.GetInspectionProtocolList(deviceId));
        }

        [HttpDelete]
        public ActionResult DeleteInspectionProtocol([FromBody]Guid protocolId)
        {
            _inspectionProtocolOperations.DeleteInspectionProtocol(protocolId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddInspectionProtocol([FromBody]InspectionProtocol inspectionProtocol)
        {
            _inspectionProtocolOperations.AddInspectionProtocol(inspectionProtocol);
            return Created(new Uri("http://localhost:49460/api/inspectionprotocol/" + inspectionProtocol.ProtocolId),
                _inspectionProtocolOperations.GetInspectionProtocol(inspectionProtocol.ProtocolId));
        }

        [HttpPut]
        public ActionResult ModifyInspectionProtocol([FromBody]InspectionProtocol inspectionProtocol)
        {
            _inspectionProtocolOperations.ModifyInspectionProtocol(inspectionProtocol);
            return NoContent();
        }

    }
}