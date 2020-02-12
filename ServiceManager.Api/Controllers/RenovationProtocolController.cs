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
    public class RenovationProtocolController : ControllerBase
    {
        private readonly IRenovationProtocolOperations _renovationProtocolOperations;

        public RenovationProtocolController(IRenovationProtocolOperations renovationProtocolOperations)
        {
            _renovationProtocolOperations = renovationProtocolOperations;
        }

        [HttpGet]
        public ActionResult<List<RenovationProtocol>> GetRenovationProtocolList(Guid deviceId)
        {
            return Ok( _renovationProtocolOperations.GetRenovationProtocolList(deviceId));
        }

        [HttpDelete]
        public ActionResult DeleteRenovationProtocol(Guid renovationProtocolId)
        {
            _renovationProtocolOperations.DeleteRenovationProtocol(renovationProtocolId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddRenovationProtocol(RenovationProtocol renovationProtocol)
        {
            _renovationProtocolOperations.AddRenovationProtocol(renovationProtocol);
            return Created(new Uri("http://localhost:49460/api/renovationprotocol/" + renovationProtocol.ProtocolId),
                _renovationProtocolOperations.GetRenovationProtocol(renovationProtocol.ProtocolId));
        }

        [HttpPut]
        public ActionResult ModifyRenovationProtocol(RenovationProtocol renovationProtocol)
        {
            _renovationProtocolOperations.ModifyRenovationProtocol(renovationProtocol);
            return NoContent();
        }
    }
}