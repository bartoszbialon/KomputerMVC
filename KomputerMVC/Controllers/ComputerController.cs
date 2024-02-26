using Microsoft.AspNetCore.Mvc;
using KomputerMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace KomputerMVC.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;


        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }


        [AllowAnonymous]
        public IActionResult Index(int typeId = 0)
        {
            ViewBag.TypeId = typeId;
            if (typeId == 0)
                return View(_computerService.FindAll());
            else
                return View(_computerService.FindByType(typeId));
        }


        [AllowAnonymous]
        public IActionResult PagedIndex(int typeId = 0, int page = 1, int size = 2)
        {
            List<Computer> list = new List<Computer>();
            if (typeId == 0)
                list = _computerService.FindAll();
            else
                list = _computerService.FindByType(typeId);
            ViewBag.TypeId = typeId;
            PagingList<Computer> pagingList = _computerService.FindPage(page, size, list);
            return View(pagingList);
        }


        [HttpGet]
        [Authorize(Roles = "user, mod, admin")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "user, mod, admin")]
        public IActionResult Create(Computer model) 
        {
            if (ModelState.IsValid)
            {
                _computerService.Add(model);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            return View(_computerService.FindById(id));
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Computer model)
        {
            _computerService.Delete(model.ComputerId);
            return RedirectToAction("PagedIndex");
        }


        [HttpGet]
        [Authorize(Roles = "mod, admin")]
        public IActionResult Update(int id)
        {
            return View(_computerService.FindById(id));
        }


        [HttpPost]
        [Authorize(Roles = "mod, admin")]
        public IActionResult Update(Computer model)
        {
            if (ModelState.IsValid)
            {
                _computerService.Update(model);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "user, mod, admin")]
        public IActionResult Details(int id)
        {
            var model = _computerService.FindById(id);
            return model is null ? NotFound() : View(model);
        }

    }
}
