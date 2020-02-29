using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using ServiceManager.Application;
using ServiceManager.Domain.Model;
using ServiceManager.MVC.Models;

namespace ServiceManager.MVC.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateOperations _estateOperations;
        private readonly IInspectorOperations _inspectorOperations;

        public EstateController(IEstateOperations estateOperations, IInspectorOperations inspectorOperations)
        {
            _estateOperations = estateOperations;
            _inspectorOperations = inspectorOperations;
        }

        public IActionResult Index()
        {
            var model = _estateOperations.GetEstateList();
            var viewModel = new List<EstateViewModel>();
            foreach (var estate in model)
            {
                viewModel.Add(ModelToViewModel(estate));
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.inspectors = getInspectorsSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EstateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.EstateId = Guid.NewGuid().ToString();
                _estateOperations.AddEstate(ViewModelToModel(model));
                return Redirect("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var model = _estateOperations.GetEstate(Guid.Parse(id));
            return View(ModelToViewModel(model));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.inspectors = getInspectorsSelectList();
            var model = _estateOperations.GetEstate(Guid.Parse(id));
            return View(ModelToViewModel(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EstateViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Estate edited!";
                _estateOperations.ModifyEstate(ViewModelToModel(model));
                return RedirectToAction("Details", new {id = model.EstateId});
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var model = _estateOperations.GetEstate(Guid.Parse(id));
            return View(ModelToViewModel(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(string estateId, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                _estateOperations.DeleteEstate(Guid.Parse(estateId));
                return RedirectToAction("Index");
            }

            return View();
        }

        private EstateViewModel ModelToViewModel(Estate estate)
        {
            var estateViewModel = new EstateViewModel
            {
                InspectorId = estate.InspectorId.ToString(),
                EstateId = estate.EstateId.ToString(),
                City = estate.City,
                Name = estate.Name,
                PostCode = estate.PostCode,
                Street = estate.Street,
                UnderContract = estate.UnderContract
            };
            return estateViewModel;
        }

        private Estate ViewModelToModel(EstateViewModel estateViewModel)
        {
            return new Estate(estateViewModel.Name, estateViewModel.City, estateViewModel.Street,
                estateViewModel.PostCode, estateViewModel.UnderContract, Guid.Parse(estateViewModel.EstateId),
                Guid.Parse(estateViewModel.InspectorId));
        }

        private List<SelectListItem> getInspectorsSelectList()
        {
            var inspectors = _inspectorOperations.GetInspectorList();
            var inspectorsSelectList = new List<SelectListItem>
            {
                (new SelectListItem("No inspector", null))
            };
            foreach (var inspector in inspectors)
            {
                inspectorsSelectList.Add(new SelectListItem(
                    inspector.FirstName + " " + inspector.LastName + ", " + inspector.City,
                    inspector.InspectorId.ToString()));
            }

            return inspectorsSelectList;
        }
    }
}