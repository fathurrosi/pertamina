using System;
using System.Linq;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.About.Details
{
    public partial class FeaturedArticle : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_Featured_Article item = tbl_Featured_ArticleItem.GetAll().FirstOrDefault();
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
                    txtYoutubeCode.Text = item.youtube_code;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Featured_Article item = tbl_Featured_ArticleItem.GetAll().FirstOrDefault();
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Featured_Article();
                item.created = DateTime.Now;
                item.created_by = username;

            }
            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.youtube_code = txtYoutubeCode.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;

            if (!isEdit)
            {
                tbl_Featured_ArticleItem.Insert(item);
            }
            else
            {
                tbl_Featured_ArticleItem.Update(item);
            }
        }
    }
}