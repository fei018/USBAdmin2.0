#pragma checksum "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\USB\UsbRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5b6841cd21776592df3567038ef1cc9c322e438"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_USB_UsbRequest), @"mvc.1.0.view", @"/Views/USB/UsbRequest.cshtml")]
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
#line 1 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\_ViewImports.cshtml"
using USBAdminWebMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\_ViewImports.cshtml"
using USBModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5b6841cd21776592df3567038ef1cc9c322e438", @"/Views/USB/UsbRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4594b8874090f6e413bd2d1f83140d4f6dde779b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_USB_UsbRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\USB\UsbRequest.cshtml"
  
    var usbDetailUrl = USBAdminHelp.WebHttpUrlPrefix + "/usb/RequestDetail";

    var usbReviewUrl = USBAdminHelp.WebHttpUrlPrefix + "/usb/RequestReviewList";
    var usbApproveUrl = USBAdminHelp.WebHttpUrlPrefix + "/usb/RequestApproveList";
    var usbRejectUrl = USBAdminHelp.WebHttpUrlPrefix + "/usb/RequestRejectList";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <fieldset class=""layui-elem-field layui-field-title"" style=""margin-top: 20px;"">
        <legend>USB Request</legend>
    </fieldset>

    <div class=""layui-input-inline"">
        <button class=""layui-btn layui-btn-primary"" type=""button"" data-btn=""click"" data-url=""");
#nullable restore
#line 16 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\USB\UsbRequest.cshtml"
                                                                                        Write(usbReviewUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <i class=\"layui-icon\">&#xe607;</i> Review\r\n        </button>\r\n    </div>\r\n\r\n    <div class=\"layui-input-inline\">\r\n        <button class=\"layui-btn layui-btn-primary\" type=\"button\" data-btn=\"click\" data-url=\"");
#nullable restore
#line 22 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\USB\UsbRequest.cshtml"
                                                                                        Write(usbApproveUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <i class=\"layui-icon\">&#xe605;</i> Approve\r\n        </button>\r\n    </div>\r\n\r\n    <div class=\"layui-input-inline\">\r\n        <button class=\"layui-btn layui-btn-primary\" type=\"button\" data-btn=\"click\" data-url=\"");
#nullable restore
#line 28 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\USB\UsbRequest.cshtml"
                                                                                        Write(usbRejectUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
            <i class=""layui-icon"">&#x1006;</i> Reject
        </button>
    </div>

    <hr />
    <table id=""index"" lay-filter=""index"" class=""layui-hide"">
    </table>
</div>

<script type=""text/html"" id=""action"">
    <a class=""layui-btn layui-btn-primary layui-border-blue layui-btn-xs"" href=""javascript:;""");
            BeginWriteAttribute("layuimini-content-href", " layuimini-content-href=\"", 1428, "\"", 1478, 2);
#nullable restore
#line 39 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\USB\UsbRequest.cshtml"
WriteAttributeValue("", 1453, usbDetailUrl, 1453, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1466, "?id={{d.id}}", 1466, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-title=\"USB Detail\">Detail</a>\r\n</script>\r\n\r\n");
            DefineSection("Script", async() => {
                WriteLiteral(@"
    <script>
        layui.use(['form', 'table', 'miniTab'], function () {
            var form = layui.form;
            var table = layui.table;
            var miniTab = layui.miniTab;

            var tableIns = table.render({
                elem: '#index'
                , url: '");
#nullable restore
#line 51 "C:\CodeRepos\USBAdmin2.0\Server\USBAdminWebMVC\Views\USB\UsbRequest.cshtml"
                   Write(usbReviewUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'
                , page: true
                , limit: 50
                , cols: [[
                    { field: 'id', title: 'Id', width: 60, sort: true },
                    { field: 'requestTimeString', title: 'RequestTime', width: 200, sort: true },
                    { field: 'manufacturer', title: 'Manufacturer', width: 150, sort: true },
                    { field: 'product', title: 'Product', width: 200, sort: true },
                    { field: 'vid', title: 'Vid', width: 100, sort: true },
                    { field: 'pid', title: 'Pid', width: 100 },
                    { field: 'serialNumber', title: 'SerialNumber', width: 250, sort: true },
                    { field: 'requestUserEmail', title: 'UserEmail', width: 250, sort: true },
                    { field: 'computerName', title: 'Computer', width: 150, sort: true },
                    { field: 'ip', title: 'IP', width: 150, sort: true },
                    { fixed: 'right', title: 'Action', toolbar: '#action', width: ");
                WriteLiteral(@"100 }
                ]]
            });

            let btnUsb = $('[data-btn=""click""]');
            $(btnUsb).on('click', function () {
                let url = $(this).attr('data-url');
                tableIns.reload({
                    url:url
                })
            })

            miniTab.listen();
        });             
    </script>
");
            }
            );
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
