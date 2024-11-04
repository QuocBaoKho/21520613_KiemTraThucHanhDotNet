using _21520613_KiemTraThucHanhDotNet.Models;

namespace _21520613_KiemTraThucHanhDotNet.ViewModels
{
    public class ProductDetailsViewModel
    {
        public TDanhMucSp danhMuc { get; set; }
        public List<TAnhSp> anhSp { get; set; }
        public ProductDetailsViewModel()
        {
            danhMuc = new TDanhMucSp();
            anhSp = new List<TAnhSp>();
        }
        public ProductDetailsViewModel(TDanhMucSp danhMuc, List<TAnhSp> anhSp)
        {
            this.danhMuc = danhMuc;
            this.anhSp = anhSp;
        }  
    }
}
