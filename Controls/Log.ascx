<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Log.ascx.cs" Inherits="Controls_Log" %>
<table style="width:240px;">
    <tr>
        <td style="width:26px;" style="vertical-align:top">
        <asp:Image ID="img_error" runat="server" Height="20px" ImageUrl="~/Images/error.png" Width="20px" Visible="False" />
        <asp:Image ID="img_success" runat="server" Height="20px" ImageUrl="~/Images/success.png" Width="20px" Visible="False" />
        </td>

        <td style="text-align:left;vertical-align:top">
        <asp:Label ID="lb_error" runat="server" Font-Size="Large" Text="Label" BackColor="White" Visible="False"></asp:Label>
        </td>
    </tr>
</table>