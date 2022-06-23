<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addYachtContent.aspx.cs" Inherits="yacht.admin.addYachtContent" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pcoded-wrapper">
        <div class="pcoded-content">
            <div class="pcoded-inner-content">
                <div class="main-body">
                    <div class="page-wrapper">
                        <!-- [ Main Content ] start -->
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>Add New Yacht</h5>
                                    </div>
                                    <div class="card-body" style="margin: auto; width: 90%;">
                                        <div style="margin-bottom: 30px;">
                                            <h5>Add Overview Content</h5>
                                            <ckeditor:ckeditorcontrol id="overviewCK" runat="server" basepath="/Scripts/ckeditor/" toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
                                                height="400px">
                                            </ckeditor:ckeditorcontrol>
                                        </div>
                                        <div style="margin-bottom: 30px;">
                                            <h5>Add Layout & Deck Plan</h5>
                                            <ckeditor:ckeditorcontrol id="layoutCK" runat="server" basepath="/Scripts/ckeditor/" toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
                                                                      height="400px">
                                            </ckeditor:ckeditorcontrol>
                                        </div>
                                        <div style="margin-bottom: 30px;">
                                            <h5>Add Specification Content</h5>
                                            <ckeditor:ckeditorcontrol id="specificationCK" runat="server" basepath="/Scripts/ckeditor/" toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
                                                                      height="400px">
                                            </ckeditor:ckeditorcontrol>
                                        </div>
                                    </div>
                                    <div style="margin: 10px auto;">
                                        <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="btn  btn-secondary btn-sm" OnClick="SubmitBtn_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- [ Main Content ] end -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
