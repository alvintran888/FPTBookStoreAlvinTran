using FPTBookStore.Models;
using FPTBookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;
using Newtonsoft.Json;

namespace FPTBookStore.Controllers
{
    public class CustomerController : Controller
    {

        public const string CARTKEY = "cart";
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        private readonly ApplicationDbContext context;
        public CustomerController(ApplicationDbContext dbContext)
        {
            context = dbContext;

        }
        [Route("/")]
        public IActionResult Index()
        {
            var products = context.Product.ToList();
            var categories = context.Category.ToList();
            ViewBag.Categories = categories;
            return View(products);
        }


        public IActionResult Index2(int? id)
        {
            var products = context.Product.ToList();
            var categories = context.Category.ToList();
            ViewBag.Categories = categories;
            var productSearch = context.Category.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
            return View(productSearch);
        }
        [HttpPost]
        public IActionResult Search(string search)
        {
            var products = context.Product.Where(p => p.Name.Contains(search)).ToList();
            var categories = context.Category.ToList();
            ViewBag.Categories = categories;
            TempData["search"] = search;

            return View("Index", products);
        }
        public IActionResult Details(int? id)
        {
            var products = context.Product.ToList();
            var item = products.FirstOrDefault(c => c.Id == id);
            var categories = context.Category.ToList();
            ViewBag.Categories = categories;
            return View(item);
        }

        [Authorize(Roles = "Customer,Administrator")]
        public IActionResult AddtoCart(int? id)
        {
            var product = context.Product
        .Where(p => p.Id == id)
        .FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == id);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { Quantity = 1, product = product });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewCart()
        {
            var categories = context.Category.ToList();
            ViewBag.Categories = categories;
            return View(GetCartItems());
        }

        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart(int productid, int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quantity = quantity;
            }
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }
        public IActionResult UserView()
        {
            var categories = context.Category.ToList();
            ViewBag.Categories = categories;
            var claimIdentity = (ClaimsIdentity)User.Identity;

            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string currentUserId = claims.Value;
            //var user = _context.Users.OfType<ApplicationUser>().FirstOrDefault(u => u.UserName == userName);
            ApplicationUser currentUser = (ApplicationUser)context.Users.FirstOrDefault(x => x.Id == currentUserId);

            ViewBag.Img = currentUser.Image;
            ViewBag.Id = currentUser.Id;
            ViewBag.Email = currentUser.Email;
            ViewBag.UserName = currentUser.UserName;
            ViewBag.Fullname = currentUser.FullName;
            ViewBag.Address = currentUser.Address;
            ViewBag.Dob = currentUser.DoB;
            return View();
        }
        public IActionResult Checkout()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string currentUserId = claims.Value;

            // caculate total price
            var cart = GetCartItems();
            double total = 0;
            foreach (var item in cart)
            {
                total += (double)(item.product.Price * item.Quantity);
            }

            for (int i = 0; i < cart.Count; i++)
            {
                var order = new Order()
                {
                    UserId = currentUserId,
                    ProductId = cart[i].product.Id,
                    ProductName = cart[i].product.Name,
                    image = cart[i].product.Image,
                    Price = (int)cart[i].product.Price,
                    Quantity = cart[i].Quantity,
                    TotalPrice = total,

                };
                context.Order.Add(order);
                context.SaveChanges();
            }
            ClearCart();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult ViewOrder()
        {
            var categories = context.Category.ToList();
            ViewBag.Categories = categories;
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string currentUserId = claims.Value;
            //int UsrID = Int32.Parse(currentUserId);
            string UsrID = currentUserId;
            var orders = context.Order.ToList();
            var FindOrder = context.Order.Where(p => p.UserId.Contains(currentUserId)).ToList();
            return View("ViewOrder", FindOrder);

        }
    }

}
