<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="updateNews.aspx.cs" Inherits="yacht.admin.updateNews" %>
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
                                            <h5>Add News Content</h5>
                                        </div>
                                        <div class="card-body" style="margin:auto;width:90%;">
                                            <div style="margin-bottom:30px;">
                                                <h5>Update release date</h5>
                                                <input type="date" runat="server" id="postDateTB" />
                                                <%--<asp:TextBox ID="postDateTB" runat="server" ReadOnly="true"></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/admin/images/calendar.png" width="4%" OnClick="ImageButton1_Click"/>
                                                <br/>
                                                <br/>
                                                <asp:DropDownList ID="yearDDL" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="yearDDL_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:DropDownList ID="monthDDL" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="yearDDL_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Calendar ID="Calendar1" runat="server" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>--%>
                                            </div>
                                            <div style="margin-bottom:30px;line-height:28px">
                                                <h5>Update News Title</h5>
                                                <asp:TextBox ID="titleTB" runat="server" Width="80%"></asp:TextBox>
                                                <br/>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Check button if this news is top news"/> 
                                            </div>
                                            <div style="margin-bottom:30px;">
                                                <h5>Update News Content</h5>

                                            </div>
                                            <div style="margin-bottom:30px;">
                                                <h5>
                                                    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/" Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image" Height="400px">
                                                    </CKEditor:CKEditorControl>
                                                    Update News summary</h5>
                                                <asp:TextBox ID="summaryTB" runat="server" Width="80%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div style="margin-bottom:30px;">
                                                <h5>Update News thumbnail</h5>
                                                 <asp:Literal ID="LiteralImg" runat="server"></asp:Literal>
                                                <br/>
                                                <asp:FileUpload ID="thumbnailUpload" runat="server"/>
                                                <asp:Button ID="PhotoUpload" runat="server" Text="UPDATE" class="btn  btn-secondary btn-sm" OnClick="PhotoUpload_Click"/>
                                                <br/>
                                                <asp:Label ID="FileLabel" runat="server" Text="" font-size="Medium" Visible="false"></asp:Label>
                                            </div>
                                            <div style="margin-bottom:30px;">
                                                <h5>Update attached</h5>
                                                <asp:FileUpload ID="attachedUpload" runat="server" AllowMultiple="True" />
                                            </div>
                                        </div>
                                        <div style="margin:10px auto;">
                                            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="btn  btn-secondary btn-sm" OnClick="SubmitBtn_Click" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn  btn-secondary btn-sm" OnClick="CancelBtn_Click" />
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
