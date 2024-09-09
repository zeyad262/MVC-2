using BusinessLogicLayer.Repositories;
using DataAcessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PresentationLyer.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepositories _repository;

        public DepartmentsController(IDepartmentRepositories repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var departments = _repository.GetAll();
            return View(departments); 
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
           if(!ModelState.IsValid) return View(department);
           _repository.Create(department);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _repository.Get(id.Value);
            if(department is null) return NotFound();
            return View(department);
        }  
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _repository.Get(id.Value);
            if(department is null) return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id,Department department)
        {
            if(id != department.Id) return BadRequest();
            if(ModelState.IsValid)
            {
                try
                {
                    _repository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(department);
        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _repository.Get(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            if (!ModelState.IsValid) return View(department);
            _repository.Remove(department);
            return RedirectToAction(nameof(Index));
        }
    }

}
