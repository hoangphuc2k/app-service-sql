using appVM.Models;
using appVM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace appVM.Pages;

public class IndexModel : PageModel
{
    public List<Products> products;

    private readonly IProductsService productsService;

    public IndexModel(IProductsService productsService) {
        this.productsService = productsService;
    }

    public void OnGet()
    {
        products = productsService.getProducts();
    }
}

