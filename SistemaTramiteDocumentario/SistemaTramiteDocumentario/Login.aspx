<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaTramiteDocumentario.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>    
</head>
<body>
    <form runat="server" id="form">
        <table style="text-align:center;width:100%" align="center">
            <tr>
                <td>
                    <table style="width:80%">
                        <tr>
                            <td colspan="4" style="height: 75px;"><strong>SISTEMA DE TRAMITE DOCUMENTAL</strong></td>
                        </tr>
                        <tr>
                            <td style="width:25%"></td>
                            <td style="width:25%"><asp:Label ID="Label1" runat="server" Text="Usuario: "></asp:Label></td>
                            <td style="width:25%"><asp:TextBox ID="txtusuario" runat="server"></asp:TextBox></td>
                            <td style="width:25%"></td>
                        </tr>
                        <tr>
                            <td style="width:25%"></td>
                            <td style="width:25%"><asp:Label ID="Label2" runat="server" Text="Contraseña: "></asp:Label></td>
                            <td style="width:25%"><asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox></td>
                            <td style="width:25%"></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td colspan="4"><asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
	</form>
</body>
</html>
