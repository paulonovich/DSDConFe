<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarCargo.aspx.cs" Inherits="SistemaTramiteDocumentario.RegistrarCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:100%;text-align:center;">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Registro del cargo</strong></td>
                        </tr>
                        <tr>
                            <td style="width:10%"></td>
                            <td style="width:40%">Numero del comprobante:</td>
                            <td style="width:40%"><asp:TextBox ID="txtId" runat="server" Enabled="False" 
                                    EnableTheming="True">1</asp:TextBox></td>
                            <td style="width:10%"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Codigo de Expediente: </td>
                            <td>
                                <asp:TextBox ID="txtCodigoExp" runat="server" Enabled="False"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Fecha de emision : </td>
                            <td><asp:TextBox ID="txtFechaEmision" runat="server" Enabled="False"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Nombre del recepcionista: </td>
                            <td><asp:TextBox ID="txtRecepcionista" runat="server" Width="200px"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Nombre del solicitante: </td>
                            <td><asp:TextBox ID="txtSolicitante" runat="server" Width="200px"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Estado: </td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server" Width="150px" 
                                    AutoPostBack="True">
                                    <asp:ListItem>En proceso</asp:ListItem>
                                    <asp:ListItem>Cancelado</asp:ListItem>
                                    <asp:ListItem>Aprobado</asp:ListItem>
                                </asp:DropDownList></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td style="text-align:right;"><asp:Button ID="btnEnviar" Width="100px" runat="server" Text="Enviar" OnClick="btnEnviar_Click" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

</asp:Content>
