<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ListarEstadios.aspx.cs" Inherits="WebAppCopa.ListarEstadios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function ExibirCadastroEstadio() {
            var url = 'CadastroEstadio.aspx';
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }
        function FecharPopUp() {
            $("#frmModalUrl").attr("src", "about:blank");
            $("frm").modal('hide');
            location.href = location.href
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

        <div class="col-md-12">       
                <button type="button" name="bntNovoEst" id="bntNovoEst" value="Novo"
                    class="bnt bnt-segundo form-control" onclick="ExibirCadastroEstadio();">
                    <i class="glyphicon glyphicon-plus"></i>Novo Estadio
                </button>
        </div>
        <asp:GridView ID="gvEstadiosAdicionados" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Estadios" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                <asp:BoundField DataField="Capacidade" HeaderText="Capacidade" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="row">
        <div class="col-md-6">
            Pesquisar
            <asp:TextBox ID="txtPesquisa" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar"
                CssClass="btn btn-sucess" OnClick="btnPesquisar_Click"/>
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnLimparPesquisa" runat="server" Text="Limpar Pesquisa"/>
        </div>

    </div>
</asp:Content>
