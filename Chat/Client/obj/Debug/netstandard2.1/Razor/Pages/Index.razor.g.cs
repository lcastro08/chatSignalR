#pragma checksum "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6d067e03822e91763a5bc6a250ac94460a287ae"
// <auto-generated/>
#pragma warning disable 1591
namespace Chat.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using Chat.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Projects\ChatSignalR\Chat\Chat\Client\_Imports.razor"
using Chat.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "form-group");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<label>User:</label>\r\n    ");
            __builder.OpenElement(4, "input");
            __builder.AddAttribute(5, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 8 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
                  userInput

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => userInput = __value, userInput));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n\r\n");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "form-group");
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.AddMarkupContent(12, "<label>Message:</label>\r\n    ");
            __builder.OpenElement(13, "input");
            __builder.AddAttribute(14, "type", "text");
            __builder.AddAttribute(15, "size", "40");
            __builder.AddAttribute(16, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 13 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
                              messageInput

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => messageInput = __value, messageInput));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n\r\n");
            __builder.OpenElement(20, "button");
            __builder.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
                  Send

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "disabled", 
#nullable restore
#line 16 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
                                    !IsConnected

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(23, "Send");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n\r\n<hr>\r\n");
            __builder.OpenElement(25, "ul");
            __builder.AddMarkupContent(26, "\r\n");
#nullable restore
#line 20 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
     foreach(var message in Messages)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(27, "                ");
            __builder.OpenElement(28, "li");
            __builder.AddContent(29, 
#nullable restore
#line 22 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
                     message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n");
#nullable restore
#line 23 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "E:\Projects\ChatSignalR\Chat\Chat\Client\Pages\Index.razor"
 
    private HubConnection hubConnection;
    private List<string> Messages = new List<string>();
    private string userInput;
    private string messageInput;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            var encodedMessage = $"{user}: {message}";
            Messages.Add(encodedMessage);
            StateHasChanged();
        });

        await hubConnection.StartAsync();
    }

    Task Send() => hubConnection.SendAsync("SendMessage", userInput, messageInput);

    public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

    public void Dispose()
    {
        _ = hubConnection.DisposeAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591