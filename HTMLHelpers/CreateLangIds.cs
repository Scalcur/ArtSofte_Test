using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArtSofte_Test.Models;
using System.Collections.Generic;

namespace ArtSofte_Test.HTMLHelpers
{
    public static class CreateLangIds
    {
         public static HtmlString CreateLangIdList(this IHtmlHelper html,  List<EmployeeLanguage> list)
        {
        string result = "";

        foreach (EmployeeLanguage item in list)
        {
            result += $"{item.LangId},";
        }

        return new HtmlString(result.TrimEnd(','));
        }
    }
}