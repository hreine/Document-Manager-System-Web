using System;
using System.Web;

public partial class index : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("swfs/index.html");
    }
}
