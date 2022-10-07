#pragma checksum "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\Computer\UsbLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "057dad0c5baa1d635c0b8551f753b12e76dcf926"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Computer_UsbLog), @"mvc.1.0.view", @"/Views/Computer/UsbLog.cshtml")]
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
#line 1 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\_ViewImports.cshtml"
using USBAdminWebMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\_ViewImports.cshtml"
using USBModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"057dad0c5baa1d635c0b8551f753b12e76dcf926", @"/Views/Computer/UsbLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4594b8874090f6e413bd2d1f83140d4f6dde779b", @"/Views/_ViewImports.cshtml")]
    public class Views_Computer_UsbLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tbl_ComputerInfo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\Computer\UsbLog.cshtml"
   
    var comIdentity = Model.ComputerIdentity;
    var usbLogListUrl = USBAdminHelp.WebHttpUrlPrefix + "/computer/UsbLogList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <fieldset class=\"layui-elem-field layui-field-title\" style=\"margin-top: 20px;\">\r\n        <legend>USB Log: ");
#nullable restore
#line 9 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\Computer\UsbLog.cshtml"
                    Write(Model.HostName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</legend>\r\n    </fieldset>\r\n\r\n    <table id=\"index\" lay-filter=\"index\" class=\"layui-hide\">\r\n    </table>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Script", async() => {
                WriteLiteral("\r\n    <script>\r\n        layui.use([\'form\', \'table\', \'layer\'], function () {\r\n            var form = layui.form,\r\n                table = layui.table;\r\n\r\n            table.render({\r\n                elem: \'#index\'\r\n                , url: \'");
#nullable restore
#line 25 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\Computer\UsbLog.cshtml"
                   Write(usbLogListUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n                , where: {comIdentity:\'");
#nullable restore
#line 26 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\Computer\UsbLog.cshtml"
                                  Write(comIdentity);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'}
                , page: true
                , limit: 50
                , cols: [[
                    { field: 'pluginTimeString', title: 'PluginTime', width: 200, sort: true },
                    { field: 'manufacturer', title: 'Manufacturer', width: 150, sort: true },
                    { field: 'product', title: 'Product', width: 200, sort: true },
                    { field: 'deviceDescription', title: 'Description', width: 200, sort: true },
                    { field: 'vid', title: 'Vid', width: 100, sort: true },
                    { field: 'pid', title: 'Pid', width: 100 },
                    { field: 'serialNumber', title: 'SerialNumber', width: 250, sort: true }
                ]]
            });
        });
    </script>

");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tbl_ComputerInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
