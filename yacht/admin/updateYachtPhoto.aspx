<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="updateYachtPhoto.aspx.cs" Inherits="yacht.admin.updateYachtPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- [ Main Content ] start -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Yacht Photos</h5>
                </div>
                <div class="card-body">
                    <div>
                        <asp:FileUpload ID="photoUpload" runat="server" AllowMultiple="True" />
                        <asp:Button ID="UploadBtn" runat="server" Text="UPLOAD" class="btn  btn-secondary btn-sm" OnClick="UploadBtn_Click" />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="" Font-Size="Medium" Visible="false"></asp:Label>
                    </div>
                    <br />
                </div>
                <div class="card-body">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CellPadding="10" RepeatColumns="2" RepeatDirection="Horizontal"></asp:RadioButtonList>
                        <asp:Button ID="deleteBtn" runat="server" Text="Delete" class="btn btn-outline-danger" OnClick="deleteBtn_Click"/>
                    </div>
                <div class="card-body" style="margin: auto ;">
                    <asp:Button ID="UpdateButton" runat="server" Text="Submit" class="btn  btn-secondary btn-sm" OnClick="UpdateButton_Click"/>
                </div>
            </div>
        </div>
    </div>
    <!-- [ Main Content ] end -->
</asp:Content>
