<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="countries.aspx.cs" Inherits="yacht.admin.countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- [ Main Content ] start -->
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
                                        <h5>Add New Country</h5>
                                    </div>
                                    <div class="card-body">
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" Text="Add" class="btn  btn-secondary btn-sm" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- [ Main Content ] end -->
                        <!-- [ Main Content2 ] start -->
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card" width="100%">
                                    <div class="card-header">
                                        <h5>Country List</h5>
                                    </div>
                                    <div class="card-body">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="100%" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Country" SortExpression="Country">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="InitDate" HeaderText="Creation Date" SortExpression="InitDate" ItemStyle-HorizontalAlign="Center" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LastMotifiedDate" HeaderText="Last Motified Date" SortExpression="LastMotifiedDate" ItemStyle-HorizontalAlign="Center" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit" ShowHeader="False" ItemStyle-HorizontalAlign="Center">
                                                    <EditItemTemplate>
                                                        <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" class="btn btn-primary btn-sm text-white m-0"></asp:Button>
                                                        &nbsp;<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" class="btn btn-primary btn-sm text-white m-0"></asp:Button>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" class="btn  btn-secondary btn-sm"></asp:Button>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ShowHeader="False" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="javascript:if(!window.confirm('Are you sure to delete this item?')) window.event.returnValue = false;" Text="Delete" class="btn  btn-secondary btn-sm"></asp:Button>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:GridView>
                                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT * FROM [country]"></asp:SqlDataSource>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- [ Main Content2 ] end -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- [ Main Content ] end -->

</asp:Content>
