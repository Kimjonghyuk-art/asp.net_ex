using System;
using System.Collections.Generic;
  using ASP.NETMVC_test.Dao;
  using ASP.NETMVC_test.Models;
  using Microsoft.AspNetCore.Mvc;

  namespace ASP.NETMVC_test.Controllers
  {
    public class SyanaiKanriController: Controller
      {
        public UserDao dao = new UserDao();
          /// <summary>
          /// 初期表示
          /// </summary>
          /// <returns>テスト画面</returns>
          public IActionResult Index()
          {
              UserViewModel vm = new UserViewModel();
      
            
              List<UserModel> userModels = dao.findLoginUserList();

              //ViewModelに格納
              setBindVm(vm, userModels);

              return View(vm);
          }
          public IActionResult DeleteUser(UserViewModel vm)
          {
              UserModel userModel = setBindM(vm); setBindM(vm);
              dao.deleteUser(userModel);


              return RedirectToAction("Index");
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


          public IActionResult InsertUser(UserViewModel vm)
          {
            //ViewModel -> Model
            UserModel userModel = setBindM(vm);
            dao.insertUser(userModel);
          

            return RedirectToAction("Index");
          }


          private UserModel setBindM(UserViewModel vm)
          {

            UserModel userModel = new UserModel()
            {
              UserId = vm.UserId,
              UserName = vm.UserName,
              Email = vm.Email,
              Age = vm.Age
              };
              return userModel;
          }
    }

   


  }
