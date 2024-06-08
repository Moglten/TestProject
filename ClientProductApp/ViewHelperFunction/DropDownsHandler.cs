using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ClientProductApp.ViewHelper
{
    public static class DropDownsHandler
    {
        public static SelectList GetSelectList<TEnum>() where TEnum : Enum
        {
            var itemValues = Enum.GetValues(typeof(TEnum)) as Array;
            var dropDownList = new List<SelectListItem>();

            for (var i = 0; i < itemValues.Length; i++)
            {
                dropDownList.Add(new SelectListItem
                {
                    Value = (i).ToString(),
                    Text = itemValues.GetValue(i)?.ToString()
                });
            }

            return new SelectList(dropDownList, "Value", "Text");

        }
    }
}
