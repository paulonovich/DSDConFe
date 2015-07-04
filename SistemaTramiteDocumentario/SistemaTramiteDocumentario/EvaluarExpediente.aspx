<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EvaluarExpediente.aspx.cs" Inherits="SistemaTramiteDocumentario.EvaluarExpediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:100%">
                        <tr>
                            <td style="width:10%"></td>
                            <td style="width:80%"></td>
                            <td style="width:10%"></td>
                        </tr>
                        <tr>
                            <td style="height: 50px;" colspan="3"><strong>
                                <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></strong></td>
                        </tr>
                        <tr>
                            <td colspan="3"><asp:GridView ID="GridView1" Width="90%" runat="server">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                </asp:GridView></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>                                
                                <asp:Button ID="btnValidar" runat="server" Text="Evaluar" OnClick="btnValidar_Click" /></td>
                            <td>
                                <asp:Button ID="btnConsultarExpediente" runat="server" Text="Consultar Expediente" OnClick="btnConsultarExpediente_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnAprobar" runat="server" Text="Aprobar" /> <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> 
</asp:Content>
