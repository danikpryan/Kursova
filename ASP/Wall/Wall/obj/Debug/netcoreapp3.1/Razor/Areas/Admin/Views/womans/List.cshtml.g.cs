#pragma checksum "D:\ВОВА\Diplom\ASP\Wall\Wall\Areas\Admin\Views\womans\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f41f4a2b8d0ca990eee74ef75108d8bff5822187"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_womans_List), @"mvc.1.0.view", @"/Areas/Admin/Views/womans/List.cshtml")]
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
#line 3 "D:\ВОВА\Diplom\ASP\Wall\Wall\Areas\Admin\Views\_ViewImports.cshtml"
using Wall.Domain.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f41f4a2b8d0ca990eee74ef75108d8bff5822187", @"/Areas/Admin/Views/womans/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"893da7b7923279365ce572901f5df019cbf045bc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_womans_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h3>");
#nullable restore
#line 1 "D:\ВОВА\Diplom\ASP\Wall\Wall\Areas\Admin\Views\womans\List.cshtml"
Write(Model.currCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<div class=\"row mt-5 mb-4\">\r\n");
#nullable restore
#line 3 "D:\ВОВА\Diplom\ASP\Wall\Wall\Areas\Admin\Views\womans\List.cshtml"
      
        foreach (Product product in Model.getAllProducts)
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ВОВА\Diplom\ASP\Wall\Wall\Areas\Admin\Views\womans\List.cshtml"
       Write(Html.Partial("AllProducts", product));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
