using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairProtocolController : ControllerBase
    {
        private readonly IRepairProtocolOperations _repairProtocolOperations;

        public RepairProtocolController(IRepairProtocolOperations repairProtocolOperations)
        {
            _repairProtocolOperations = repairProtocolOperations;
        }

        [HttpGet]
        public ActionResult<List<RepairProtocol>> GetRepairProtocolList(Guid deviceId)
        {
            return Ok(_repairProtocolOperations.GetRepairProtocolList(deviceId));
        }

        [HttpDelete]
        public ActionResult DeleteRepairProtocol(Guid protocolId)
        {
            _repairProtocolOperations.DeleteRepairProtocol(protocolId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddRepairProtocol(RepairProtocol repairProtocol)
        {
            _repairProtocolOperations.AddRepairProtocol(repairProtocol);
            return Created(new Uri("http://localhost:49460/api/repairprotocol/" + repairProtocol.ProtocolId),
                _repairProtocolOperations.GetRepairProtocol(repairProtocol.ProtocolId));
        }

        [HttpPut]
        public ActionResult ModifyRepairProtocol(RepairProtocol repairProtocol)
        {
            _repairProtocolOperations.ModifyRepairProtocol(repairProtocol);
            return NoContent();
        }
    }
}