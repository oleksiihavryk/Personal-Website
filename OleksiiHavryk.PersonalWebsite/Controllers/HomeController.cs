using Microsoft.AspNetCore.Mvc;

namespace OleksiiHavryk.PersonalWebsite.Controllers;

[Controller]
public class HomeController : Controller
{
    public ViewResult Index()
    {
        return View();
    }
}