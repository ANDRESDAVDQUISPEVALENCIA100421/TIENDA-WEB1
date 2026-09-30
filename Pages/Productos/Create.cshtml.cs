using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TIENDA_WEB1.models;
using TIENDA_WEB1.Data;

namespace TIENDA_WEB1.Pages.Productos;

public class CreateModel : PageModel
{
    private readonly TiendaContext _context;

    public CreateModel(TiendaContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Producto Producto { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Productos.Add(Producto);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}