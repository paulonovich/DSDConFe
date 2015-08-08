<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EvaluarExpediente.aspx.cs" Inherits="SistemaTramiteDocumentario.EvaluarExpediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:100%;text-align:center;">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Evaluar Expediente</strong></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center;">
                                <asp:GridView ID="gvExpediente" runat="server" BackColor="White" 
                                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                    ForeColor="Black" GridLines="Vertical" Width="100%" 
                                    AutoGenerateColumns="False" DataKeyNames="codigoExpediente"
                                    onselectedindexchanged="gvExpediente_SelectedIndexChanged" 
                                    onrowcommand="gvExpediente_RowCommand">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="codigoExpediente" HeaderText="Codigo Expediente" />
                                        <asp:BoundField DataField="Tramite" HeaderText="Tramite" />
                                        <asp:BoundField DataField="Solicitante" HeaderText="Solicitante" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center;">
                                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="hdCodigo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:10%"></td>
                            <td style="width:40%"></td>
                            <td colspan="2" style="width:50%; text-align:right;">
                                <asp:Button ID="btnEvaluar" runat="server" Width="150px" 
                                    Text="Evaluar" onclick="btnEvaluar_Click"  /></td>
                        </tr>
                        <tr id="trPregunta" runat="server">
                            <td colspan="4" style="text-align:center;">
                                <asp:Label ID="lblTexto" runat="server" Text="El expediente seleccionado será:"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trOpcion" runat="server">
                            <td colspan="4" style="text-align:center;">
                                <asp:Button ID="btnAprobar" runat="server" Text="Aprobado" Width="150px" 
                                    onclick="btnAprobar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelado" Width="150px" 
                                    onclick="btnCancelar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
