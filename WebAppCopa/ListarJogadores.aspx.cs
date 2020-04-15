using Library.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCopa
{
    public partial class ListarJogadores : System.Web.UI.Page
    {
        JogadorBLL jService = new JogadorBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CarregarJogadores();
            }

        }
        public void CarregarJogadores()
        {
            gvJogadores.DataSource = jService.GetAll();
            gvJogadores.DataBind();
        }

    }

}