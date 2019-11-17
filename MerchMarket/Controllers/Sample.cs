using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerchMarket.Controllers
{
  public class Sample : Controller
  {
    [Authorize]
    public IActionResult Index()
    {
      return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
  }
}