<%@ Page Title="" Language="C#" MasterPageFile="~/yachtType.Master" AutoEventWireup="true" CodeBehind="yacht_overview.aspx.cs" Inherits="yacht.yachts_list" %>

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
    <!--下載開始-->
    <div id="divDownload" class="downloads" runat="server">
        <p>
            <img src="images/downloads.gif" alt="&quot;&quot;" />
        </p>
        <ul>
            <li>
                <asp:Literal ID="downloadLiteral" runat="server"></asp:Literal>
            </li>
        </ul>
    </div>
    <!--下載結束-->
    <!--------------------------------內容結束------------------------------------------------------>
</asp:Content>
