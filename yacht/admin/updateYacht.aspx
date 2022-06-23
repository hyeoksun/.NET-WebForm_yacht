<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="updateYacht.aspx.cs" Inherits="yacht.admin.updateYacht" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- [ Main Content ] start -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Yacht Info.</h5>
                </div>
                <div class="card-body">
                    <h6>Update Yacht Banner</h6>
                </div>
                <div class="card-body" style="margin: auto;">
                    <asp:Literal ID="LiteralImg" runat="server"></asp:Literal>
                    <br />
                </div>
                <div style="margin: auto;">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="PhotoUpload" runat="server" Text="UPLOAD" class="btn  btn-secondary btn-sm" OnClick="PhotoUpload_Click" />
                    <br />
                    <asp:Label ID="FileLabel" runat="server" Text="" Font-Size="Medium" Visible="false"></asp:Label>
                    <br />
                </div>
                <div class="card-body">
                    <h6>Update Yacht Info.</h6>
                    <div class="table-responsive" style="width: 100%; padding: 4px 10%">
                        <table class="table table-striped" style="text-align: center;">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Type" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="nameTB" runat="server" Width="60%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Is new design" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:CheckBox ID="newDesignCB" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Is new building" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:CheckBox ID="newBuildingCB" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Video Link" Font-Size="Medium"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="videoTB" runat="server" Width="60%"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="card-body">
                    <h6>Update Yacht Attachment</h6>
                </div>
                <div class="card-body">
                    <div>
                        <asp:FileUpload ID="FileUpload3" runat="server" AllowMultiple="True" />
                        <asp:Button ID="UploadBtn" runat="server" Text="UPLOAD" class="btn  btn-secondary btn-sm" OnClick="FileUpload_Click" />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="" Font-Size="Medium" Visible="false"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="80%" GridLines="None" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fileName" HeaderText="" SortExpression="fileName" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="javascript:if(!window.confirm('Are you sure to delete this item?')) window.event.returnValue = false;" Text="Delete"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT [id], [fileName], [yacht_id] FROM [yachtFile] WHERE ([yacht_id] = @yacht_id)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="yacht_id" QueryStringField="id" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
                <div class="card-body" style="margin: auto;">
                    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn  btn-secondary btn-sm" OnClick="CancelBtn_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="NextBtn" runat="server" Text="Next" class="btn  btn-secondary btn-sm" OnClick="NextBtn_Click" />

                </div>
            </div>
        </div>
    </div>
    <!-- [ Main Content ] end -->
</asp:Content>
