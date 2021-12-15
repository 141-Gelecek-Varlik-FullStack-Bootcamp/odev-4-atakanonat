#pragma checksum "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1870fc52260edcef7c61b79dece13138522db777"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ProductList), @"mvc.1.0.view", @"/Views/Product/ProductList.cshtml")]
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
#line 1 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/_ViewImports.cshtml"
using Comm.API;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/_ViewImports.cshtml"
using Comm.API.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
using Comm.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
using Comm.Model.Product;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1870fc52260edcef7c61b79dece13138522db777", @"/Views/Product/ProductList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc0fe6203ae8ac6a83369fff828b5cffc4e53846", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ProductList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
  
    var Products = (List<Common<Product>>)ViewBag.Products;
    ViewData["title"] = "Product List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1870fc52260edcef7c61b79dece13138522db7773603", async() => {
                WriteLiteral("\n    <h1>Product List</h1>\n    <br />\n");
#nullable restore
#line 11 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
     foreach (var product in Products)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <ul>\n            <p><b>Product: </b>");
#nullable restore
#line 14 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
                          Write(product.Entity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n            <li>\n                <p>Description:");
#nullable restore
#line 16 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
                          Write(product.Entity.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n            </li>\n            <li>\n                <p>Stock Count:");
#nullable restore
#line 19 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
                          Write(product.Entity.Stock);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n            </li>\n            <li>\n                <p>Price:");
#nullable restore
#line 22 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
                    Write(product.Entity.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n            </li>\n        </ul>\n        <br />\n");
#nullable restore
#line 26 "/Users/atakanonat/dev/C#/odev-4/Comm.API/Views/Product/ProductList.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
