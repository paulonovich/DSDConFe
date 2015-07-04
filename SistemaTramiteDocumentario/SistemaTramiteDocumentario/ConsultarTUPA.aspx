<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConsultarTUPA.aspx.cs" Inherits="SistemaTramiteDocumentario.ConsultarTUPA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: justify;
        }
        .auto-style2 {
            color: #3366FF;
        }
        .auto-style3 {
            color: #000099;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:80%">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>Texto Único de Procedimientos Administrativos de SUNAT - TUPA</strong></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="auto-style1">
                                <span class="auto-style3"><strong>2013</strong></span>
                                <br />
                                <span class="auto-style2">Decreto Supremo N° 176-2013-EF</span> – Publicada el 18 de julio de 2013<br />
                                *Aprueban Texto Único de Procedimientos Administrativos de la Superintendencia Nacional de Aduanas y de Administración Tributaria.<br />
                                *Relación de Procedimientos Administrativos del TUPA 2013<br />
                                *Texto Consolidado del TUPA<br />
                                <br />
                                <span class="auto-style3"><strong>2014</strong></span>
                                <br />
                                <strong>Modificación del Texto Único de Procedimientos Administrativos</strong> 
<span class="auto-style2">Resolución de Superintendencia N° 316-2014/SUNAT</span> – Publicada el 22 de octubre de 2014<br />
*Aprueban modificación del Texto Único de Procedimientos Administrativos de la Superintendencia Nacional de Aduanas y de Administración Tributaria – SUNAT

                                <br />
                                <br />
                                <span class="auto-style3"><strong>2015</strong></span>
                                <br />
                                <strong>Modificación del Texto Único de Procedimientos Administrativos</strong><br />
<span class="auto-style2">Resolución de Superintendencia N° 064-2015/SUNAT</span> – Publicada el 04 de marzo de 2015
                                <br />
                                *Anexo de la R.S  N° 064-2015/SUNAT
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
