<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PROC_ADO.aspx.cs" Inherits="ADO_PROJECT.PROC_ADO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function confirmDelete() {
            return confirm("Are you sure you want to delete this item?");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="background-color: lightseagreen; color: white">
                <tr>
                    <td>NAME : </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ValidationGroup="vg" ID="rfvName" runat="server" ErrorMessage="Please Enter Your Name" ControlToValidate="txtName"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>AGE : </td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAge" ValidationGroup="vg" runat="server" ErrorMessage="Please Enter Your Age" ControlToValidate="txtAge"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>PHONE No: </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ValidationGroup="vg" ErrorMessage="Please Enter Your Phone No" ControlToValidate="txtPhone"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>COUNTRY :  </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ValidationGroup="vg" ErrorMessage="Please Enter Your Country" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>STATE : </td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ValidationGroup="vg" ErrorMessage="Please Enter Your State" ControlToValidate="ddlState"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" ValidationGroup="vg" Text="SUBMIT" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
            <br />
            <table>
                <tr style="background-color: pink">
                    <td>
                        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" OnRowCommand="gv1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <%#Eval("AID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NAME">
                                    <ItemTemplate>
                                        <%#Eval("NAME") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGE">
                                    <ItemTemplate>
                                        <%#Eval("AGE") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PHONE NO">
                                    <ItemTemplate>
                                        <%#Eval("PHONE") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COUNTRY">
                                    <ItemTemplate>
                                        <%#Eval("CNAME") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STATE">
                                    <ItemTemplate>
                                        <%#Eval("SNAME") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDlt" runat="server" CommandName="DELETE1" Text="DELETE" CommandArgument='<%#Eval("AID") %>' OnClientClick="return confirmDelete();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdt" runat="server" Text="EDIT" CommandName="EDIT1" CommandArgument='<%#Eval("AID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
