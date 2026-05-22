using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.Controllers
{
    public class BaseTraceController : Controller
    {
        protected void SetupTraceInfo ()
        {
            ViewData["TraceIdent"] = HttpContext.TraceIdentifier;
        }
    }
}
