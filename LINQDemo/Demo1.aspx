<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo1.aspx.cs" Inherits="LINQDemo.Demo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCity" runat="server" AssociatedControlID="ddlCity" Text="City"></asp:Label>
            <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="true" />
        </div><hr />
        <div>
            <asp:Label ID="lblAge" runat="server" Text="Age" AssociatedControlID="txtAge" />
            <asp:TextBox ID="txtAge" runat="server" placeHolder="Age" />
            <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" 
                ErrorMessage="This field is required." InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revAge" runat="server" ControlToValidate="txtAge" 
                ErrorMessage="Please enter a valid input." ValidationExpression="^(\.[^0-9=]?|[<>=][=0-9]\d{2})$" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:Button ID="btnAge" runat="server" OnClick="btnAge_Click" Text="Submit" />
        </div><hr />
        <div>
            <asp:Label ID="lblOrderBy" runat="server" AssociatedControlID="ddlOrderBy" Text="Order By"></asp:Label>
            <asp:DropDownList ID="ddlOrderBy" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrderBy_SelectedIndexChanged">
                <asp:ListItem Text="Nothing" Value="0" />
                <asp:ListItem Text="Name" Value="1" />
                <asp:ListItem Text="Age" Value="2" />
            </asp:DropDownList>
        </div><hr />
        <div>
            <asp:Label ID="lblAggregate" runat="server" AssociatedControlID="ddlAggregate" Text="Aggregate"></asp:Label>
            <asp:DropDownList ID="ddlAggregate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAggregate_SelectedIndexChanged">
                <asp:ListItem Text="Min" Value="1" />
                <asp:ListItem Text="Max" Value="2" />
                <asp:ListItem Text="Avg" Value="3" />
                <asp:ListItem Text="Sum" Value="4" />
            </asp:DropDownList>
        </div><hr />
        <div>
            <asp:GridView ID="gvPerson" runat="server" BackColor="SkyBlue" />
        </div>
    </form>
</body>
</html>
