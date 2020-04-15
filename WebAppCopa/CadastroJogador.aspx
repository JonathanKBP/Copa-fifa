<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="CadastroJogador.aspx.cs"
    Inherits="WebAppCopa.CadastroJogador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootbox.min.js"></script>
    <script src="Scripts/toastr.min.js"></script>
    <script type="text/javascript">
        function ConfirmarExclusao(sender) {
            parent.FecharPopUp();
        }
        function ConfirmarExclusao(sender) {
            if ($(sender).attr("ExclusaoConfirmada") == "true") {
                return true;
            }
            bootbox.confirm({
                message: "Deseja realmente excluir este jogador?",
                buttons: {
                    confirm: {
                        label: 'Sim',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'Não',
                        className: 'btn-danger'
                    }
                },
                callback: function (confirmed) {
                    if (confirmed) {
                        $(sender).attr("ExlusaoConfirmada", confirmed).trigger("click");
                    }
                }
            });
            return false;
        }
    </script>

    <style type="text/css">
        .btn-danger {}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div>ID</div>
                <br />
                <div>
                    <asp:TextBox ID="txtId" runat="server" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <br />

            <div>
                <div>Nome</div>
                <br />
                <div>
                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div>
                <div>Data Nascimento</div>
                <br />
                <div>
                    <asp:TextBox ID="txtDataNascimento" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div>
                <div>Numero Camisa</div>
                <br />
                <div>
                    <asp:TextBox ID="txtNumeroCamisa" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />

            <div>
                <div>Convocacao</div>
                <br />
                <div>
                    <asp:TextBox ID="txtConvocacao" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div>
                <div>Dispensa</div>
                <br />
                <div>
                    <asp:TextBox ID="txtDispensa" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div>
                <div>Posição</div>
                <br />
                <div>
                    <asp:DropDownList ID="ddlPosicao" runat="server" AppendDataBoundItems="True">
                        
                    </asp:DropDownList>
                </div>
            </div>
            <br />
        </div>
        <asp:Label ID="lblMensagem" runat="server" Text="Mensagem"></asp:Label>
        <br />
        <br />

        <asp:Button ID="btnExibirDados" runat="server" BackColor="#CCFFFF" BorderColor="White" OnClick="btnExibirDados_Click" Text="EXIBIR DADOS" Width="184px" CssClass="btn btn-primary" />
        <p>
            <asp:Button runat="server" Text="Calcular a Idade" ID="btnCalcularIdade" BackColor="#CCFFFF" BorderColor="White" OnClick="btnCalcularIdade_Click" Width="183px" CssClass="btn btn-success" />
        </p>

        <asp:Button ID="btnCalcularIndenizacaoFifa" runat="server" Text="Calcular Indenização" BackColor="#CCFFFF" BorderColor="White" Width="183px" OnClick="btnCalcularIndenizacaoFifa_Click" />
        <br />
        <br />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" BackColor="#CCFFFF" OnClick="btnSalvar_Click" Width="181px" CssClass="btn btn-info" />
        <br />
        <br />
        <asp:Button ID="bntExcluir" runat="server" Text="Excluir"
            CssClass="btn btn-danger" OnClintClick="return ConfirmarExclusao(this);" Width="179px" OnClick="bntExcluir_Click" BackColor="#FF3E3E" />


    </form>
</body>
</html>



