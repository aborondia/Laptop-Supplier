#pragma checksum "C:\Users\MZ-admin\Desktop\SD\Assignments\LaptopSupplier\LaptopSupplier\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00499060da7cee823175fee5defa359f5a3b173a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "C:\Users\MZ-admin\Desktop\SD\Assignments\LaptopSupplier\LaptopSupplier\Views\_ViewImports.cshtml"
using LaptopSupplier;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MZ-admin\Desktop\SD\Assignments\LaptopSupplier\LaptopSupplier\Views\_ViewImports.cshtml"
using LaptopSupplier.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00499060da7cee823175fee5defa359f5a3b173a", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86be5953a53f41e283ac7cefb8c3f374a7a646fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Greetings Admin User</h1>\r\n\r\n<h2>What action do you wish to perform?</h2>\r\n<ul class=\"list-unstyled\">\r\n  <li>");
#nullable restore
#line 5 "C:\Users\MZ-admin\Desktop\SD\Assignments\LaptopSupplier\LaptopSupplier\Views\Admin\Index.cshtml"
 Write(Html.ActionLink("Add New Brand", "AddBrand", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n  <li>");
#nullable restore
#line 6 "C:\Users\MZ-admin\Desktop\SD\Assignments\LaptopSupplier\LaptopSupplier\Views\Admin\Index.cshtml"
 Write(Html.ActionLink("Remove Existing Brand", "RemoveBrand", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n  <li>");
#nullable restore
#line 7 "C:\Users\MZ-admin\Desktop\SD\Assignments\LaptopSupplier\LaptopSupplier\Views\Admin\Index.cshtml"
 Write(Html.ActionLink("Add New Product", "AddLaptop", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n  <li>");
#nullable restore
#line 8 "C:\Users\MZ-admin\Desktop\SD\Assignments\LaptopSupplier\LaptopSupplier\Views\Admin\Index.cshtml"
 Write(Html.ActionLink("Remove Existing Product", "RemoveProduct", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n</ul>");
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