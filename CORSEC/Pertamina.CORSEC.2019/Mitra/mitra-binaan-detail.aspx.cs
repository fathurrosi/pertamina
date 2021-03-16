using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;


namespace Pertamina.CORSEC._2019.Mitra
{
    public partial class mitra_binaan_detail : CORSECPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                string username = Utilities.Username;
                hdnIsLogin.Value = Utilities.IsUser ? "1" : "0";
                hdnLoginUrl.Value = ResolveUrl(string.Format("~/Login.aspx?ReturnUrl={0}", Server.UrlEncode(string.Format("Mitra/mitra-binaan-detail.aspx{0}&id={1}", PrevUrl, ItemID))));
                btnBack.HRef = ResolveUrl(string.Format("~/Mitra/Mitra-binaan.aspx{0}", PrevUrl));

                #region PRODUK LAINNYA
                string templateProdukLainnya = @"
<div class=""col-md-3"">
    <!--begin:: Widgets/Blog-->
    <div class=""kt-portlet kt-portlet--height-fluid kt-widget19"">
        <div class=""kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill"">
            <a href=""{0}"">
                <div class=""kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides""
                    style=""min-height: 280px; background-image: url('{1}')"">
                </div>
            </a>
        </div>
        <div class=""kt-portlet__body bd-thin"">
            <div class=""kt-widget19__wrapper"">
                <div class=""kt-widget19__content"">
                    <div class=""kt-widget19__info p-0"">
                        <a href=""{0}"" class=""kt-widget19__username"">{2}
                        </a>
                    </div>
                </div>
                <div class=""kt-widget18__text"">
                    {3}
                </div>
            </div>
        </div>
    </div>

    <!--end:: Widgets/Blog-->
</div>
";

                string templateContainerProdukLainnya = @"

                    <h2 class=""mt-3 mb-4"">Produk Lainnya</h2>
                    <div class=""row"">
					{0}
					</div>
";

                List<Dto.Cstm.tbl_product_related> products = tbl_product_relatedItem.GetMerchandiseHub_ByRelated(ItemID);
                if (products.Count > 0)
                {
                    string produkLainnya = "";
                    foreach (Dto.Cstm.tbl_product_related product in products)
                    {
                        string url = ResolveUrl(string.Format("~/Mitra/Mitra-binaan-Detail.aspx{0}&id={1}", PrevUrl, product.product_id));
                        string imageUrl = ConvertUrl(product.file_blob);
                        produkLainnya += string.Format(templateProdukLainnya, url, imageUrl, product.title, Crop(product.body, 66));
                    }
                    lblProdukLainnya.Text = string.Format(templateContainerProdukLainnya, produkLainnya);
                }
                #endregion

                #region KONTAK PERSON
                string tempalteContactPerson = @"
<a href=""#""><i class=""flaticon2-new-email""></i>{0}</a>
<a href=""#""><i class=""fa fa-phone-square""></i>{1}</a>
";

                //tbl_product_contact_person person = tbl_product_contact_personItem.GetAll().FirstOrDefault();
                tbl_product_contact_person person = tbl_product_contact_personItem.GetAll().OrderByDescending(t => t.id).FirstOrDefault();
                lblContactPerson.Text = string.Format(tempalteContactPerson, person == null ? "None" : person.email, person == null ? "None" : person.phone);
                #endregion


                #region DETAIL
                tbl_product contentItem = tbl_productItem.GetByPK(ItemID);
                if (contentItem != null)
                {
                    hdnId.Value = string.Format("{0}", contentItem.id);
                    lblSKU.Text = contentItem.SKU;
                    lblIsi.Text = contentItem.body;
                    lblHargaMulai.Text = string.Format("{0:N0}", contentItem.Estimasi_Harga_Mulai);
                    lblHargaHingga.Text = string.Format("{0:N0}", contentItem.Estimasi_Harga_Hingga);
                    lblQty.Text = string.Format("{0}", contentItem.Min_Quantity);
                    lblJudul.Text = contentItem.title;

                    //List<tbl_product_File> _files = tbl_product_FileItem.GetGalery(contentItem.id);
                    List<tbl_product_File> _files = tbl_product_FileItem.GetByFK(ItemID);
                    string imageTemplate = @"<li><img src=""{0}"" alt=""photo"" /></li>
";
                    foreach (tbl_product_File _file in _files)
                    {
                        lblImages.Text += string.Format(imageTemplate, Utilities.ByteToString(_file.file_blob));
                    }
                }

                #endregion
            }
        }
    }
}