using ClassLibrary1.Data.Repository.IRepository;
using ClassLibrary2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProjectOne.Cantrollers;
[Area("Customer")]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
  

    public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productsList = _unitOfWork.product.GetAll(includeProperties:"Category,CoverType"); 
            return View(productsList);
    }
    public IActionResult Details(int id)
    {
        ShoppingCart cartObj = new()
        {

            Count = 1,
            Product = _unitOfWork.product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CoverType")
    };
        return View(cartObj);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}