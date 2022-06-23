<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="updateYachtContent.aspx.cs" Inherits="yacht.admin.updateYachtContent" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- [ Main Content ] start -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Yacht Content</h5>
                </div>
                <div class="card-body">
                    <h6>Update Yacht Overview</h6>
                </div>
                <div class="card-body">
                    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/" Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
                        Height="400px">
                    </CKEditor:CKEditorControl>
                </div>
                <div class="card-body">
                    <h6>Update Yacht Layout</h6>
                </div>
                <div>
                    <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server" BasePath="/Scripts/ckeditor/" Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
                        Height="400px">
                    </CKEditor:CKEditorControl>
                </div>
                <div class="card-body">
                    <h6>Update Yacht Specification</h6>
                </div>
                <div>
                    <CKEditor:CKEditorControl ID="CKEditorControl3" runat="server" BasePath="/Scripts/ckeditor/" Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
                        Height="400px">
                    </CKEditor:CKEditorControl>
                </div>
                <div class="card-body" style="margin: auto;">
                    <asp:Button ID="UpdateButton" runat="server" Text="Next" class="btn  btn-secondary btn-sm" OnClick="UpdateButton_Click"/>
                </div>
            </div>
        </div>
    </div>
    <!-- [ Main Content ] end -->
</asp:Content>
