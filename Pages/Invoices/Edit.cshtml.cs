using Invoices.Models;
using Invoices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Numerics;

namespace Invoices.Pages.Invoices
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public InvoiceDto Invoicedto { get; set; } = new InvoiceDto();
		public Invoice Invoice {get; set; } = new();

		private readonly ApplicationDBContext context;

		public EditModel(ApplicationDBContext context)
        {
			this.context = context;
		}
        public IActionResult OnGet(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }
            Invoice = invoice;

		
			Invoicedto.Number = invoice.Number;
            Invoicedto.Status = invoice.Status;
            Invoicedto.IssueDate = invoice.IssueDate;
            Invoicedto.DueDate = invoice.DueDate;

            Invoicedto.Service = invoice.Service;
			Invoicedto.UnitPrice = invoice.UnitPrice;
			Invoicedto.Quantity = invoice.Quantity;

			Invoicedto.ClientName = invoice.ClientName;
			Invoicedto.Email = invoice.Email;
			Invoicedto.Phone = invoice.Phone;
			Invoicedto.Address = invoice.Address;
            return Page();
        }

		public string successMessage = "";
		public IActionResult OnPost(int id)
		{
			var invoice = context.Invoices.Find(id);
			if (invoice == null)
			{
				return RedirectToPage("/Invoices/Index");
			}
			Invoice = invoice;
			if (!ModelState.IsValid)
			{
				return Page();
			}

			invoice.Number = Invoicedto.Number;
			invoice.Status = Invoicedto.Status;
			invoice.IssueDate = Invoicedto.IssueDate;
			invoice.IssueDate = Invoicedto.DueDate;

			invoice.Service = Invoicedto.Service;
			invoice.UnitPrice = Invoicedto.UnitPrice;
			invoice.Quantity = Invoicedto.Quantity;

			invoice.ClientName = Invoicedto.ClientName;
			invoice.Email = Invoicedto.Email;
			invoice.Phone = Invoicedto.Phone;
			invoice.Address = Invoicedto.Address;

			context.SaveChanges();
			successMessage = "Success";
			return Page();
		}
	}
}
