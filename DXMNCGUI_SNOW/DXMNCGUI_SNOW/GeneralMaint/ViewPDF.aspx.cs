using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using DXMNCGUI_SNOW.Controllers;

namespace DXMNCGUI_SNOW.GeneralMaint
{
    public partial class ViewPDF : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.Request.QueryString["url"] != null)
                {


                    string resultfilepath = MapPath(this.Request.QueryString["url"].ToString());
                    string sContentType;
                    WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(resultfilepath);
                    if (FileBuffer != null)
                    {
                        switch (Path.GetExtension(resultfilepath).ToLower())
                        {
                            case ".dwf":
                                sContentType = "Application/x-dwf";
                                break;
                            case ".pdf":
                                sContentType = "Application/pdf";
                                break;
                            case ".docx":
                                sContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".pps":
                                sContentType = "Application/vnd.ms-powerpoint";
                                break;
                            case ".xls":
                                sContentType = "Application/vnd.ms-excel";
                                break;
                            case ".jpg":
                                sContentType = "image/jpg";
                                break;
                            case ".jpeg":
                                sContentType = "image/jpeg";
                                break;
                            case ".png":
                                sContentType = "image/png";
                                break;
                            default:
                                sContentType = "Application/octet-stream";
                                break;
                        }
                        Response.Clear();
                        Response.ContentType = sContentType;
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }


            }
            else
            {

            }
        }
    }
}