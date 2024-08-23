using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShanaiKanri.Dao;
using ShanaiKanri.DataModels;
using ShanaiKanri.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static ShanaiKanri.Common.Const;

namespace ShanaiKanri.Controllers
{
    public class AAAKimTestController : Controller
    {
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <returns>テスト画面</returns>
        public IActionResult Index()
        {
            AAAKimTestViewModel vm = new AAAKimTestViewModel();

            AAAKimTestDao dao = new AAAKimTestDao();
            List<AAAKimTestModel> aAAKimTestModels = dao.findLoginUserList();

            //ViewModelに格納
            setBindVm(vm, aAAKimTestModels);

            return View(vm);
        }
        /// <summary>
        /// 勤怠入力画面
        /// </summary>
        /// <returns>勤怠入力画面</returns>
        public IActionResult InputKintai()
        {
          /*  AAAKimTestViewModel vm = new AAAKimTestViewModel();

            AAAKimTestDao dao = new AAAKimTestDao();
            List<AAAKimTestModel> aAAKimTestModels = dao.findLoginUserList();

            //ViewModelに格納
            setBindVm(vm, aAAKimTestModels);*/

            return View();
        }

        /// <summary>
        /// DataModel型のデータをViewModel型に変換
        /// </summary>
        /// <param name="vm">テスト画面</param>
        /// <param name="aAAKimTestModel">db取得デート</param>
        private void setBindVm(AAAKimTestViewModel vm, List<AAAKimTestModel> aAAKimTestModel)
        {
            List<AAAKimTestViewModel> vmList = new List<AAAKimTestViewModel>();

            foreach (AAAKimTestModel model in aAAKimTestModel)
            {
                
                AAAKimTestViewModel item = new AAAKimTestViewModel()
                {
                    EngId = model.EngId,
                    CompCode = model.CompCode,
                    EmployeeId = model.EmployeeId,
                    EngName = model.EngName,
                    EngInitial = model.EngInitial
                };
                vmList.Add(item);
            }
            vm.aAAKimTestViewModel = vmList;
        }



    }

   


}
