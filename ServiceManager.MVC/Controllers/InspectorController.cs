using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceManager.Application;
using ServiceManager.Domain.Model;
using ServiceManager.MVC.Models;

namespace ServiceManager.MVC.Controllers
{
    public class InspectorController : Controller
    {
        private readonly IInspectorOperations _inspectorOperations;
        public InspectorController(IInspectorOperations inspectorOperations)
        {
            _inspectorOperations = inspectorOperations;
        }

        public IActionResult Index()
        {
            var model = _inspectorOperations.GetInspectorList();
            var viewModel = new List<InspectorViewModel>();
            foreach (var inspector in model)
            {
                viewModel.Add(ModelToViewModel(inspector));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var inspector = _inspectorOperations.GetInspector(Guid.Parse(id));
            return View(ModelToViewModel(inspector));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InspectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Inspector Added!";
                model.InspectorId = Guid.NewGuid().ToString();
                _inspectorOperations.AddInspector(ViewModelToModel(model));
                return Redirect("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = _inspectorOperations.GetInspector(Guid.Parse(id));
            return View(ModelToViewModel(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(InspectorViewModel model)
        {

            if (ModelState.IsValid)
            {
                TempData["Message"] = "Inspector Edited!";
                _inspectorOperations.ModifyInspector(ViewModelToModel(model));
                return RedirectToAction("Details", new {id = model.InspectorId });
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var inspector = _inspectorOperations.GetInspector(Guid.Parse(id));
            return View(ModelToViewModel(inspector));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(string id, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Inspector Deleted!";
                _inspectorOperations.RemoveInspector(Guid.Parse(id));
                return RedirectToAction("Index");
            }

            return View(id);
        }
        
        private InspectorViewModel ModelToViewModel(Inspector inspector)
        {
            return new InspectorViewModel
            {
                InspectorId = inspector.InspectorId.ToString(),
                City = inspector.City,
                FirstName = inspector.FirstName,
                LastName = inspector.LastName,
                PhoneNumber = inspector.PhoneNumber
            };

        }

        private Inspector ViewModelToModel(InspectorViewModel model)
        {
            return new Inspector(model.FirstName, model.LastName, model.City, model.PhoneNumber,
                Guid.Parse(model.InspectorId));
        }
    }
}