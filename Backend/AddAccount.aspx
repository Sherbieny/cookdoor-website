<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAccount.aspx.cs" MasterPageFile="~/Backend.master" Inherits="Backend_AddAccount" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Log.ascx" TagName="ctrl_Log" TagPrefix="uc1" %>

    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 352px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <br /><br />

   <table>
        
        <tr>
            <td class="style1"><h2>Add Account</h2></td>
            <td><uc1:ctrl_log ID="ctrl_Log1" runat="server" /> </td>
        </tr>
    </table> 
    <asp:Panel ID="Panel1" CssClass="eswed" runat="server" GroupingText="User Data">
        <table width="100%">
            <tr>
                <td>Name : 
                <asp:TextBox ID="txt_user_name" MaxLength="100" runat="server" ToolTip="" ></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="Req1" Enabled="true" Text="Required!" runat="server" ControlToValidate="txt_user_name"></asp:RequiredFieldValidator>
                    
                </td>
                <td>
                    <asp:Button ID="btn_Report" OnClick="btn_Insert_Click"   
                    Text="Submit" CssClass="button"  runat="server"  />
                </td>
           </tr>
           <tr>
                   
                <td>
                Password :       
                    <asp:TextBox TextMode="Password" ID="txt_pass"  MaxLength="100" runat="server" ToolTip="" ></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" Enabled="true" Text="Required!" runat="server" ControlToValidate="txt_pass"></asp:RequiredFieldValidator>
              
                </td>
           </tr>

         <tr>
                   
                <td>
                Confirm Password :       
                    <asp:TextBox TextMode="Password" ID="txt_pass_again"  MaxLength="100" runat="server" ToolTip="" ></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" Enabled="true" Text="Required!" runat="server" ControlToValidate="txt_pass_again"></asp:RequiredFieldValidator>
              
                </td>
           </tr>
           
         
        </table>
   </asp:Panel>
               <br /><br /><br /><br /><br /><br /><br /><br /><br />
   
</asp:Content>

