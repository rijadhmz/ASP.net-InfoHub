using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
	{
        try
        {

            if (Session["role"] != "privileged")
            {
                Response.Redirect("home.aspx");
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
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void btnSettings_Click(object sender, EventArgs e)
    {
        Response.Redirect("Settings.aspx");
    }

	protected void btnPotvrda_Click(object sender, EventArgs e)
	{
        lblFail.Text = "";

        SqlConnection con = new SqlConnection(strcon);

        int adm = Convert.ToInt32(chkAdmin.Checked);

        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (txtIme.Text == "" || txtPrezime.Text == "" || txtEmail.Text == "" || txtPass.Text == "" || txtRepeat.Text == "")
            {
                lblFail.Text = "Unesite podatke u sva polja!";
            }
            else if (txtPass.Text != txtRepeat.Text)
            {
                lblFail.Text = "'Ponovi password' mora biti isti kao 'password' !";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into Korisnik(ime, prezime, email, password, priority) " +
                    "values ('" + txtIme.Text + "', '" + txtPrezime.Text + "', '" + txtEmail.Text + "', '" + txtPass.Text + "', " + adm + ")", con);
                cmd.ExecuteNonQuery();
                Response.Redirect("Admin.aspx");
            }
        }
        catch (Exception ex)
		{
            Response.Write("<script>alert('" + ex.ToString() + "');</script>");
        }
    }

	protected void btnDelete_Click(object sender, EventArgs e)
	{
        SqlConnection con = new SqlConnection(strcon);

        if (txtDelete.Text == "")
		{
            lblDelete.Text = "Enter Post ID";
		}
		else
		{
			try
			{
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Postovi WHERE IdPost=" + Convert.ToInt32(txtDelete.Text) + "", con);
                cmd.ExecuteNonQuery();
                Response.Redirect("Admin.aspx");
            }
            catch (Exception ex)
			{
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
		}
    }
}