using Microsoft.AspNetCore.Mvc;

namespace test_Yung_Ching_project.Controllers;

public class ItemsBag : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Items(string name)
    {
        ViewData["DataName"] = name;
        return View();
    }
}