<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SistemaTramiteDocumentario.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:80%">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Registro de Expediente</strong></td>
                        </tr>
                        <tr>
                            <td style="width:10%"></td>
                            <td style="width:40%">Id Usuario:</td>
                            <td style="width:40%"><asp:TextBox ID="txtId" runat="server">1</asp:TextBox></td>
                            <td style="width:10%"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Nombre del usuario: </td>
                            <td>
                                <asp:TextBox ID="txtCodigoExp" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Apellidos: </td>
                            <td><asp:TextBox ID="txtCodigoSUT" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Telefono: </td>
                            <td><asp:TextBox ID="txtRequisito" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Perfil: </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>Activo</asp:ListItem>
                                    <asp:ListItem>Inactivo</asp:ListItem>
                                </asp:DropDownList></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
