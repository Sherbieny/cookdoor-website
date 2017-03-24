<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Backend.master" CodeFile="RemoveCategory.aspx.cs" Inherits="Backend_RemoveCategory" %>

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
            
            <td><uc1:ctrl_Log ID="ctrl_Log1" runat="server" /> </td>
        </tr>
    </table> 
               <br />

                   <h2>Categories: </h2>
                <br />
                <asp:GridView ID="thegrid" Width="1000px" Visible="true"
                AutoGenerateColumns="false" EnableModelValidation="true" runat="server" BackColor="White" 
                BorderColor="#CCCCCC" OnRowDeleting="RemoveBezra" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3"  GridLines="Both" >
                <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                                            <asp:BoundField DataField="Name_ar" HeaderText="الأسم" />
                                                            <asp:BoundField DataField="Path" HeaderText="Path" />
                                            
                                            <%--<asp:CommandField ShowDeleteButton="true"  />--%>
                                            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="DLinkButton" CssClass="ka3bo" runat="server" CausesValidation="False" OnClientClick="return confirm('Are you sure?');this.style.display = 'none'"
                                                        CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                <br /><br /><br /><br /><br /><br />
</asp:Content>

