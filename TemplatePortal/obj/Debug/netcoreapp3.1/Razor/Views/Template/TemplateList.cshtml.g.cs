#pragma checksum "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65571d3ef58028610dee72f50f6824404aca22a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Template_TemplateList), @"mvc.1.0.view", @"/Views/Template/TemplateList.cshtml")]
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
#line 1 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\_ViewImports.cshtml"
using TemplatePortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\_ViewImports.cshtml"
using TemplatePortal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
using EfDBContext;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65571d3ef58028610dee72f50f6824404aca22a8", @"/Views/Template/TemplateList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd78dce1fff9a182dbd34601cc94bc1eaa904b38", @"/Views/_ViewImports.cshtml")]
    public class Views_Template_TemplateList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Template>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Template.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65571d3ef58028610dee72f50f6824404aca22a84645", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "65571d3ef58028610dee72f50f6824404aca22a84972", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css"" />
    <link href=""http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.min.css""
          rel=""stylesheet"" type=""text/css"" />
    <script src=""http://code.jquery.com/jquery-1.10.2.js""></script>
    <script src=""http://code.jquery.com/ui/1.11.1/jquery-ui.js""></script>
    <script src=""https://cdn.ckeditor.com/ckeditor5/36.0.1/super-build/ckeditor.js""></script>
    <script src=""https://cdn.ckeditor.com/ckeditor5/36.0.1/super-build/translations/de.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>

    <script type=""text/javascript"">
       var url = '");
#nullable restore
#line 23 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
             Write(Url.Action("TemplateDetails", "Template"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';


        $(function () {
            $(""#templateDialog"").dialog({
                draggable: true,
                resizable: true,
                show: 'Transfer',
                hide: 'Transfer',
                width: '100%',
                height : 850,
                autoOpen: false,
                minHeight: 100,
                minwidth: 100,
                title : 'Template Preview'
            });

            $(""#divPreferences"").dialog({
                draggable: true,
                resizable: true,
                show: 'Transfer',
                hide: 'Transfer',
                width: '50%',
                height: 150,
                autoOpen: false,
                minHeight: 100,
                minwidth: 100,
                title: 'Preference'
            });
        });

        function loadTemplateDetails(templateId) {
            $('#templateDetails').val("""");
            $('#templateDetails').html("""");
            $('#templateDetails').");
                WriteLiteral("load(url, { templateId: templateId });\r\n            $(\"#templateDialog\").dialog(\"open\");\r\n\r\n        }\r\n\r\n\r\n    </script>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65571d3ef58028610dee72f50f6824404aca22a89099", async() => {
                WriteLiteral("\r\n    <div id=\"templateDialog\"");
                BeginWriteAttribute("title", " title=\"", 2201, "\"", 2209, 0);
                EndWriteAttribute();
                WriteLiteral(@">
       <div id=""templateDetails"">

       </div>
    </div>

    
    <h4>Template List</h4>
    <hr />
    <table cellpadding=""0"" cellspacing=""0"" class=""container table table-bordered table-responsive table-hover"">
        <tr>
            <th>Template ID</th>
            <th>Type</th>
            <th>Channels</th>
            <th>Language</th>
            <th>Status</th>
            <th>Created Date</th>
            <th></th>
        </tr>
");
#nullable restore
#line 85 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
         foreach (Template customer in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 88 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
               Write(customer.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 89 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
               Write(customer.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td></td>\r\n                <td></td>\r\n                <td> ");
#nullable restore
#line 92 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
                Write(customer.StatusName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 93 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
               Write(customer.CreatedDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>\r\n                    <p class=\"submit\"><input type=\"submit\" id=\"btnTemplateDetails\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3087, "\"", 3130, 3);
                WriteAttributeValue("", 3097, "loadTemplateDetails(", 3097, 20, true);
#nullable restore
#line 95 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
WriteAttributeValue("", 3117, customer.Id, 3117, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3129, ")", 3129, 1, true);
                EndWriteAttribute();
                WriteLiteral(" value=\"Edit Template\" /> \r\n                    </p>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 99 "C:\Users\bchaithanya\source\repos\TemplatePortal\TemplatePortal\Views\Template\TemplateList.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </table>\r\n");
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
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Template>> Html { get; private set; }
    }
}
#pragma warning restore 1591
