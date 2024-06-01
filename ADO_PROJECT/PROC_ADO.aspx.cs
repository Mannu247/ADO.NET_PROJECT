using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO_PROJECT
{
    public partial class PROC_ADO : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
                Bind_Country();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "SUBMIT")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("PROC_ADO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "INS");
                cmd.Parameters.AddWithValue("@NAME", txtName.Text);
                cmd.Parameters.AddWithValue("@AGE", txtAge.Text);
                cmd.Parameters.AddWithValue("@PHONE", txtPhone.Text);
                cmd.Parameters.AddWithValue("@COUNTRY", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@STATE", ddlState.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                empty();
            }
            else if (btnSubmit.Text == "UPDATE")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("PROC_ADO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "UPD");
                cmd.Parameters.AddWithValue("@NAME", txtName.Text);
                cmd.Parameters.AddWithValue("@AGE", txtAge.Text);
                cmd.Parameters.AddWithValue("@PHONE", txtPhone.Text);
                cmd.Parameters.AddWithValue("@COUNTRY", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@STATE", ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@AID", ViewState["vs"]);
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "SUBMIT";
                display();
                empty();
            }
        }
        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("PROC_ADO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ACTION", "DIS");
            cmd.Parameters.AddWithValue("@NAME", txtName.Text);
            cmd.Parameters.AddWithValue("@AGE", txtAge.Text);
            cmd.Parameters.AddWithValue("@PHONE", txtPhone.Text);
            cmd.Parameters.AddWithValue("@COUNTRY", ddlCountry.SelectedValue);
            cmd.Parameters.AddWithValue("@STATE", ddlState.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gv1.DataSource = dt;
            gv1.DataBind();
        }
        public void empty()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
            ddlCountry.SelectedValue = "0";
            ddlState.SelectedValue = "0";
            btnSubmit.Text = "SUBMIT";
        }
        public void Bind_Country()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBL_COUNTRY", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlCountry.DataValueField = "CID";
            ddlCountry.DataTextField = "CNAME";
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("SELECT COUNTRY", "0"));
        }
        public void Bind_State()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBL_STATE where CID='" + ddlCountry.SelectedValue + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlState.DataValueField = "SID";
            ddlState.DataTextField = "SNAME";
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("SELECT STATE", "0"));
        }

        protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DELETE1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("PROC_ADO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "DEL");
                cmd.Parameters.AddWithValue("@AID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                display();
            }
            else if (e.CommandName == "EDIT1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("PROC_ADO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "EDT");
                cmd.Parameters.AddWithValue("@AID", e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                txtName.Text = dt.Rows[0]["NAME"].ToString();
                txtAge.Text = dt.Rows[0]["AGE"].ToString();
                txtPhone.Text = dt.Rows[0]["PHONE"].ToString();
                ddlCountry.SelectedValue = dt.Rows[0]["COUNTRY"].ToString();
                ddlState.SelectedValue = dt.Rows[0]["STATE"].ToString();
                btnSubmit.Text = "UPDATE";
                ViewState["vs"] = e.CommandArgument;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_State();
        }
    }
}