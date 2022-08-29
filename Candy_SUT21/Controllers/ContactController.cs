using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
