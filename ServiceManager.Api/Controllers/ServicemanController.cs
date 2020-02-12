using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicemanController : ControllerBase
    {
        private readonly IServicemanOperations _servicemanOperations;

        public ServicemanController(IServicemanOperations servicemanOperations)
        {
            _servicemanOperations = servicemanOperations;
        }

        [HttpGet]
        public ActionResult<List<Serviceman>> GetServicemanList()
        {
            return Ok(_servicemanOperations.GetServicemanList());
        }

        [HttpDelete]
        public ActionResult DeleteServiceman(Guid servicemanId)
        {
            _servicemanOperations.DeleteServiceman(servicemanId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddServiceman(Serviceman serviceman)
        {
            _servicemanOperations.AddServiceman(serviceman);
            return Created(new Uri("http://localhost:49460/api/serviceman/" + serviceman.ServicemanId),
                _servicemanOperations.GetServiceman(serviceman.ServicemanId));
        }

        [HttpPut]
        public ActionResult ModifyServiceman(Serviceman serviceman)
        {
            _servicemanOperations.ModifyServiceman(serviceman);
            return NoContent();
        }
    }
}