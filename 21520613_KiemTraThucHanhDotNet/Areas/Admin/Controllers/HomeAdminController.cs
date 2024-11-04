using _21520613_KiemTraThucHanhDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
        [Route("edit")]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");
            var updated = db.TDanhMucSps.Find(id);
            return View(updated);
        }
        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TDanhMucSp dm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage_Product");
            }
            return View(dm);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            TempData["message"] = "Chua xoa";
            var ctSp = db.TChiTietSanPhams.Where(ct=>ct.MaSp.Equals(id)).ToList();
            var tenSp = db.TDanhMucSps.Where(ct => ct.MaSp.Equals(id)).Select(ct => ct.TenSp).FirstOrDefault();
            if (ctSp.Count > 0)
            {
                TempData["message"] = "Can't remove " + tenSp;
                return RedirectToAction("Manage_Product", "homeadmin");
            }
            var listHinhAnh = db.TAnhSps.Where(anh=>anh.MaSp.Equals(id)).ToList();
            if (listHinhAnh.Any())
            {
                db.RemoveRange(listHinhAnh);
            }
            db.Remove(db.TDanhMucSps.Find(id));
            db.SaveChanges();
            TempData["message"] = tenSp + " Successfully removed";
            return RedirectToAction("Manage_Product", "homeadmin");



        }

    }
}
