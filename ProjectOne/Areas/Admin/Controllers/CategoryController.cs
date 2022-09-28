using ClassLibrary1.Data;
using ClassLibrary1.Data.Repository.IRepository;
using ClassLibrary2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectOne.Area.Admin.Controllers;

    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }  
        public IActionResult Index()
        {
            IEnumerable<category> objCategoryList = _unitOfWork.category.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
           
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(category obj)
        {
            if (obj.Name == obj.DisplyOrger.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "category created successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            return View();
           // var categoryFromDb = _db.Categories.Find(id);
           var categoryFromDbFirst = _unitOfWork.category.GetFirstOrDefault(c => c.Id==id);  

            if(categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
       
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(category obj)
        {
            if (obj.Name == obj.DisplyOrger.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            return View();
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDb = _unitOfWork.category.GetFirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "category deleted successfully";
                return RedirectToAction("Index");
           
        }

    }
