using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{

    public SqlCommand cmd = new SqlCommand();
    public SqlDataReader dr;
    public SqlDataAdapter ad = new SqlDataAdapter();
    public DataTable dt = new DataTable();

    public Class1()
    {
        //
        // TODO: Add constructor logic here

        //

    }
    public SqlConnection connect()
    {
        SqlConnection db = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;User Instance=True");
        db.Open();
        return db;
    }
    public void save(String Query)
    {
        cmd = new SqlCommand(Query, connect());
        cmd.ExecuteNonQuery();
    }
    public void update(String Query)
    {
        cmd = new SqlCommand(Query, connect());
        cmd.ExecuteNonQuery();
    }
    public SqlDataReader Search(String Query)
    {
        cmd = new SqlCommand(Query, connect());
        dr = cmd.ExecuteReader();
        return dr;
    }
    public DataTable show_grid(String Query)
    {
        cmd = new SqlCommand(Query, connect());
        ad.SelectCommand = cmd;
        ad.Fill(dt);
        return dt;
    }
    public void delete(String Query)
    {
        cmd = new SqlCommand(Query, connect());
        cmd.ExecuteNonQuery();
    }
}
