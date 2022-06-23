<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="news_content.aspx.cs" Inherits="yacht.news_content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--------------------------------換圖開始---------------------------------------------------->
    <div class="banner">
        <ul>
            <li>
                <img src="images/newbanner.jpg" alt="Tayana Yachts" />
            </li>
        </ul>
    </div>
    <!--------------------------------換圖結束---------------------------------------------------->
    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">
            <div class="left1">
                <p>
                    <span>NEWS</span>
                </p>
                <ul>
                    <li><a href="news_list.aspx">News & Events</a></li>
                </ul>
            </div>
        </div>
        <!--------------------------------左邊選單結束---------------------------------------------------->
        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb">
            <a href="index.aspx">Home</a> >>
            <a href="#">News </a> >>
            <a href="#"><span class="on1">News & Events</span></a>
        </div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <span>News & Events</span>
                </div>
                <!--------------------------------內容開始------------------------------------------------------>
                <div class="box3">
                    <asp:Literal ID="newsTitleLiteral" runat="server"></asp:Literal>
                    <asp:Literal ID="newsContentLiteral" runat="server"></asp:Literal>
                </div>
                <!--下載開始-->
                <!--下載結束-->
                <div class="buttom001"><a href="javascript:window.history.back();">
                    <img src="images/back.gif" alt="&quot;&quot;" width="55" height="28" /></a></div>
                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>
        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>
</asp:Content>
