using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETMVC_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETMVC_test.Controllers
{
    public class SyanaikanriController : Controller
    {
        public IActionResult Index()
        {
            AAAKimTestViewModel vm = new AAAKimTestViewModel();

            AAAKimTestDao dao = new AAAKimTestDao();
            List<AAAKimTestModel> aAAKimTestModels = dao.findLoginUserList();

            //ViewModelに格納
            setBindVm(vm, aAAKimTestModels);

            return View(vm);
        }

  }
}

