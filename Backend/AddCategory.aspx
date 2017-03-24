<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.master" CodeFile="AddCategory.aspx.cs" Inherits="Backend_AddCategory" %>

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
            <td class="style1"><h2>Add New Category</h2></td>
            <td><uc1:ctrl_Log ID="ctrl_Log1" runat="server" /> </td>
        </tr>
    </table> 
    <asp:Panel ID="Panel1" CssClass="eswed" runat="server" GroupingText="Category Data">
        <table width="100%">
            <tr>
                <td>Name : <asp:TextBox ID="txt_category_name" MaxLength="100" runat="server" ToolTip="" ></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="Req1" Enabled="true" Text="Required!" runat="server" ControlToValidate="txt_category_name"></asp:RequiredFieldValidator>
                    
                </td>
                <td>
                    <asp:TextBox ID="txt_category_name_ar" MaxLength="100" runat="server" ToolTip="" ></asp:TextBox> : أسم
                </td>
                <td>
                    <asp:Button ID="btn_Report"   
                    Text="Submit" CssClass="button"  runat="server" onclick="btn_Insert_Click" />
                </td>
           </tr>
           
           <tr>
                
               <td align="left" colspan="3">
                    Upload Image :  
                    <asp:FileUpload ID="upload_path" MaxLength="400" Width="200px" runat="server" ToolTip="" ></asp:FileUpload>
                </td> 
                
           </tr>
           

         
        </table>
   </asp:Panel>
             
                <br />
                <asp:GridView ID="thegrid" Width="1000px" Visible="true"
                AutoGenerateColumns="true" EnableModelValidation="true" runat="server" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3"  GridLines="Both" >
                 <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#227A42" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle  HorizontalAlign="Center" CssClass="eswed" ForeColor="#000" />
                 <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
   
</asp:Content>
