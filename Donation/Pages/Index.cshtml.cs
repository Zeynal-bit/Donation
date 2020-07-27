using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Donation.Data;
using Donation.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Globalization;
using Donation.Helpers;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Donation
{
    public class IndexModel : PageModel
    {
        private readonly PaymentDbContext _context;

        public IndexModel(PaymentDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaymentList PaymentList { get; set; }
        public PaymentViewModel listVM { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            var client = new HttpClient();

            var list = new PaymentList
            {
                UserName = "client10",
                Password = "1803",
                OrderNumber = Convert.ToString(Guid.NewGuid()),
                ReturnUrl = "https://localhost:44349/Payments/Register",
                Amount = PaymentList.Amount,
                Description = PaymentList.Description
            };

            var json = JsonConvert.SerializeObject(list);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://attest.turkmen-tranzit.com/payment/rest/register.do";

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            listVM = SimpleJson.DeserializeObject<PaymentViewModel>(result);


            list.formUrl = listVM.formUrl;
            list.orderId = listVM.orderId;

            _context.PaymentLists.Add(list);

            await _context.SaveChangesAsync();
            return Redirect(listVM.formUrl);
        }
    }
}
