<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="CertificateContent.aspx.cs" Inherits="yacht.admin.CertificateContent" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- [ Main Content ] start -->
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5>Update Certificate Content</h5>
                                        </div>
                                        <div class="card-body">  
                                            <%--<asp:TextBox ID="ContentTB" runat="server" Width="100%" TextMode="MultiLine" Height="300px"></asp:TextBox>--%>
                                            <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/" Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image" Height="400px">
                                            </CKEditor:CKEditorControl>
                                        </div>
                                        <div class="card-body" style="margin:auto;">
                                            <asp:Button ID="UpdateButton" runat="server" Text="submit" class="btn  btn-secondary btn-sm" OnClick="UpdateButton_Click"/>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn  btn-secondary btn-sm" OnClick="CancelBtn_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
    <!-- [ Main Content ] end -->
</asp:Content>
