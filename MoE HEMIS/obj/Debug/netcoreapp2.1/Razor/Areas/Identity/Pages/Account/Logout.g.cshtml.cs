#pragma checksum "C:\Users\gemme\OneDrive\Documents\files\4th year\DBA\assignment\2. Net MVC 5 app\Moshe\MoE HEMIS\Areas\Identity\Pages\Account\Logout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acf321d273a4b4dd8650c17231b06987dc03df69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MoE_HEMIS.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_Logout), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Logout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Identity/Pages/Account/Logout.cshtml", typeof(MoE_HEMIS.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_Logout), null)]
namespace MoE_HEMIS.Areas.Identity.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\gemme\OneDrive\Documents\files\4th year\DBA\assignment\2. Net MVC 5 app\Moshe\MoE HEMIS\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\gemme\OneDrive\Documents\files\4th year\DBA\assignment\2. Net MVC 5 app\Moshe\MoE HEMIS\Areas\Identity\Pages\_ViewImports.cshtml"
using MoE_HEMIS.Areas.Identity;

#line default
#line hidden
#line 5 "C:\Users\gemme\OneDrive\Documents\files\4th year\DBA\assignment\2. Net MVC 5 app\Moshe\MoE HEMIS\Areas\Identity\Pages\_ViewImports.cshtml"
using MoE_HEMIS.Models;

#line default
#line hidden
#line 1 "C:\Users\gemme\OneDrive\Documents\files\4th year\DBA\assignment\2. Net MVC 5 app\Moshe\MoE HEMIS\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using MoE_HEMIS.Areas.Identity.Pages.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acf321d273a4b4dd8650c17231b06987dc03df69", @"/Areas/Identity/Pages/Account/Logout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c1cead7ca53bd6561c54ad7d00a5db286a8ff34", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78808af5add5a1692622cc20f325483d53a88370", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Logout : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\gemme\OneDrive\Documents\files\4th year\DBA\assignment\2. Net MVC 5 app\Moshe\MoE HEMIS\Areas\Identity\Pages\Account\Logout.cshtml"
  
    ViewData["Title"] = "Log out";

#line default
#line hidden
            BeginContext(70, 20, true);
            WriteLiteral("\r\n<header>\r\n    <h1>");
            EndContext();
            BeginContext(91, 17, false);
#line 8 "C:\Users\gemme\OneDrive\Documents\files\4th year\DBA\assignment\2. Net MVC 5 app\Moshe\MoE HEMIS\Areas\Identity\Pages\Account\Logout.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(108, 81, true);
            WriteLiteral("</h1>\r\n    <p>You have successfully logged out of the application.</p>\r\n</header>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LogoutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel>)PageContext?.ViewData;
        public LogoutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
