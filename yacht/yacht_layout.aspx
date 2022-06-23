<%@ Page Title="" Language="C#" MasterPageFile="~/yachtType.Master" AutoEventWireup="true" CodeBehind="yacht_layout.aspx.cs" Inherits="yacht.yacht_layout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--------------------------------內容開始---------------------------------------------------->
    <div class="box1">
        <asp:Literal ID="contentLiteral" runat="server"></asp:Literal>
    </div>
    <p class="topbuttom">
        <img src="images/top.gif" alt="top" />
    </p>
    <!--------------------------------內容結束------------------------------------------------------>
</asp:Content>
