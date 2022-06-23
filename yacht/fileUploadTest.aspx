<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileUploadTest.aspx.cs" Inherits="yacht.fileUploadTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="upload" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"></asp:CheckBoxList>
            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
