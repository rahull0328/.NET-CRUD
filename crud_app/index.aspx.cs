using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace crud_app
{
    public partial class index : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            gr_userData.DataBind();    
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (!checkUserExists())
            {
                registerUser();
            }
            else
            {
                Response.Write("<script>alert('User ID Exists Try with Another ID !');</script>");
            }
        }

        bool checkUserExists()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strCon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM data WHERE id='" + txt_id.Text.Trim() + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
                return false;
            }
        }

        void registerUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon); 
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string gen;
                if (rad_male.Checked == true)
                {
                    gen = rad_male.Text;
                }
                else
                {
                    gen = rad_female.Text;
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO data(id, name, email, gender, mobile) VALUES("+txt_id.Text.Trim()+", '" + txt_name.Text.Trim() + "', '" + txt_email.Text.Trim() + "', '" + gen + "', '" + txt_phone.Text.Trim() + "')", con);
                int res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    Response.Write("<script>alert('Data Added Successfully !');</script>");
                    clearForm();
                    gr_userData.DataBind();
                }
                con.Close();
            } catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }    
        }
         void clearForm()
         {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_email.Text = "";
            txt_phone.Text = "";
         }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
                updateUser();
            }
            else
            {
                Response.Write("<script>alert('User Doesn't Exists !');</script>");
            }
        }

        void updateUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string gen;
                if (rad_male.Checked == true)
                {
                    gen = rad_male.Text;
                }
                else
                {
                    gen = rad_female.Text;
                }
                SqlCommand cmd = new SqlCommand("UPDATE data SET name='"+txt_name.Text.Trim()+"', email='"+txt_email.Text.Trim()+"', gender='"+gen+"', mobile='"+txt_phone.Text.Trim()+"' WHERE id='"+txt_id.Text.Trim()+"' ", con);
                int res = cmd.ExecuteNonQuery();
                if (res == 1) {
                    Response.Write("<script>alert('Data Updated Successfully !');</script>");
                    clearForm();
                    gr_userData.DataBind();
                }
                con.Close();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
                deleteUser();
            }
            else
            {
                Response.Write("<script>alert('User Doesn't Exists !');</script>");
            }
        }

        void deleteUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string gen;
                if (rad_male.Checked == true)
                {
                    gen = rad_male.Text;
                }
                else
                {
                    gen = rad_female.Text;
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM data WHERE id='" + txt_id.Text.Trim() + "' ", con);
                int res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    Response.Write("<script>alert('Data Deleted Successfully !');</script>");
                    clearForm();
                    gr_userData.DataBind();
                }
                con.Close();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
                searchUserById();
            }
            else
            {
                Response.Write("<script>alert('User Doesn't Exists !');</script>");
            }
        }

        void searchUserById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM data WHERE id='" + txt_id.Text.Trim() + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    txt_name.Text = dr["name"].ToString();
                    txt_email.Text = dr["email"].ToString();
                    if (dr["gender"].ToString() == rad_male.Text)
                    {
                        rad_male.Checked = true;
                    }
                    else
                    {
                        rad_female.Checked = true;
                    }
                    txt_phone.Text = dr["mobile"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('No data found for the given ID.');</script>");
                }
                con.Close();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }
        }
    }
}