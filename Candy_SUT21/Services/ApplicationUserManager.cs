using Candy_SUT21.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candy_SUT21.Services
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly ICustomerRepository _customers;
        public ApplicationUserManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger,
            ICustomerRepository customers) : 
            base(store, optionsAccessor, passwordHasher, userValidators,
                passwordValidators, keyNormalizer, errors, services, logger)
        {
            _customers = customers;
        }

        public async Task<string> GetUserFullName(string id)
        {
            var customer = await _customers.GetCustomerByApplicationUserId(id);
            return customer == null ? "Dude" : customer.FirstName + " " + customer.LastName;
        }
    }
}
