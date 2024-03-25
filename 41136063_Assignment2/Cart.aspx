<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="_41136063_Assignment2.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-image: url('Media/Back.jpg')">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 522px;
        }
        .auto-style2 {
            width: 522px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            width: 522px;
            height: 28px;
        }
        .auto-style5 {
            height: 28px;
        }
        .auto-style6 {
            width: 383px;
        }
        .auto-style7 {
            height: 26px;
            width: 383px;
        }
        .auto-style8 {
            height: 28px;
            width: 383px;
        }
        .auto-style9 {
            width: 522px;
            height: 100px;
        }
        .auto-style10 {
            height: 100px;
            width: 383px;
        }
        .auto-style11 {
            height: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblCart" runat="server" Font-Size="XX-Large" Text="Your Cart"></asp:Label>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:ListBox ID="lstCart" runat="server" Height="214px" Width="487px" OnSelectedIndexChanged="lstCart_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style6">
                    <asp:Calendar ID="Calendar1" runat="server" ForeColor="White"></asp:Calendar>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnAddItems" runat="server" OnClick="Button1_Click" Text="Add items" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRemoveItems" runat="server" OnClick="Button2_Click" Text="Remove from cart" />
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style8">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnCompleteOrder" runat="server" OnClick="Button3_Click" Text="Complete your order" style="height: 26px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style7">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Shop.aspx" ForeColor="White" OnLoad="HyperLink1_Load">Back</asp:HyperLink>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style10">
                </td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Button ID="btnDone" runat="server" OnClick="btnDone_Click" Text="Done" />
                </td>
                <td class="auto-style10">
                    &nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
