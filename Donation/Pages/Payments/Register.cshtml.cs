﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Donation.Data;
using Donation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace Donation
{
    public class RegisterModel : PageModel
    {
        private readonly PaymentDbContext _context;

        public RegisterModel(PaymentDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaymentList PaymentList { get; set; }
        public PaymentViewModel listVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = new HttpClient();

            var payments = _context.PaymentLists.ToList();

            int successfulPayment = 2;
            int successfulPaymentWithADelay = 8;

            foreach (var payment in payments)
            {
                var paymentList = new PaymentList
                {
                    UserName = payment.UserName,
                    Password = payment.Password,
                    orderId = payment.orderId
                };

                var json = JsonConvert.SerializeObject(paymentList);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://attest.turkmen-tranzit.com/payment/rest/getOrderStatus.do";

                var response = await client.PostAsync(url, data);

                var result = await response.Content.ReadAsStringAsync();

                listVM = SimpleJson.DeserializeObject<PaymentViewModel>(result);
            };

            if (listVM.orderStatus == successfulPayment || listVM.orderStatus == successfulPaymentWithADelay)
            {
                return RedirectToPage("./List");
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }
}