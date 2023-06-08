using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
	{
        try
        {

            if (System.Web.HttpContext.Current.Session["role"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                username.Controls.Add(new LiteralControl(Session["ime"].ToString()));
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
        if (Session["role"].ToString() == "privileged")
        {
            LinkButton btnAdmin = new LinkButton();
            btnAdmin.Text = "Admin opcije";
            btnAdmin.CssClass = "dropdown-item";
            btnAdmin.Click += new EventHandler(btnAdmin_Click);
            admin.Controls.Add(btnAdmin);
        }
    }

	protected void btnSettings_Click(object sender, EventArgs e)
	{
        Response.Redirect("Settings.aspx");
    }

	protected void btnLogout_Click(object sender, EventArgs e)
	{
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

    protected void btnPotvrda_Click(object sender, EventArgs e)
	{
        SqlConnection con = new SqlConnection(strcon);

        try
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (txtStara.Text != Session["pass"].ToString())
			{
                lblStara.Text = "Pogresan password!";
			}
            else
			{
                lblStara.Text = "";
			}

            if (txtPonovo.Text != txtNova.Text)
			{
                lblPonovo.Text = "'Ponovi novi password' mora biti isti kao 'Novi password' !";
			}
			else 
            {
                lblPonovo.Text = "";
            }

            if (txtPonovo.Text == txtNova.Text && txtStara.Text == Session["pass"].ToString())
			{
                SqlCommand cmd = new SqlCommand("UPDATE Korisnik SET password = '" + txtNova.Text + "' WHERE password = '" + txtStara.Text + "' AND idKorisnik ='" + Session["userId"] + "'", con);
                cmd.ExecuteNonQuery();
                lblStara.Text = "";
                lblPonovo.Text = "";
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "');</script>");
        }
    }
}