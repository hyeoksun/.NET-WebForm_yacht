<%@ Page Title="" Language="C#" MasterPageFile="~/yachtType.Master" AutoEventWireup="true" CodeBehind="yacht_video.aspx.cs" Inherits="yacht.yacht_video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--------------------------------內容開始---------------------------------------------------->
    <div class="box1">
        <p>Video</p>
        <iframe width="560" height="315" src="#" id="video" runat="server" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
    </div>
    <p class="topbuttom">
        <img src="images/top.gif" alt="top" />
    </p>
    <!--------------------------------內容結束------------------------------------------------------>
</asp:Content>
