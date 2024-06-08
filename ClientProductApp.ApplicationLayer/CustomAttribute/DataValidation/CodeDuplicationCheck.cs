using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProductApp.ApplicationLayer.CustomAttribute.DataValidation
{
    public class CodeDuplicationCheck : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value.ToString();
            
            var currentId = validationContext.ObjectInstance.GetType().GetProperty("Id")?.GetValue(validationContext.ObjectInstance, null).ToString() ?? "0";

            var ClientDbContext = validationContext.GetService(typeof(IGenericRepository<Client>)) as IGenericRepository<Client>;

            var isExist = ClientDbContext.GetEntityIQueryable().Any(x => x.Code == valueAsString && x.Id != Int32.Parse(currentId));

            return isExist ? new ValidationResult("Code Already Exist") : ValidationResult.Success;

        }
    }
}
