<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarExpediente.aspx.cs" Inherits="SistemaTramiteDocumentario.RegistrarExpediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:100%;text-align:center;">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Registrar Expediente</strong></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:DropDownList ID="ddlTramite" Width="100%" runat="server" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align:right;">
                                <asp:Button ID="btnConsultarTUPA" runat="server" Width="150px" Text="Consultar TUPA" OnClick="btnConsultarTUPA_Click" />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center;">
                                <asp:Label ID="lblErrorCarga" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center;">
                                <asp:GridView ID="gvSolicitante" runat="server" BackColor="White" 
                                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                    ForeColor="Black" GridLines="Vertical" Width="100%" 
                                    AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="codigo" HeaderText="Id" />
                                        <asp:BoundField DataField="nombre" HeaderText="Nombres" />
                                        <asp:BoundField DataField="apellido" HeaderText="Apellidos" />
                                        <asp:BoundField DataField="dni" HeaderText="DNI" />
                                        <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                                        <asp:BoundField DataField="correo" HeaderText="Correo" />
                                        <asp:BoundField DataField="direccion" HeaderText="Dirección" />
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
                            </td>
                        </tr>
                        <tr>
                            <td style="width:10%"></td>
                            <td style="width:40%"></td>
                            <td style="width:40%; text-align:right;">
                                <asp:Button ID="btnGenerarCargo" runat="server" Width="150px" 
                                    Text="Generar Cargo" OnClick="btnGenerarCargo_Click" />
                            </td>
                            <td style="width:10%"></td>
                        </tr>
                        <tr>
                            <td style="width:10%"></td>
                            <td style="width:40%"></td>
                            <td style="width:40%"></td>
                            <td style="width:10%"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

</asp:Content>
