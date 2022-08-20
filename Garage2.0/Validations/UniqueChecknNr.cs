using Garage2._0.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Validations
{
    public class UniqueChecknNr: ValidationAttribute
    {
        private object _context;

       


        public string ErrorMessage { get; }

        public void AddValidation(MembersViewModel context)
        {
            throw new NotImplementedException();
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
