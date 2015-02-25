using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class _Default : System.Web.UI.Page
{
    Class1 obj = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\CC\\Documents\\Visual Studio 2010\\WebSites\\WebSite1\\App_Data\\Database.mdf;Integrated Security=True;User Instance=True");
        DataTable dt = new DataTable();
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Id, Name from tblFiles";
                cmd.Connection = con;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }
        }
    }



    protected void Upload(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;
        using (Stream fs = FileUpload1.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);


                obj.save("insert into tblFiles  values('" + txtid.Text + "' , '" + filename + "','" + contentType + "','" + bytes + "')");

                
               
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }




    protected void View(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"600px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbed.Text = string.Format(embed, ResolveUrl("~/FileCS.ashx?Id="), id);
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
