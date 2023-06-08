using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

	string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void btnLogin_Click(object sender, EventArgs e)
	{
		try
		{
            SqlConnection con = new SqlConnection(strcon);

            if (con.State == ConnectionState.Closed)
			{
				con.Open();
			}

			SqlCommand cmd = new SqlCommand("SELECT * from Korisnik WHERE " +
				"email='" + txtEmail.Text.Trim() + "'  AND " +
				"password='" + txtPass.Text.Trim() + "'", con);

			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Session["ime"] = dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString();
					Session["userId"] = dr.GetValue(0);
					Session["pass"] = dr.GetValue(4);
					if (Convert.ToInt32(dr.GetValue(5)) == 1)
					{
						Session["role"] = "privileged";

					}
					else
					{
						Session["role"] = "user";
					}
					Response.Redirect("home.aspx");
				}
			}

			else
			{
				Response.Write("<script>alert('Neuspjesna prijava!');</script>");
			}

		}
		catch (Exception ex)
		{
			Response.Write("<script>alert('" + ex.Message + "');</script>");
		}


	}
}