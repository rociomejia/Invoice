using Invoices.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services

{
	public class ApplicationDBContext: DbContext

	{
		public ApplicationDBContext(DbContextOptions options):base(options)
		{

		}
		public DbSet<Invoice> Invoices { get; set; } = null!;
	}
}
