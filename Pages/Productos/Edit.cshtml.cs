using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TIENDA_WEB1.models;
using TIENDA_WEB1.Data;

namespace TIENDA_WEB1.Pages.Productos;

public class EditModel : PageModel
{
    private readonly TiendaContext _context;

    public EditModel(TiendaContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Producto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(Producto.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ProductoExists(int id)
    {
        return _context.Productos.Any(e => e.Id == id);
    }
}