<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addMembers.aspx.cs" Inherits="yacht.admin.addMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageMainContentPlaceHolder" runat="server">
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
                                        <h5>Add New Member</h5>
                                    </div>
                                    <div class="card-body">
                                        <asp:Literal ID="Literal1" runat="server">Account：</asp:Literal>
                                        <asp:TextBox ID="accountTB" runat="server"></asp:TextBox>
                                        <asp:Literal ID="Literal4" runat="server" Visible="False">The account is existed.</asp:Literal>
                                        <br />
                                        <br />
                                        <asp:Literal ID="Literal2" runat="server">Password：</asp:Literal>
                                        <asp:TextBox ID="passwordTB" runat="server" TextMode="Password"></asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:Literal ID="Literal3" runat="server">Name：</asp:Literal>
                                        <asp:TextBox ID="nameTB" runat="server"></asp:TextBox>
                                        <br /><br />
                                        <asp:Button ID="addMemberBtn" runat="server" Text="Add" class="btn  btn-secondary btn-sm" OnClick="addMemberBtn_Click" />
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
                                        <h5>Member List</h5>
                                    </div>
                                    <div class="card-body">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="100%" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnDataBound="GridView1_OnDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="account" HeaderText="Account" SortExpression="account" ItemStyle-HorizontalAlign="Center" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" ItemStyle-HorizontalAlign="Center" ReadOnly="True"></asp:BoundField>
                                                <%--<asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />--%>
                                                <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="email" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Max Power"  ItemStyle-HorizontalAlign="Center"  >
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="maxPowerchk" runat="server" Checked='<%# Eval("Maxpower") %>' ItemStyle-HorizontalAlign="Center"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="lastModifiedDate" HeaderText="Last Modified Date" SortExpression="lastModifiedDate" ReadOnly="True"/>
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
                                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT * FROM [members]"></asp:SqlDataSource>--%>
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
