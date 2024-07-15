using LoginDemo.Data;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers
{
    public class UserController : Controller
    {

        private readonly UserDbContext _db;

        public UserController(UserDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IActionResult Login() // phương thức trả về view Login
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(User user) //phương thức nhận 1 đối tươngj user từ form login
        {
            //**Lưu ý, Có thể sử dụng nhiều cách khác nhau để kiểm tra user người dùng nhập vào có tồn tại trong database hay không
            try
            {
                // kiểm tra xem thông tin người dùng nhập vào có tồn tại trong database hay không
                User us = _db.Users.First(u => u.UserName == user.UserName && u.Password == user.Password);
                return Redirect("/Home/Index"); //nếu không văng exception => tồn tại thông tin user được nhập => trả về trang chủ
            }
            catch (Exception ex) { 
                ViewBag.ErrorMessage = "Sai ten dang nhap hoac mat khau";
                //nếu không văng exception => ko tồn tại user  được nhập  => Cập nhật thông báo lỗi sau đó trả về view
            }

            return View();
        }

    }
}
