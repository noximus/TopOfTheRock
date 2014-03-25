using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ZipInputStream s = new ZipInputStream(File.OpenRead(Server.MapPath("library//themesZip//Green.zip")));
        //ZipEntry theEntry = null;
        //while ((theEntry = s.GetNextEntry()) != null)
        //{

        //    string directoryName = Path.GetDirectoryName(@"C:\UnZipTest\" + theEntry.Name);
        //    string fileName = Path.GetFileName(@"C:\UnZipTest\" + theEntry.Name);

        //    // create directory
        //    if (directoryName.Length > 0)
        //    {
        //        Directory.CreateDirectory(directoryName);
        //    }

        //    if (fileName != String.Empty)
        //    {
        //        using (FileStream streamWriter = File.Create(@"C:\UnZipTest\" + theEntry.Name))
        //        {

        //            int size = 2048;
        //            byte[] data = new byte[2048];
        //            while (true)
        //            {
        //                size = s.Read(data, 0, data.Length);
        //                if (size > 0)
        //                {
        //                    streamWriter.Write(data, 0, size);
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}
        //s.Close();
    }
}
