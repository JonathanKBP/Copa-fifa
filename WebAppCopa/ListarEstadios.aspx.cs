using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCopa
{
    public partial class ListarEstadios : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Estadio> listaEstadiosAdicionados = new List<Estadio>();

            if (!Page.IsPostBack)
            {

                if (Session["SessionListaEstadios"] != null)
                {
                    listaEstadiosAdicionados = (List<Estadio>)Session["SessionListaEstadios"];
                    gvEstadiosAdicionados.DataSource = listaEstadiosAdicionados;
                    gvEstadiosAdicionados.DataBind();
                }
            }



        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            List<Estadio> listaEstadiosAdicionados = new List<Estadio>();
            listaEstadiosAdicionados = (List<Estadio>)Session["SessionListaEstadios"];

            List<Estadio> listFiltrado = (from r in listaEstadiosAdicionados
                                          where r.Cidade.Contains(txtPesquisa.Text)
                                          select r).ToList();

            gvEstadiosAdicionados.DataSource = listFiltrado;
            gvEstadiosAdicionados.DataBind();
        }

  
    }
}