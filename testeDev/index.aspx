<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="testeDev.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Cadastro de Clientes</h1>
            <asp:HiddenField ID="idcliente" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Cliente" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtnome" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Endereço" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtendereco" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="UF" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtuf" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Cidade" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtcidade" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="CPF" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtcpf" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="E-mail" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtemail" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label Text="Telefone" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtfone" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button Text="Cadastrar" ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" />
                        <asp:Button Text="Limpar" ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" />
                        <asp:Button Text="Deletar" ID="btnDeletar" runat="server" OnClick="btnDeletar_Click" />
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Label Text="" ID="lblMensagemOk" ForeColor="Green" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label Text="" ID="lblMensagemErro" ForeColor="Red" runat="server" />
                    </td>
                </tr>

            </table>
            <br/ . />
            <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="nome" HeaderText="Cliente" />
                    <asp:BoundField DataField="endereco" HeaderText="Endereço" />
                    <asp:BoundField DataField="uf" HeaderText="UF" />
                    <asp:BoundField DataField="cidade" HeaderText="Cidade" />
                    <asp:BoundField DataField="cpf" HeaderText="CPF" />
                    <asp:BoundField DataField="email" HeaderText="E-mail" />
                    <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Selecionar" ID="lnkSelect" CommandArgument='<%# Eval("ClienteID") %>' runat="server" OnClick="lnkSelect_OnClick"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
