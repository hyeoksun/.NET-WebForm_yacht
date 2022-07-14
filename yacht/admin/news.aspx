<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="yacht.admin.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="right">
        <asp:Button ID="AddButton" runat="server" Text="Add News" class="btn btn-primary" title="btn btn-primary" OnClick="AddButton_Click"/>
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
                                            <h5>News List</h5>
                                        </div>
                                        <div class="card-body">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="100%" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" OnRowDeleting="GridView1_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                         </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="date" HeaderText="Release Date" SortExpression="date" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd}"/>
                                                    <asp:BoundField DataField="title" HeaderText="News Title" SortExpression="title" ItemStyle-HorizontalAlign="Center"/>
                                                    <asp:CheckBoxField DataField="isTop" HeaderText="Top News" SortExpression="isTop" ItemStyle-HorizontalAlign="Center"/>
                                                    <asp:BoundField DataField="lastMotifiedDate" HeaderText="Last Motified Date" SortExpression="lastMotifiedDate" ItemStyle-HorizontalAlign="Center"/>
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"updateNews.aspx?id="+Eval("id")%>' Font-Size="Medium" class="btn  btn-secondary btn-sm">Edit</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ShowHeader="False" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
<%--                                                            <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="javascript:if(!window.confirm('Are you sure to delete this item?')) window.event.returnValue = false;" Text="Delete" class="btn  btn-secondary btn-sm"></asp:Button>--%>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="javascript:if(!window.confirm('Are you sure to delete this item?')) window.event.returnValue = false;">刪除</asp:LinkButton>
                                                            </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT * FROM [news] ORDER BY [isTop] DESC, [date] DESC"></asp:SqlDataSource>
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
