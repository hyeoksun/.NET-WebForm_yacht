<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ckeditorTest.aspx.cs" Inherits="yacht.WebForm1" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.0/themes/base/jquery-ui.css"/>
     <link rel="stylesheet" href="/resources/demos/style.css"/>
      <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
      <script src="https://code.jquery.com/ui/1.13.0/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=datepicker.ClientID %>').datepicker();
            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/" Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"></CKEditor:CKEditorControl>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            &nbsp;&nbsp;
            <input id="Reset1" type="reset" value="reset" />
        </div>
        <asp:TextBox ID="datepicker" runat="server"></asp:TextBox>

        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
    </form>
</body>
</html>
