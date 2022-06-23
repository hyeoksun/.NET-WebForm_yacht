<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addYacht.aspx.cs" Inherits="yacht.admin.addYacht" %>

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
                                        <div style="margin-bottom: 14px; line-height: 28px">
                                            <h5>Yacht Name</h5>
                                            <asp:TextBox ID="typeName" runat="server" Width="80%"></asp:TextBox><br/>
                                        </div>
                                        <div style="margin-bottom: 30px; line-height: 14px">
                                            <asp:CheckBox ID="newDesignCheck" runat="server" Text="Check button if this yacht is new design" /><br/>
                                            <asp:CheckBox ID="newBuildingCheck" runat="server" Text="Check button if this yacht is new building" />
                                        </div>
                                        <div style="margin-bottom: 30px; line-height: 28px">
                                            <h5>Video Link</h5>
                                            <asp:Literal ID="Literal1" runat="server">If there is a video for this yacht, please put the link in the bow below.</asp:Literal><br/>
                                            <asp:TextBox ID="videoTB" runat="server" Width="80%"></asp:TextBox>
                                        </div>
                                        <div style="margin-bottom: 30px;">
                                            <h5>Add Yacht Banner</h5>
                                            <asp:Literal ID="Literal2" runat="server">Please upload a photo to be a banner, and it will display on index.</asp:Literal><br/>
                                            <asp:FileUpload ID="bannerUpload" runat="server" />
                                        </div>
                                        <div style="margin-bottom: 30px;">
                                            <h5>Add Attachments</h5>
                                            <asp:Literal ID="Literal3" runat="server">Please upload all attachments of yacht, and can choose multiple attachments at one time.</asp:Literal><br/>
                                            <asp:FileUpload ID="attachedUpload" runat="server" AllowMultiple="True"/>
                                        </div>
                                        <div style="margin-bottom: 30px;">
                                            <h5>Add Yacht Photos</h5>
                                            <asp:Literal ID="Literal4" runat="server">Please upload all photos of yacht, and can choose multiple photos at one time.</asp:Literal><br/>
                                            <asp:FileUpload ID="yachtPhotosUpload" runat="server" AllowMultiple="True" />
                                        </div>
                                        <div style="margin-bottom: 30px;">
                                            <asp:Literal ID="Literal5" runat="server">If you finished information of yacht, please enter "Next" to finish other content.</asp:Literal><br/>
                                        </div>
                                    </div>
                                    <div style="margin: 10px auto;">
                                        <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn  btn-secondary btn-sm" OnClick="CancelBtn_Click"/>
                                        &nbsp;&nbsp;
                                        <asp:Button ID="SubmitBtn" runat="server" Text="Next" class="btn  btn-secondary btn-sm" OnClick="SubmitBtn_Click"/>
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
