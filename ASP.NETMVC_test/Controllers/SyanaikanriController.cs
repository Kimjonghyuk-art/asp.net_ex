using ASP.NETMVC_test.Dao;
using ASP.NETMVC_test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ASP.NETMVC_test.Controllers
{
    public class SyanaiKanriController: Controller
    {
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <returns>テスト画面</returns>
        public IActionResult Index()
        {
            UserViewModel vm = new UserViewModel();
      
            UserDao dao = new UserDao();
            List<UserModel> userModels = dao.findLoginUserList();

            //ViewModelに格納
            setBindVm(vm, userModels);

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
        private void setBindVm(UserViewModel vm, List<UserModel> userModel)
        {
            List<UserViewModel> vmList = new List<UserViewModel>();

            foreach (UserModel model in userModel)
            {
                
                UserViewModel item = new UserViewModel()
                {
                    UserId = model.UserId,
                    UserName = model.UserName,
                    Email = model.Email,
                    Age = model.Age,
                };
                vmList.Add(item);
            }
            vm.Users = vmList;
        }


    public IActionResult TestSubmit(UserViewModel vm)
    {
      Console.WriteLine(vm.UserName);

      return RedirectToAction("Index");
    }


    }

   


}
