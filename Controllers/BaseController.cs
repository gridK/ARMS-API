using Microsoft.AspNetCore.Mvc;
using AUroomAPI.Data;

namespace AUroomAPI.Controllers
{
    // [Authorize]
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _db;
        public BaseController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
