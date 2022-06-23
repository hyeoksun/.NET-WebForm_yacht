<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="yacht.admin.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- [ Main Content ] start -->
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5>About Us Content</h5>
                                        </div>
                                        <div class="card-body">        
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </div>
                                        <div class="card-body" style="text-align:left;">
                                            <asp:Literal ID="Literal2" runat="server" Text="Last Motified Date："></asp:Literal>
                                            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                            <br />
                                            <asp:Button ID="UpdateButton" runat="server" Text="Update Content" class="btn  btn-secondary btn-sm" OnClick="UpdateButton_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
    <!-- [ Main Content ] end -->
</asp:Content>
