#pragma checksum "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28970ee19f9e0c29e49dc6abf92a5b4d0230140d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_GetAllProducts), @"mvc.1.0.view", @"/Views/Product/GetAllProducts.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\_ViewImports.cshtml"
using MyApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\_ViewImports.cshtml"
using MyApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28970ee19f9e0c29e49dc6abf92a5b4d0230140d", @"/Views/Product/GetAllProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11677bef14cb8a5c5f02f7f352b9baf0a6209476", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_GetAllProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyApp.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
  
    ViewData["Title"] = "GetAllProducts";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<nav class=""navbar navbar-expand-lg navbar-light bg-light"">
    <a class=""navbar-brand"" href=""#"">GetAllProducts</a>
    <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarNavDropdown"" aria-controls=""navbarNavDropdown"" aria-expanded=""false"" aria-label=""Toggle navigation"">
        <span class=""navbar-toggler-icon""></span>
    </button>
    <div class=""collapse navbar-collapse"" id=""navbarNavDropdown"">
        <ul class=""navbar-nav"">
        </ul>
    </div>
</nav>

<p>
    ");
#nullable restore
#line 19 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
Write(Html.ActionLink("Create New", "AddProduct", null, htmlAttributes: new { @class = "btn btn-outline-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("       |       ");
#nullable restore
#line 19 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
                                                                                                                            Write(Html.ActionLink("Home", "Index", "Home", null, htmlAttributes: new { @class = "btn btn-outline-secondary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 25 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 28 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 31 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
       Write(Html.DisplayNameFor(model => model.Pkgd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 34 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
       Write(Html.DisplayNameFor(model => model.Exp));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 37 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
       Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 42 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.DisplayFor(modelItem => item.Pkgd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.DisplayFor(modelItem => item.Exp));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.DisplayFor(modelItem => item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.ActionLink("Edit", "EditProduct", new { id = item.ProductId }, htmlAttributes: new { @class = "btn btn-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 62 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.ActionLink("Details", "ViewPro", new { id = item.ProductId }, htmlAttributes: new { @class = "btn btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 63 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
           Write(Html.ActionLink("Delete", "DeleteProduct", new { id = item.ProductId }, new { onclick = "return confirm('Confirm Delete?');", @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 67 "C:\Users\RANGANATHAN\source\repos\MyApp\Views\Product\GetAllProducts.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyApp.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591