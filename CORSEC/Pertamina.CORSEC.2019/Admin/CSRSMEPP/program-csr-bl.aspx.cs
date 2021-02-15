using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Helper;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.CSRSMEPP
{
    public partial class program_csr_bl : AuthorizeAdminPage
    {
        //public string PrevUrl { get; set; }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/CSRSMEPP/Details/program.aspx{0}&t=csr", PrevUrl)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<tbl_CSR_SMEP_Program_Related_Document> relatedDocList = new List<tbl_CSR_SMEP_Program_Related_Document>();

                object objList = SessionHelper.Get("tbl_CSR_SMEP_Program_Related_Document");
                if (objList == null)
                {
                    relatedDocList = tbl_CSR_SMEP_Program_Related_DocumentItem.GetAll();
                    SessionHelper.Set("tbl_CSR_SMEP_Program_Related_Document", relatedDocList);
                }
                else
                {
                    relatedDocList = (List<tbl_CSR_SMEP_Program_Related_Document>)objList;
                }

                Label lblrelated_document = e.Row.FindControl("lblrelated_document") as Label;

                HiddenField hdnrelated_document = e.Row.FindControl("hdnrelated_document") as HiddenField;
                tbl_CSR_SMEP_Program_Related_Document cat = relatedDocList.Where(t => string.Format("{0}", t.id) == hdnrelated_document.Value).FirstOrDefault();
                if (cat != null)
                {
                    lblrelated_document.Text = cat.Name;
                }


                // Display the company name in italics.
                //e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                //HyperLink hyperLink = e.Row.FindControl("hl") as HyperLink;
                //hyperLink.NavigateUrl = string.Format("~/Admin/Details/Question.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

                HyperLink hyperLink = e.Row.FindControl("hlEdit") as HyperLink;
                hyperLink.NavigateUrl = string.Format("~/Admin/CSRSMEPP/Details/program.aspx{0}&id={1}&t=csr", PrevUrl, hiddenField.Value);

                //HyperLink hlAdd = e.Row.FindControl("hlAdd") as HyperLink;
                //hlAdd.NavigateUrl = string.Format("~/Admin/CorporateCommunication/Folder.aspx{0}&pid={1}&t=a", PrevUrl, hiddenField.Value);

                LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                lbtn.CommandArgument = hiddenField.Value;
            }
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);

            tbl_CSR_SMEP_ProgramItem.Delete(_id);


            grid.DataBind();
        }
    }
}