<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="dealers.aspx.cs" Inherits="yacht.dealers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <!--------------------------------換圖開始---------------------------------------------------->
      <div class="banner">
        <ul>
          <li><img src="images/DEALERS.jpg" alt="Tayana Yachts" /></li>
        </ul>
      </div>
      <!--------------------------------換圖結束---------------------------------------------------->
      <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">
          <div class="left1">
            <p><span>DEALERS</span></p>
            <ul>
                <asp:Literal ID="areaList" runat="server"></asp:Literal>
            </ul>
          </div>
        </div>
        <!--------------------------------左邊選單結束---------------------------------------------------->
        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb">
            <a href="index.aspx">Home</a> >> 
            <a href="#">Dealers </a> >> 
            <a href="#"><span class="on1" id="areaLink" runat="server">USA</span></a>
        </div>
        <div class="right">
          <div class="right1">
            <div class="title">
              <span id="areaTitle" runat="server">USA</span></div>
            <!--------------------------------內容開始---------------------------------------------------->
            <div class="box2_list">
              <ul>
                  <asp:Literal ID="dealerList" runat="server"></asp:Literal>
              </ul>
              <div class="pagenumber"> </div>
            </div>
            <!--------------------------------內容結束------------------------------------------------------>
          </div>
        </div>
        <!--------------------------------右邊選單結束---------------------------------------------------->
      </div>
</asp:Content>
