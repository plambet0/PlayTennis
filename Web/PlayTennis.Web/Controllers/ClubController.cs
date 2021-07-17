using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayTennis.Web.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Add()
        {
            return this.View();
        }

    }
}
