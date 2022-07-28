using BaumKantin.Core.Models;
using BaumKantin.Core.Repositories;

namespace BaumKantin.Repository.Repositories
{
    public class ImageRepository : GenericRepository<ImageModel>,IImageRepository
    {
        public ImageRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
