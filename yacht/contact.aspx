<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="yacht.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--------------------------------換圖開始---------------------------------------------------->
    <div class="banner">
        <ul>
            <li>
                <img src="images/contact.jpg" alt="Tayana Yachts" /></li>
        </ul>
    </div>
    <!--------------------------------換圖結束---------------------------------------------------->
    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">
            <div class="left1">
                <p><span>CONTACT</span></p>
                <ul>
                    <li><a href="#">contacts</a></li>
                </ul>
            </div>
        </div>
        <!--------------------------------左邊選單結束---------------------------------------------------->
        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb">
            <a href="index.aspx">Home</a> >> 
            <a href="#"><span class="on1">Contact</span></a>
        </div>
        <div class="right">
            <div class="right1">
                <div class="title"><span>Contact</span></div>
                <!--------------------------------內容開始---------------------------------------------------->
                <!--表單-->
                <div class="from01">
                    <p>
                        Please Enter your contact information<span class="span01">*Required</span>
                    </p>
                    <br />
                    <table>
                        <tr>
                            <td class="from01td01">Name :</td>
                            <td><span>*</span><asp:TextBox ID="name" runat="server" Width="250px" class="{validate:{required:true, messages:{required:'Required'}}}" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required Content')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Email :</td>
                            <td><span>*</span><asp:TextBox ID="email" runat="server" Width="250px" class="{validate:{required:true, messages:{required:'Required'}}}" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required Content')"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="from01td01">Phone :</td>
                            <td><span>*</span><asp:TextBox ID="phone" runat="server" Width="250px" class="{validate:{required:true, messages:{required:'Required'}}}" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required Content')"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="from01td01">Country :</td>
                            <td><span>*</span>
                                <asp:DropDownList ID="coutryDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country" DataValueField="Country"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT [Country] FROM [country]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><span>*</span>Brochure of interest *Which Brochure would you like to view?</td>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="yachtDropDownList" runat="server" DataSourceID="SqlDataSource2" DataTextField="typeName" DataValueField="typeName"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yachtConnectionString %>" SelectCommand="SELECT [typeName] FROM [yachtType]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Comments:</td>
                            <td>
                                <asp:TextBox ID="comments" runat="server" Width="250px" class="{validate:{required:true, messages:{required:'Required'}}}" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required Content')" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td class="f_right">
                                <asp:ImageButton ID="ImageButton1" runat="server" src="images/buttom03.gif" style="border-width: 0px;" OnClick="ImageButton1_Click"/>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--表單-->
                <div class="box1">
                    <span class="span02">Contact with us</span><br />
                    Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
              As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our
              potential customers.
              If you have any questions about our yachts or would like to take your interest a stage further, please
              feel free to contact us.
                </div>
                <div class="list03">
                    <p>
                        <span>TAYANA HEAD OFFICE</span><br />
                        NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
                        tel. +886(7)641 2422<br />
                        fax. +886(7)642 3193<br />
                    </p>
                </div>
                <div class="box4">
                    <h4>Location</h4>
                    <p>
                        <iframe width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://maps.google.com/maps?f=d&amp;source=s_d&amp;saddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E5%B0%8F%E6%B8%AF%E5%8D%80%E4%B8%AD%E5%B1%B1%E5%9B%9B%E8%B7%AF%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F%E5%A0%B4&amp;daddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;hl=zh-en&amp;geocode=FRthWAEdwlwsByGxkQ4S1t-ckinNS9aM0xxuNDELEXJZh6Soqg%3BFRRmVwEdMKssBym5azbzl-JxNDGd62mwtzGaDw&amp;aq=0&amp;oq=%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F&amp;sll=22.50498,120.36792&amp;sspn=0.008356,0.016512&amp;g=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;mra=ls&amp;ie=UTF8&amp;t=m&amp;ll=22.537135,120.360718&amp;spn=0.08213,0.119133&amp;z=13&amp;output=embed"></iframe>
                    </p>
                </div>
                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>
        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>
</asp:Content>
