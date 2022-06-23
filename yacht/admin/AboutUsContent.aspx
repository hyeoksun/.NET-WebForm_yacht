<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="AboutUsContent.aspx.cs" Inherits="yacht.admin.AboutUsContent" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <!-- [ Main Content ] start -->
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5>Update About Us Content</h5>
                                        </div>
                                        <div>
                                            <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server" BasePath="/Scripts/ckeditor/" Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image" Height="400px"></CKEditor:CKEditorControl>
                                       </div>
                                       <div style="margin:20px auto;">
                                           <asp:Button ID="SubmitBTN" runat="server" Text="Submit" OnClick="SubmitBTN_Click" class="btn  btn-secondary btn-sm" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn  btn-secondary btn-sm" OnClick="CancelBtn_Click" />
                                       </div>
                                    </div>
                                </div>
                            </div>
    <!-- [ Main Content ] end -->
</asp:Content>
