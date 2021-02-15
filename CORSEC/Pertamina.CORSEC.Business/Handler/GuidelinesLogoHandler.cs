using System;
using System.Linq;
using System.Web;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Business.Handler
{
    public class GuidelinesLogoHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            int _id = 0;
            int.TryParse(string.Format("{0}", request["id"]), out _id);

            try
            {

                tbl_brand_guideline_logo file = tbl_brand_guideline_logoItem.GetByPK(_id);

                if (file != null)
                {
                    string fileName = file.file_name;
                    string[] exts = fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    string ext = string.Empty;
                    if (exts.Length > 0)
                        ext = exts.Last();

                    int Length = file.file_blob.Length;
                    if (!string.IsNullOrEmpty(ext) && ext.ToLower().Equals("pdf"))
                    {
                        response.AddHeader("Accept-Ranges", "bytes");
                        response.AddHeader("Accept-Header", Length.ToString());
                        response.AddHeader("Cache-Control", "public");
                        response.AddHeader("Cache-Control", "must-revalidate");
                        response.AddHeader("Pragma", "public");
                        response.AddHeader("expires", "0");
                        response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.file_name));
                        response.ContentType = "application/octet-stream";
                        response.BufferOutput = true;
                        response.BinaryWrite(file.file_blob);
                        response.Flush();
                    }
                    else
                    {
                        response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.file_name));
                        response.ContentType = ext;
                        response.BufferOutput = true;
                        response.BinaryWrite(file.file_blob);
                        response.Flush();
                    }

                    //UpdateTable(file);
                }
                else
                {
                    //response.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                //response.StatusCode = 404;
                Log.Error(ex);
            }

            response.End();
        }
    }
}