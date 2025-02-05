using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(dogLeash => dogLeash.Name).NotEmpty()
                                              .NotNull()
                                              .WithMessage("\"Name\" cannot be empty");
            RuleFor(dogLeash => dogLeash.Price).GreaterThan(0)
                                               .WithMessage("\"Price\" must be a positive number");
            RuleFor(dogLeash => dogLeash.Quantity).GreaterThan(-1)
                                                  .WithMessage("\"Quantity\" must be a positive number");
            RuleFor(dogLeash => dogLeash.Description).MinimumLength(10).WithMessage("\"Description\" must have at least 10 characters")
                                                     .When(dogLeash => dogLeash.Description != null);
        }
    }
}
