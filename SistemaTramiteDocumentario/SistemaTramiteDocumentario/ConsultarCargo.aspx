<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConsultarCargo.aspx.cs" Inherits="SistemaTramiteDocumentario.ConsultarCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:80%">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Registro del cargo</strong></td>
                        </tr>
                        <tr>
                            <td style="width:10%"></td>
                            <td style="width:40%">Numero del comprobante:</td>
                            <td style="width:40%"><asp:TextBox ID="txtId" runat="server">1</asp:TextBox></td>
                            <td style="width:10%"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Codigo de Expediente: </td>
                            <td>
                                <asp:TextBox ID="txtCodigoExp" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Fecha de emision : </td>
                            <td><asp:TextBox ID="txtFechaEmision" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Nombre del recepcionista: </td>
                            <td><asp:TextBox ID="txtRecepcionista" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Nombre del solicitante: </td>
                            <td><asp:TextBox ID="txtSolicitante" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Estado: </td>
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
                            <td><asp:Button ID="btnEnviar" runat="server" Text="Enviar" /></td>
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
