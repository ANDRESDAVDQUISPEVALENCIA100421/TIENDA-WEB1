using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TIENDA_WEB1.models;
using TIENDA_WEB1.Data;

namespace TIENDA_WEB1.Pages.Productos;

public class DeleteModel : PageModel
{
    private readonly TiendaContext _context;

    public DeleteModel(TiendaContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Producto Producto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
            .FirstOrDefaultAsync(m => m.Id == id);

        if (producto is null)
        {
            return NotFound();
        }

        Producto = producto;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var producto = await _context.Productos.FindAsync(id);

        if (producto != null)
        {
            Producto = producto;
            _context.Productos.Remove(Producto);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}