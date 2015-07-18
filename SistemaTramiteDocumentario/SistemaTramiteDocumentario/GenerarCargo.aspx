<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GenerarCargo.aspx.cs" Inherits="SistemaTramiteDocumentario.GenerarCargo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="text-align: center; width: 100%" align="center">
        <tr>
            <td>
                <table style="width: 80%">
                    <tr>
                        <td colspan="4" style="height: 75px;"><strong>Registrar Expediente</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlTramite" Width="100%" runat="server">
                                <asp:ListItem>Permiso de construcción urbana</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align:right;">
                            <asp:Button ID="btnConsultarTUPA" runat="server" Width="100px" Text="Consultar TUPA" OnClick="btnConsultarTUPA_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 40%"></td>
                        <td style="width: 40%;"></td>
                        <td style="width: 10%"></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblTitulo" runat="server" Text="Datos Solicitante"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 25%"></td>
                        <td style="width: 25%">Id:</td>
                        <td style="width: 25%">
                            <asp:TextBox ID="txtId" Enabled="false" runat="server">1</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Nombre:</td>
                        <td>
                            <asp:TextBox ID="txtCodigoExp" runat="server" Enabled="False"></asp:TextBox></td>
                        <td>Apellido:</td>
                        <td>
                            <asp:TextBox ID="txtCodigoSUT" runat="server" Enabled="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>DNI:</td>
                        <td>
                            <asp:TextBox ID="txtDNI" runat="server" Enabled="False"></asp:TextBox></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Telefono:</td>
                        <td>
                            <asp:TextBox ID="txtRequisito" runat="server" Enabled="False"></asp:TextBox></td>
                        <td>Correo:</td>
                        <td>
                            <asp:TextBox ID="txtCorreo" runat="server" Enabled="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Direccion:</td>
                        <td>
                            <asp:TextBox ID="txtDireccion" runat="server" Enabled="False"></asp:TextBox></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: right;">
                            <asp:Button ID="btnGenerarCargo" runat="server" Text="Generar Cargo" OnClick="btnGenerarCargo_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
