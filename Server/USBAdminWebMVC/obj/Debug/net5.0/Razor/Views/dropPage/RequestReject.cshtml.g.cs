#pragma checksum "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\dropPage\RequestReject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc8dd7b525db7d796c94e18369ed89270b3d4937"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_dropPage_RequestReject), @"mvc.1.0.view", @"/Views/dropPage/RequestReject.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc8dd7b525db7d796c94e18369ed89270b3d4937", @"/Views/dropPage/RequestReject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4594b8874090f6e413bd2d1f83140d4f6dde779b", @"/Views/_ViewImports.cshtml")]
    public class Views_dropPage_RequestReject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\dropPage\RequestReject.cshtml"
  
    var requestUrl = USBAdminHelp.WebHttpUrlPrefix + "/usb/RequestRejectList";
    var requestDetailUrl = USBAdminHelp.WebHttpUrlPrefix + "/usb/RequestDetail";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <fieldset class=""layui-elem-field layui-field-title"" style=""margin-top: 20px;"">
        <legend>UsbRequest Reject</legend>
    </fieldset>

    <table id=""index"" lay-filter=""index"" class=""layui-hide"">
    </table>
</div>

<script type=""text/html"" id=""usbRequest"">
    <a style=""color:blue;text-decoration:underline"" href=""javascript:;""");
            BeginWriteAttribute("layuimini-content-href", " layuimini-content-href=\"", 526, "\"", 580, 2);
#nullable restore
#line 16 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\dropPage\RequestReject.cshtml"
WriteAttributeValue("", 551, requestDetailUrl, 551, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 568, "?id={{d.id}}", 568, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-title=\"Request Detail\">{{d.id}}</a>\r\n</script>\r\n\r\n");
            DefineSection("Script", async() => {
                WriteLiteral(@"
    <script>
        layui.use(['form', 'table', 'miniTab'], function () {
            let form = layui.form,
                table = layui.table;
            let miniTab = layui.miniTab;

            table.render({
                elem: '#index'
                , url: '");
#nullable restore
#line 28 "C:\CodeRepos\USBAdmin\Server\USBAdminWebMVC\Views\dropPage\RequestReject.cshtml"
                   Write(requestUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'
                , page: true
                , cols: [[
                    { fixed: 'left', title: 'Id', toolbar: '#usbRequest', width: 60, sort: true },
                    { field: 'requestStateChangeTimeString', title: 'StateChange', width: 200, sort: true },
                    { field: 'manufacturer', title: 'Manufacturer', width: 150, sort: true },
                    { field: 'product', title: 'Product', width: 200, sort: true },
                    { field: 'vid_Hex', title: 'Vid', width: 100, sort: true },
                    { field: 'pid_Hex', title: 'Pid', width: 100 },
                    { field: 'serialNumber', title: 'SerialNumber', width: 250, sort: true },
                    { field: 'requestUserEmail', title: 'UserEmail', width: 250, sort: true },
                    { field: 'computerName', title: 'Computer', width: 150, sort: true },
                    { field: 'ip', title: 'IP', width: 150, sort: true }
                ]]
            });

            miniTab.listen()");
                WriteLiteral(";\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
