<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="_41136063_Assignment2.Shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #000000; background-image: url('https://localhost:44369/Media/Back.jpg');">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style7 {
            height: 23px;
            width: 508px;
        }
        .auto-style10 {
            height: 23px;
            width: 543px;
        }
        .auto-style11 {
            height: 182px;
            width: 543px;
        }
        .auto-style12 {
            height: 182px;
            width: 508px;
        }
        .auto-style13 {
            height: 182px;
        }
        .auto-style14 {
            height: 184px;
            width: 543px;
        }
        .auto-style15 {
            height: 184px;
            width: 508px;
        }
        .auto-style16 {
            height: 184px;
        }
        .auto-style17 {
            height: 188px;
            width: 543px;
        }
        .auto-style18 {
            height: 188px;
            width: 508px;
        }
        .auto-style19 {
            height: 188px;
        }
        .auto-style20 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#666666" Text="EvoStore"></asp:Label>
        </div>
        <table class="auto-style20">
            <tr>
                <td class="auto-style17">&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Gray" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Enter your username" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Gray" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a valid email address" ForeColor="#CC0000" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style18"></td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10" style="color: #C0C0C0">&nbsp;&nbsp;
                    <asp:RadioButton ID="rbGain" runat="server" ForeColor="Gray" GroupName="Goal" Text="Weight gain" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbLose" runat="server" GroupName="Goal" Text="Weight loss" ForeColor="Gray" />
                    <br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbPerformance" runat="server" GroupName="Goal" Text="Performance" ForeColor="Gray" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbVegan" runat="server" GroupName="Goal" Text="Vegan" ForeColor="Gray" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View Products" />
                </td>
                <td class="auto-style7" style="color: #C0C0C0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
                    <br />
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style14">
                    <asp:ListBox ID="lstProducts" runat="server" Height="163px" Width="504px"></asp:ListBox>
                </td>
                <td class="auto-style15">
                    &nbsp;</td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style11">
                    &nbsp;&nbsp;<asp:Button ID="btnAddToCart" runat="server" OnClick="btnAddToCart_Click" style="height: 26px" Text="Add to cart" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGoToCart" runat="server" OnClick="btnGoToCart_Click" Text="Go to cart" />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
                </td>
                <td class="auto-style12">&nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Black" NavigateUrl="~/default.aspx">Back</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
