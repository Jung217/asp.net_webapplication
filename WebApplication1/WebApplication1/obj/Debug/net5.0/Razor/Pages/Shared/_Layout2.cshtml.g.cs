#pragma checksum "C:\Users\alex2\Desktop\WebApplication1\WebApplication1\Pages\Shared\_Layout2.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "afd09847654e7b0d93736d7fc8316a3ba027a965863c17daf07f6dac5b561377"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication1.Pages.Shared.Pages_Shared__Layout2), @"mvc.1.0.view", @"/Pages/Shared/_Layout2.cshtml")]
namespace WebApplication1.Pages.Shared
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\alex2\Desktop\WebApplication1\WebApplication1\Pages\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"afd09847654e7b0d93736d7fc8316a3ba027a965863c17daf07f6dac5b561377", @"/Pages/Shared/_Layout2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b62b7116ba96dcd8c94c8d1e354747201d602940c413cd6dd208c840f213370c", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Shared__Layout2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afd09847654e7b0d93736d7fc8316a3ba027a965863c17daf07f6dac5b5613773310", async() => {
                WriteLiteral(@"

    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
    <link href=""https://fonts.googleapis.com/css2?family=Poppins:wght@100;200;300;400;500;600;700;800;900&display=swap"" rel=""stylesheet"">

    <title>");
#nullable restore
#line 10 "C:\Users\alex2\Desktop\WebApplication1\WebApplication1\Pages\Shared\_Layout2.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>

    <!-- Bootstrap core CSS -->
    <link href=""vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"">


    <!-- Additional CSS Files -->
    <link rel=""stylesheet"" href=""assets/css/fontawesome.css"">
    <link rel=""stylesheet"" href=""assets/css/templatemo-lugx-gaming.css"">
    <link rel=""stylesheet"" href=""assets/css/owl.css"">
    <link rel=""stylesheet"" href=""assets/css/animate.css"">
    <link rel=""stylesheet"" href=""https://unpkg.com/swiper@7/swiper-bundle.min.css"" />
    <!--

    TemplateMo 589 lugx gaming

    https://templatemo.com/tm-589-lugx-gaming

    -->
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afd09847654e7b0d93736d7fc8316a3ba027a965863c17daf07f6dac5b5613775442", async() => {
                WriteLiteral(@"

    <!-- ***** Preloader Start ***** -->
    <div id=""js-preloader"" class=""js-preloader"">
        <div class=""preloader-inner"">
            <span class=""dot""></span>
            <div class=""dots"">
                <span></span>
                <span></span>
                <span></span>
            </div>
        </div>
    </div>
    <!-- ***** Preloader End ***** -->
    <!-- ***** Header Area Start ***** -->
    <header class=""header-area header-sticky"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12"">
                    <nav class=""main-nav"">
                        <!-- ***** Logo Start ***** -->
                        <a href=""index.html"" class=""logo"">
                            <img src=""assets/images/logo.png""");
                BeginWriteAttribute("alt", " alt=\"", 1754, "\"", 1760, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""width: 158px;"">
                        </a>
                        <!-- ***** Logo End ***** -->
                        <!-- ***** Menu Start ***** -->
                        <ul class=""nav"">
                            <li><a href=""index.html"">Home</a></li>
                            <li><a href=""shop.html"">Our Shop</a></li>
                            <li><a href=""product-details.html"">Product Details</a></li>
                            <li><a href=""contact.html"" class=""active"">Contact Us</a></li>
                            <li><a href=""#"">Sign In</a></li>
                        </ul>
                        <a class='menu-trigger'>
                            <span>Menu</span>
                        </a>
                        <!-- ***** Menu End ***** -->
                    </nav>
                </div>
            </div>
        </div>
    </header>
    <!-- ***** Header Area End ***** -->

    <div class=""page-heading header-text"">
        <div class=""container""");
                WriteLiteral(@">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <h3>Contact Us</h3>
                    <span class=""breadcrumb""><a href=""#"">Home</a>  >  Contact Us</span>
                </div>
            </div>
        </div>
    </div>

    <div class=""contact-page section"">
        <div class=""container"">
            <div class=""row"">
                ");
#nullable restore
#line 89 "C:\Users\alex2\Desktop\WebApplication1\WebApplication1\Pages\Shared\_Layout2.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
    </div>

    <footer>
        <div class=""container"">
            <div class=""col-lg-12"">
                <p>Copyright © 2048 LUGX Gaming Company. All rights reserved. &nbsp;&nbsp; <a rel=""nofollow"" href=""https://templatemo.com"" target=""_blank"">Design: TemplateMo</a></p>
            </div>
        </div>
    </footer>

    <!-- Scripts -->
    <!-- Bootstrap core JavaScript -->
    <script src=""vendor/jquery/jquery.min.js""></script>
    <script src=""vendor/bootstrap/js/bootstrap.min.js""></script>
    <script src=""assets/js/isotope.min.js""></script>
    <script src=""assets/js/owl-carousel.js""></script>
    <script src=""assets/js/counter.js""></script>
    <script src=""assets/js/custom.js""></script>

");
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
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591