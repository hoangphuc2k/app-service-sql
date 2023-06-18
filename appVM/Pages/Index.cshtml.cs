using appVM.Models;
using appVM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace appVM.Pages;

public class IndexModel : PageModel
{
    public List<Products> products;

    public void OnGet()
    {
        ProductsService productsService = new ProductsService();

        products = productsService.getProducts();
    }
}

