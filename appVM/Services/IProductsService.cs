using appVM.Models;

namespace appVM.Services
{
    public interface IProductsService
    {
        List<Products> getProducts();
        Task<bool> isBeta();
    }
}