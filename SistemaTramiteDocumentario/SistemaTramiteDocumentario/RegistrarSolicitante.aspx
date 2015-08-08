<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarSolicitante.aspx.cs" Inherits="SistemaTramiteDocumentario.RegistrarSolicitante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:100%;text-align:center;">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Registro de Solicitante</strong></td>
                        </tr>
                        <tr>
                            <td style="width:25%">&nbsp;</td>
                            <td style="width:25%">Nombre:</td>
                            <td style="width:25%"><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                            <td style="width:25%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>Apellido:</td>
                            <td><asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>DNI:</td>
                            <td><asp:TextBox ID="txtDNI" runat="server" MaxLength="8"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>Telefono:</td>
                            <td><asp:TextBox ID="txtTelefono" runat="server" MaxLength="9"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>Correo:</td>
                            <td><asp:TextBox ID="txtCorreo" runat="server" Width="100%"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>Direccion:</td>
                            <td><asp:TextBox ID="txtDireccion" runat="server" Width="100%"></asp:TextBox></td>
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
                            <td colspan="4" style="text-align:right;"><asp:Button ID="btnContinuar" 
                                    Width="150px" runat="server" Text="Continuar" Visible="false" 
                                    onclick="btnContinuar_Click" /><asp:Button ID="btnGuardar" Width="150px" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
