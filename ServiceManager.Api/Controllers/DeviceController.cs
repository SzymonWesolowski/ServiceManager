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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceOperations _deviceOperations;
        public DeviceController(IDeviceOperations deviceOperations)
        {
            _deviceOperations = deviceOperations;
        }
        [HttpGet]

        public ActionResult<List<Device>> GetDevices([FromBody]Guid estateId)
        {
            var devices = _deviceOperations.GetDeviceList(estateId);
            return Ok(devices);
        }

        [HttpDelete]
        public ActionResult DeleteDevice([FromBody]Device device)
        {
            _deviceOperations.RemoveDevice(device);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddDevice([FromBody]Device device)
        {
            _deviceOperations.AddDevice(device);
            return Created(new Uri("http://localhost:49460/api/device"), _deviceOperations.GetDevice(device.DeviceId.ToString()));
        }

        [HttpPut]
        public ActionResult ModifyDevice([FromBody]Device device)
        {
            _deviceOperations.ModifyDevice(device);
            return NoContent();
        }
    }
}