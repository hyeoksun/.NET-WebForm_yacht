<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addDealer.aspx.cs" Inherits="yacht.admin.addDealer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
                            <!-- [ Main Content ] start -->
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5>Add Dealer Info.</h5>
                                        </div>
                                        <div class="card-body">        
                                            <div class="table-responsive" style="width:100%;padding:4px 10%">
                                                <table class="table table-striped" style="text-align:center;">
                                                    <%--<thead>
                                                        <tr>
                                                            <th>Item</th>
                                                            <th>Content</th>
                                                        </tr>
                                                    </thead>--%>
                                                    <tbody>
                                                        <tr>
                                                            <td><asp:Label ID="Label1" runat="server" Text="Select Country" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:DropDownList ID="CountryList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country" DataValueField="id" Width="60%" AppendDataBoundItems="True">
                                                                <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT [Country], [id] FROM [country]"></asp:SqlDataSource>
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td><asp:Label ID="Label2" runat="server" Text="Area" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="AreaTB" runat="server" Width="60%"></asp:TextBox></td> 
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label3" runat="server" Text="Company" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="CompanyTB" runat="server" Width="60%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label4" runat="server" Text="Contact" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="ContactTB" runat="server" Width="60%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label5" runat="server" Text="Address" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="AddressTB" runat="server" Width="60%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label6" runat="server" Text="TEL" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="TelTB" runat="server" Width="60%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label7" runat="server" Text="FAX" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="FaxTB" runat="server" Width="60%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label8" runat="server" Text="E-mail" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="EmailTB" runat="server" Width="60%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label9" runat="server" Text="Website" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:TextBox ID="WebsiteTB" runat="server" Width="60%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label10" runat="server" Text="Dealer Photo" Font-Size="Medium"></asp:Label></td>
                                                            <td><asp:FileUpload ID="FileUpload1" runat="server" Width="60%"/></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="card-body" style="margin:auto;">
                                            <asp:Button ID="SubmitButton" runat="server" Text="submit" class="btn  btn-secondary btn-sm" OnClick="SubmitButton_Click"/>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn  btn-secondary btn-sm" OnClick="CancelBtn_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
    <!-- [ Main Content ] end -->
 
</asp:Content>
