<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="yacht.aspx.cs" Inherits="yacht.admin.yacht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="right">
        <asp:Button ID="AddButton" runat="server" Text="Add New Yacht" class="btn btn-primary" title="btn btn-primary" OnClick="AddButton_Click" />
    </div>
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
                                            <h5>Yacht List</h5>
                                        </div>
                                        <div class="card-body">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="100%" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" OnRowDeleting="GridView1_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="typeName" HeaderText="Yacht Type" SortExpression="typeName" ItemStyle-HorizontalAlign="Center"/>
                                                    <asp:CheckBoxField DataField="newDesign" HeaderText="New Design" SortExpression="newDesign" ItemStyle-HorizontalAlign="Center"/>
                                                    <asp:CheckBoxField DataField="newBuilding" HeaderText="New Building" SortExpression="newBuilding" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="LastModifiedDate" HeaderText="Last Modified Date" SortExpression="LastModifiedDate" ItemStyle-HorizontalAlign="Center"/>
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"updateYacht.aspx?id="+Eval("id")%>' Font-Size="Medium" class="btn  btn-secondary btn-sm">Edit</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="javascript:if(!window.confirm('Are you sure to delete this item?')) window.event.returnValue = false;" Text="Delete" class="btn  btn-secondary btn-sm"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT [id], [typeName], [newDesign], [newBuilding], [LastModifiedDate] FROM [yachtType]"></asp:SqlDataSource>
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
