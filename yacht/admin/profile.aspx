<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="yacht.admin.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- [ Main Content ] start -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>User Info.</h5>
                </div>
                <div class="card-body" style="margin: auto;">
                    <asp:Literal ID="LiteralImg" runat="server"></asp:Literal>
                    <br />
                </div>
                <div class="card-body">
                    <div class="table-responsive" style="width: 100%; padding: 4px 10%">
                        <table class="table table-striped" style="text-align: center;">
                            <tbody>
                            <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Account" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="accountLab" runat="server" Font-Size="Medium"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Name" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="nameLab" runat="server" Font-Size="Medium"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="E-mail" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="mailLab" runat="server" Font-Size="Medium"></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="card-body" style="margin:auto;">
                    <asp:Button ID="Button1" runat="server" Text="Update" class="btn  btn-secondary btn-sm" OnClick="Button1_Click"/>
                </div>
            </div>
        </div>
    </div>
    <!-- [ Main Content ] end -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ManageMainContentPlaceHolder" runat="server">
</asp:Content>
