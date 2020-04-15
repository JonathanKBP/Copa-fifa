using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.Model;

namespace WebAppCopa
{
    public partial class CadastroEstadio : System.Web.UI.Page
    {
        List<Estadio> listaEstadios = new List<Estadio>();

        protected void Adicionar_Click(object sender, EventArgs e)
        {
            if (Session["SessionListaEstadio"] != null)
            {
                listaEstadios = (List<Estadio>)Session["SessionListaEstadios"];
            }
            Estadio est = new Estadio();
            est.Id = Convert.ToInt32(txtId.Text);
            est.Nome = txtNome.Text;
            est.Cidade = txtCidade.Text;
            est.Capacidade = Convert.ToInt32(txtCapacidade.Text);

            listaEstadios.Add(est);

            Session["SessionListaEstadios"] = listaEstadios;


        }

    }
}