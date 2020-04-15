<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroEstadio.aspx.cs" Inherits="WebAppCopa.CadastroEstadio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootbox.min.js"></script>
    <script src="Scripts/toastr.min.js"></script>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/toastr.min.css" rel="stylesheet" />

    <script type="text/javascript">
        function ChamarFecharPopUp() {                        
            parent.FecharPopUp();
        }
    </script>

    <style type="text/css">
        .btn-success {
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="row">
                <div class="col-md-3">
                    Id
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    Nome
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    Cidade
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    Capacidade
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtCapacidade" runat="server"></asp:TextBox>
                </div>
            </div>


            <div class="row">
                <div class="col-md-3">
                    <asp:Button ID="btnAdicionar" CssClass="btn btn-info"
                        runat="server" Text="Adicionar" OnClick="Adicionar_Click" />
                </div>
                <div class="col-md-3">
                    <button type="button" name="btnConcluir" id="btnConcluir" value="Concluir"                         
                         class="btn btn-success" onclick="ChamarFecharPopUp();">
                        <i class="glyphicon glyphicon-save"></i>Concluir
                    </button>
                    <%--<asp:Button ID="btnConcluir" runat="server" Text="Concluir"
                       CssClass="btn btn-success" OnClientClick="return ChamarFecharPopUp();" />--%>
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                </div>


            </div>

            <br />
            <br />

        </div>
    </form>
</body>
</html>
