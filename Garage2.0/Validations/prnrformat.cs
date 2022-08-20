using Garage2._0.Models;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage2._0.Validations
{
    public class prnrformat: RegularExpressionAttribute
    {
        public prnrformat() : base("[0-9]{6}-[0-9]{4}")
            {
                ErrorMessageResourceType = typeof(ValidationMessage);
                ErrorMessageResourceName = "Invalid";
            }
        }


    }

