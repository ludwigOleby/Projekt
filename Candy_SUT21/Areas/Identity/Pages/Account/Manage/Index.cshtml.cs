using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Candy_SUT21.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Candy_SUT21.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICustomerRepository _customers;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICustomerRepository customers)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customers = customers;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Please enter your first Name!")]
            [Display(Name = "First Name")]
            [StringLength(25)]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "Please Enter Your Last Name")]
            [Display(Name = "Last Name")]
            [StringLength(50)]
            public string LastName { get; set; }
            [Required(ErrorMessage = "Please Enter Your Address")]
            [Display(Name = "Street Address")]
            [StringLength(100)]
            public string Address { get; set; }
            [Required(ErrorMessage = "Please Enter your City Name")]
            [Display(Name = "City")]
            [StringLength(50)]
            public string City { get; set; }
            [Required(ErrorMessage = "Please Enter your Zip Code")]
            [Display(Name = "Zip Code")]
            [StringLength(5, MinimumLength = 5)]
            public string ZipCode { get; set; }
            [Required(ErrorMessage = "Please Enter your Phone Number")]
            [Display(Name = "Phone number")]
            [Phone]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;
            Input = new InputModel();

            if (user.CustomerId != null)
            {
                var userCustomer = await _customers.GetCustomerById((int)user.CustomerId);
                Input.FirstName = userCustomer.FirstName;
                Input.LastName = userCustomer.LastName;
                Input.Address = userCustomer.Address;
                Input.ZipCode = userCustomer.ZipCode;
                Input.City = userCustomer.City;
                Input.PhoneNumber = userCustomer.Phone;
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userCustomerId = user.CustomerId;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}
            if(userCustomerId != null)
            {
                var customerToUpdate = new Customer
                {
                    CustomerId = (int)userCustomerId,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Phone = Input.PhoneNumber,
                    Address = Input.Address,
                    ZipCode = Input.ZipCode,
                    City = Input.City
                };
                await _customers.UpdateCustomer(customerToUpdate);
            }
            
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

    }
}
