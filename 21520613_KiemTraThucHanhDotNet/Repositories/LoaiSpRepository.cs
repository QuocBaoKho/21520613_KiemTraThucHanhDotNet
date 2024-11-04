using _21520613_KiemTraThucHanhDotNet.Models;

namespace _21520613_KiemTraThucHanhDotNet.Repositories
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QlbanVaLiContext _context;
        public LoaiSpRepository(QlbanVaLiContext context)
        {
            _context = context;
        }

        public TLoaiSp Add(TLoaiSp entity)
        {
            _context.TLoaiSps.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TLoaiSp Delete(string loaiSP)
        {
            TLoaiSp deleted = _context.TLoaiSps.Find(loaiSP);
            _context.SaveChanges();
            return deleted;
        }

        public TLoaiSp Get(string loaiSP)
        {
            return _context.TLoaiSps.Find(loaiSP);
        }

        public IEnumerable<TLoaiSp> GetAll()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp Update(TLoaiSp entity)
        {
            _context.TLoaiSps.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
