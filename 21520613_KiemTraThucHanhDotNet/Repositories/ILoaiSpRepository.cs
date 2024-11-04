using _21520613_KiemTraThucHanhDotNet.Models;

namespace _21520613_KiemTraThucHanhDotNet.Repositories
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp entity);
        TLoaiSp Update(TLoaiSp entity);
        TLoaiSp Delete(string loaiSP);
        TLoaiSp Get(string loaiSP);
        IEnumerable<TLoaiSp> GetAll();
    }
}
