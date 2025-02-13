using Invoices.Models;
using Invoices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Invoices.Pages.Invoices
{
    public class CreateModel : PageModel
    {
		private readonly ApplicationDBContext context;

		[BindProperty]
        public InvoiceDto Invoicedto { get; set; } = new();

        public CreateModel(ApplicationDBContext context)
        {
			this.context = context;
		}
        public void OnGet()
        {
        }

		public IActionResult OnPost()
		{
            if (!ModelState.IsValid)
            { return Page(); 
            }
            var invoice = new Invoice
            {
                Number = Invoicedto.Number,
                Status = Invoicedto.Status,
                IssueDate = Invoicedto.IssueDate,
                DueDate = Invoicedto.DueDate,

                Service=Invoicedto.Service,
                UnitPrice=Invoicedto.UnitPrice,
                Quantity=Invoicedto.Quantity,

                ClientName=Invoicedto.ClientName,
                Email  = Invoicedto.Email,
                Phone = Invoicedto.Phone,
                Address=Invoicedto.Address,

            };
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToPage("/Invoices/Index");
		}
	}
}
