﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MODSAL_RestaMalEstado.aspx.cs" Inherits="Inventario.MODSAL_RestaMalEstado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Operacion Resta en Mal Estado</h1>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Producto"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label>
        <br />
        <asp:TextBox ID="txtProducto" runat="server" Width="130px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCantidad" runat="server" Width="61px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Restar" OnClick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>
