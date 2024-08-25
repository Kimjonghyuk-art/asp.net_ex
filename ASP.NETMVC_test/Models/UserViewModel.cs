using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NETMVC_test.Models
{
    public class UserViewModel
    {
    public int UserId { get; set; }

    public string UserName { get; set; }
      
    public int Age { get; set; }

    public string Email { get; set; }

    public DateTime RegisterDate { get; set; }

    public List<UserViewModel> Users { get; set; }

    public int SelectedUserId { get; set; } // 선택된 UserId

    }
}
