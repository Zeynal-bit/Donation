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
    public class ListModel : PageModel
    {
        private readonly Donation.Data.PaymentDbContext _context;

        public ListModel(Donation.Data.PaymentDbContext context)
        {
            _context = context;
        }

        public IList<PaymentList> PaymentList { get;set; }

        public async Task OnGetAsync()
        {
            PaymentList = await _context.PaymentLists.ToListAsync();
        }
    }
}
