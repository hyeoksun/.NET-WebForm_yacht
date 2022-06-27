<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="yacht.admin.UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- [ Main Content ] start -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update User Info.</h5>
                </div>
                <div class="card-body" style="margin: auto;">
                    <asp:Literal ID="LiteralImg" runat="server"></asp:Literal>
                    <br />
                    <div>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="PhotoUpload" runat="server" Text="UPLOAD" class="btn  btn-secondary btn-sm" OnClick="PhotoUpload_Click" />
                        <br />
                        <asp:Label ID="FileLabel" runat="server" Text="" Font-Size="Medium" Visible="false"></asp:Label>
                    </div>
                    <br />
                </div>
                <div class="card-body">
                    <div class="table-responsive" style="width: 100%; padding: 4px 10%">
                        <table class="table table-striped" style="text-align: center;">
                            <tbody>
                            <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Account" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="AccountTB" runat="server" Width="60%" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Password" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server">Enter origin Password：</asp:Literal>
                                        <asp:TextBox ID="OriginPassTB" runat="server" Width="60%"></asp:TextBox>
                                        <asp:Literal ID="Literal2" runat="server">Enter new password：</asp:Literal>
                                        <asp:TextBox ID="NewPassTB" runat="server" Width="60%"></asp:TextBox>
                                        <asp:Literal ID="Literal3" runat="server">Enter new password again：</asp:Literal>
                                        <asp:TextBox ID="NewPassTB2" runat="server" Width="60%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="E-mail" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="EmailTB" runat="server" Width="60%"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="card-body" style="margin: auto;">
                    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn  btn-secondary btn-sm" OnClick="CancelBtn_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Submit" class="btn  btn-secondary btn-sm" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- [ Main Content ] end -->
</asp:Content>
