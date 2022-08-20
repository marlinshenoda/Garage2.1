using Garage2._0.Models;
using Garage2._0.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage2._0.Validations
{
    public class age: ValidationAttribute 
    {
       
        public void AddValidation(MembersViewModel context)
        {
            throw new NotImplementedException();
        }
    }


}
    
    

