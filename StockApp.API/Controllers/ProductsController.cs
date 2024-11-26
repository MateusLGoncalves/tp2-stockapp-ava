using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Policy = "CanManageProducts")]
public class ProductsController : Controller
{
    public IActionResult Manage()
    {
        return View();
    }
}