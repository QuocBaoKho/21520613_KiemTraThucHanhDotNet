using _21520613_KiemTraThucHanhDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _21520613_KiemTraThucHanhDotNet.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        ILoaiSpRepository repository;
        public LoaiSpMenuViewComponent(ILoaiSpRepository repository)
        {
            this.repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            var loai = repository.GetAll().OrderBy(x => x.Loai);
            return View(loai);
        }
    }
}
