using _21520613_KiemTraThucHanhDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _21520613_KiemTraThucHanhDotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();

        }
        [Route("product_list")]
        public IActionResult Manage_Product()
        {
            var ps = db.TDanhMucSps.ToList();
            return View(ps);
        }
        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");
            return View();
        }
        [Route("add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(TDanhMucSp dm)
        {
            if (ModelState.IsValid)
            {
                db.Add(dm);
                db.SaveChanges();
                return RedirectToAction("Manage_Product");
            }
            return View(dm);
        }
    }
}
