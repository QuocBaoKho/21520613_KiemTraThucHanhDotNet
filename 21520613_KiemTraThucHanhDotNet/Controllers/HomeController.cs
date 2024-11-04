using _21520613_KiemTraThucHanhDotNet.Models;
using _21520613_KiemTraThucHanhDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _21520613_KiemTraThucHanhDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private QlbanVaLiContext db;
        public HomeController(ILogger<HomeController> logger)
        {
            db = new QlbanVaLiContext();
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dssp = db.TDanhMucSps.OrderBy(sp=>sp.TenSp).ToList();
            return View(dssp);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ProductDetails(string MaSp)
        {
            var sanPhamClicked = db.TDanhMucSps.Find(MaSp);
            if (sanPhamClicked == null)
            {
                return NotFound();
            }
            var hinhAnhs = db.TAnhSps.Where(img => img.MaSp.Equals(MaSp)).ToList();
            var vm = new ProductDetailsViewModel(sanPhamClicked, hinhAnhs);
            return View(vm);
        }
        public IActionResult SanPhamTheoLoai(string MaLoai)
        {
            var spl = db.TDanhMucSps.Where(d=>d.MaLoai.Equals(MaLoai)).ToList();
            return View(spl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
