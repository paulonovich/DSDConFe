<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SistemaTramiteDocumentario.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:100%;text-align:center;">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Registro de Usuario</strong></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>DNI:</td>
                            <td><asp:TextBox ID="txtDNI" runat="server" MaxLength="8"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width:25%">&nbsp;</td>
                            <td style="width:25%">Nombre:</td>
                            <td style="width:25%"><asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox></td>
                            <td style="width:25%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>Tipo:</td>
                            <td>
                                <asp:DropDownList ID="ddlTipo" runat="server" Width="150px">
                                    <asp:ListItem Value="0">Seleccione un tipo de usuario</asp:ListItem>
                                    <asp:ListItem Value="1">Administrador</asp:ListItem>
                                    <asp:ListItem Value="2">Recepcionista</asp:ListItem>
                                    <asp:ListItem Value="3">Evaluador</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center;">
                                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:right;"><asp:Button ID="btnGuardar" Width="150px" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
