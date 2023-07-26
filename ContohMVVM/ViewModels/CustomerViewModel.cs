using System;
using ContohMVVM.Models;

namespace ContohMVVM.ViewModels
{
	public class CustomerViewModel
	{
        

		public Customer Customer { get; set; }
		public CustomerViewModel()
		{
            Customer = new Customer
            {
                Name = "Scott Guthire",
                Street = "Redmond 123",
                City = "Redmond",
                State = "WA",
                ZipCode = 158989,
                Phone = "412-888-1212",
                BirthDay = new DateTime(1980, 12, 21),
                ContactTime = new TimeSpan(12, 0, 0),
                Balance = 123.45,
                ActiveCustomer = true
            };

            


        }
    }
}

