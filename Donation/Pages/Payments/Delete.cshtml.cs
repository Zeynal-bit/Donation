using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Donation.Data;
using Donation.Models;

namespace Donation
{
    public class DeleteModel : PageModel
    {
        private readonly Donation.Data.PaymentDbContext _context;

        public DeleteModel(Donation.Data.PaymentDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaymentList PaymentList { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PaymentList = await _context.PaymentLists.FirstOrDefaultAsync(m => m.orderId == id);

            if (PaymentList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PaymentList = await _context.PaymentLists.FindAsync(id);

            if (PaymentList != null)
            {
                _context.PaymentLists.Remove(PaymentList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
