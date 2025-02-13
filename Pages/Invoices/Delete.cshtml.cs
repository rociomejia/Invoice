using Invoices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Invoices.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDBContext context;

		public DeleteModel(ApplicationDBContext context)
        {
			this.context = context;
		}
        public IActionResult OnGet(int id)
        {
			var invoice = context.Invoices.Find(id);
			if (invoice != null)
			{
				context.Invoices.Remove(invoice);
				context.SaveChanges();
			}
			return RedirectToPage("/Invoices/Index");
		}
    }
}
