using ClassLibrary1.Data;
using ClassLibrary1.Data.Repository.IRepository;
using ClassLibrary2.Models;
using ClassLibrary2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;





namespace ProjectOne.Area.Admin.Controllers;
[Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }
    public IActionResult Index()
        {
            return View();
        }


    public IActionResult Upsert(int? id)
    {
        ProductVM productVM = new()
        {
            product = new(),
              CategoryList = _unitOfWork.category.GetAll().Select(i=>new SelectListItem
                {
                    Text = i.Name,
                    Value=i.Id.ToString(),
                }),

                 CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                 {
                     Text = i.Name,
                     Value = i.Id.ToString(),
                 }),
        };
        
        if (id == null || id == 0)
        {
            ////create product
            //ViewBag.CategoryList=CategoryList;
            //ViewData["CoverTypeList"] = CoverTypeList;
            return View(productVM);

        }
        else
        {
            //update product
            productVM.product=_unitOfWork.product.GetFirstOrDefault(u => u.Id == id);
        return View(productVM);
        }
       

    }
       
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
          
            if (ModelState.IsValid)
            {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName=Guid.NewGuid().ToString();
                var uploads=Path.Combine(wwwRootPath, @"Images\Products");
                var extension=Path.GetExtension(file.FileName);

                if (obj.product.ImageUrl != null)
                {
                    var oldImagePath=Path.Combine(wwwRootPath, obj.product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.product.ImageUrl = @"\Images\Products\" + file + extension;
            }
            if (obj.product.Id == 0)
            {
              _unitOfWork.product.Add(obj.product);
            }
            else
            {
                _unitOfWork.product.Update(obj.product);
            }
               
                _unitOfWork.Save();
                TempData["success"] = "product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        

        //Post
       
    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var ProductList = _unitOfWork.product.GetAll(includeProperties:"Category,CoverType");
        return Json(new {data=ProductList});

    }
   

[HttpDelete]

    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.product.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }
        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork.product.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete successful" });


    }
    #endregion

}
