using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    List<String> autori = new List<String>();
    List<String> datumi = new List<String>();
    List<String> tekst = new List<String>();
    List<String> postIds = new List<String>();
    

    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
	{
        try
		{
            if (!IsPostBack)
            {
                txtNew.Attributes.Add("maxlength", "280");
            }

            if (System.Web.HttpContext.Current.Session["role"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
			{
                if (Session["role"].ToString() == "privileged")
                {
                    LinkButton btnAdmin = new LinkButton();
                    btnAdmin.Text = "Admin opcije";
                    btnAdmin.CssClass = "dropdown-item";
                    btnAdmin.Click += new EventHandler(btnAdmin_Click);
                    admin.Controls.Add(btnAdmin);
                }
                username.Controls.Add(new LiteralControl(Session["ime"].ToString()));
            }
        }
        catch (Exception ex)
		{
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }

        SqlConnection con = new SqlConnection(strcon);

        try
		{

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select text, dateTime, ime + ' ' + prezime as autor, IdPost from Postovi inner join Korisnik on Postovi.korisnik = Korisnik.idKorisnik ORDER BY dateTime desc", con);
            SqlDataReader or = cmd.ExecuteReader();
            while (or.Read())
			{
                autori.Add(or["autor"].ToString());
                datumi.Add(or["dateTime"].ToString());
                tekst.Add(or["text"].ToString());
                postIds.Add(or["IdPost"].ToString());
			}

        }
		catch (Exception ex)
		{
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }

        addmainDiv(autori.Count);
    }

    protected void addmainDiv(int m)
    {
        for (int i = 0; i < m; i++)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl newdivs = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            newdivs.Attributes.Add("class", "container-md px-2 my-4 border border-3 rounded-3 ");
            newdivs.Style.Add("overflow", "hidden");
            //newdivs.ID = "createDiv";

            Label lblTime = new Label();
			Label lblAutor = new Label();
            Label lblText = new Label();
            Label lblPostId = new Label();

            lblAutor.Text = autori[i];
            lblAutor.CssClass = "h6";
            if (autori[i] == "OK7 Admin")
			{
                lblAutor.CssClass = "h6 text-danger text";
			}
            lblTime.Text = datumi[i];
            lblTime.CssClass = "h6 mx-2 text-secondary mb-0 ";
            lblText.Text = tekst[i];
            lblPostId.Text = "Objava ID: " + postIds[i];
            lblPostId.CssClass = "text-info d-flex justify-content-end ";
            lblPostId.Visible = false;

            if (Session["role"].ToString() == "privileged")
			{
                lblPostId.Visible = true;
			}

            newdivs.Controls.Add(lblAutor);
            newdivs.Controls.Add(new LiteralControl(" "));
            newdivs.Controls.Add(lblTime);
            newdivs.Controls.Add(new LiteralControl("<br>"));
            newdivs.Controls.Add(lblText);
            newdivs.Controls.Add(new LiteralControl("<br>"));
            newdivs.Controls.Add(lblPostId);

            maindivs.Controls.Add(newdivs);
        }
    }

	protected void btnNew_Click(object sender, EventArgs e)
	{

        SqlConnection con = new SqlConnection(strcon);

        try
        {

            DateTime datum = DateTime.Now;

            SqlCommand cmd = new SqlCommand("insert into Postovi(text, dateTime, korisnik) values('" + txtNew.Text + "', '" + datum.ToString("M-dd-yyy hh:mm:ss") +"', " + Session["userId"] + ");", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("Home.aspx");
            }
            catch (SqlException ex)
            {
                Response.Write("<script>alert('" + ex.ToString() +"');</script>");
            }
            finally
            {
                con.Close();
            }

        }
        catch
        {

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

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

}