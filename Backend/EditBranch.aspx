<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditBranch.aspx.cs" MasterPageFile="~/Backend.master" Inherits="Backend_EditBranch" %>

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
            <td class="style1"><h2>Select a Branch to edit</h2></td>
            <td><uc1:ctrl_Log ID="ctrl_Log1" runat="server" /> </td>
        </tr>
    </table> 
    <asp:Panel ID="Panel1" CssClass="eswed" Visible="false" runat="server" GroupingText="Branch Data">
        <table width="100%">
               <tr>
                <td>Name : <asp:TextBox ID="txt_branch_name" MaxLength="100" runat="server" ToolTip="" ></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="Req1" Enabled="true" Text="Required!" runat="server" ControlToValidate="txt_branch_name"></asp:RequiredFieldValidator>
                    
                </td>
                <td>
                    <asp:TextBox ID="txt_branch_name_ar" MaxLength="100" runat="server" ToolTip="" ></asp:TextBox> : أسم
                </td>
                <td>
                    <asp:Button ID="btn_Report"   
                    Text="Submit" CssClass="button"  runat="server" onclick="btn_Insert_Click" />
                </td>
           </tr>
           <tr>
                            <td> City : <asp:DropDownList ID="list_cities" runat="server" AutoPostBack="false"  ToolTip="" ></asp:DropDownList>
                </td>
                <td>
                </td>
                <td></td>
           </tr>
           <tr>
                <td>
                    Otlob Link 
                </td>
               <td align="left">
                    <asp:TextBox ID="txt_otlob" MaxLength="400" Width="400px" runat="server" ToolTip="" ></asp:TextBox>
                </td> 
                <td></td>    
           </tr>
           <tr>
                <td>
                    Facebook Link 
                </td>
               <td align="left">
                    <asp:TextBox ID="txt_facebook" MaxLength="400" Width="400px" runat="server" ToolTip="" ></asp:TextBox>
                </td> 
                <td></td>   
           </tr>
           <tr>
                <td>
                    Mail Link 
                </td>
               <td align="left"> 
                    <asp:TextBox ID="txt_mail" MaxLength="400" Width="400px" runat="server" ToolTip="" ></asp:TextBox>
                </td>
                 <td></td>       
           </tr>

         
        </table>
   </asp:Panel>
               <br />

                  <asp:GridView ID="thegrid" Width="1000px" Visible="true"
                AutoGenerateColumns="false" EnableModelValidation="true" runat="server" BackColor="White" 
                BorderColor="#CCCCCC" OnRowEditing="SelectBranch" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3"  GridLines="Both" >

                <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                                            <asp:BoundField DataField="Name_ar" HeaderText="الأسم" />
                                                            <asp:BoundField DataField="City_Name" HeaderText="City" />
                                            
                                            <%--<asp:CommandField ShowEditButton="true"  />--%>
                                            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton CssClass="ka3bo"  ID="DLinkButton" runat="server" CausesValidation="False"
                                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                </Columns>
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
   <br />
</asp:Content>
