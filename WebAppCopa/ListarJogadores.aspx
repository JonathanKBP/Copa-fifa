<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ListarJogadores.aspx.cs" Inherits="WebAppCopa.ListarJogadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">


        function ExibirCadastroJogador() {
            var url = 'CadastroJogador.aspx';
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();

            return false;
        }
        function FecharPopUp() {
            $("#frmModalUrl").attr("src", "about:blank");
            $("#frmModel").model('hide');
        }
        function ExibirMensagemSucesso(msg) {
            toastr.success(msg, "Informação:", { "extendedTImeout": "0", "progressBar": true });
        }
        function ExibirMensagemErro(msg) {
            toastr.error(msg, "Informação: ", { "extendedTimeOut": "0", "progressBar": true });
        }
        function ExibirEditarJogador(id) {
            var url = 'CadastroJogador.aspx?JogadorId=' + id;
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="frmModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div>
                        <iframe src="javascript:" id="frmModalUrl" frameborder="0" class="frame-param" style="border: 0; width: 800px; height: 600px"
                            scrolling="auto" marginheight="0" marginwidth="0"></iframe>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Fechar</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                Novo Jogador
            </div>
            <div class="col-md-9">
                <button type="button" name="bntNovo" id="bntNovo" value="Novo"
                    class="bnt bnt-primary form-control" onclick="ExibirCadastroJogador();">
                    <i class="glyphicon glyphicon-plus"></i>Novo
                </button>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvJogadores" DataKeyName="Id" AutoGenerateColumns="False" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="Nome do Jogador" DataField="NmNome" />
                        <asp:BoundField HeaderText="Data de Nascimento" DataField="DtNascimento" />
                        <asp:BoundField HeaderText="Nº da Camisa" DataField="NrCamisa" />
                        <asp:BoundField HeaderText="Posição" DataField="NmPosicao" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <button class="btn btn-success btn-sm" title="Editar Jogador" type="<%--button--%>"
                                    onclick='ExibirEditarJogador(<%#Eval("id") %>); return false;'>
                                    <i class="glyphicon glyphicon-pencil"></i>
                                </button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
