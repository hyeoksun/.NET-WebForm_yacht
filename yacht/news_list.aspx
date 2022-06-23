<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="news_list.aspx.cs" Inherits="yacht.news_list" %>

<%@ Register Src="~/pageControl.ascx" TagPrefix="uc1" TagName="pageControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/pagination.css" rel="stylesheet" />
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
                    <li><a href="#">News & Events</a></li>
                </ul>
            </div>
        </div>
        <!--------------------------------左邊選單結束---------------------------------------------------->
        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb">
            <a href="index.aspx">Home</a> >> <a href="#">News </a>>> <a href="#"><span class="on1">News & Events</span></a>
        </div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <span>News & Events</span>
                </div>
                <!--------------------------------內容開始------------------------------------------------------>
                <div class="box2_list">
                    <ul>
                        <li>
                            <div class="list01">
                                <ul>
                                    <asp:Literal ID="newsLiteral" runat="server"></asp:Literal>
                                </ul>
                            </div>
                            <div>
                                <uc1:pageControl runat="server" id="pageControl" />
                            </div>
                        </li>
                    </ul>
                </div>
                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>
        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>
</asp:Content>
