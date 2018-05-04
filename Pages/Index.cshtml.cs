using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Square.Connect.Api;
using Square.Connect.Model;

namespace sqRazorSample.Pages
{
    public class IndexModel : PageModel
    {
        public bool IsSandbox { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            this.IsSandbox = (configuration["AppSettings:Sandbox"] != null && configuration["AppSettings:Sandbox"].ToLower() == "true") ?
                true : false;
        }

        public List<CatalogObject> Items { get; set; }

        public void OnGet()
        {
            if (this.IsSandbox)
            {
                // We'll display a dummy item on ui
                return;
            }

            CatalogApi catalogApi = new CatalogApi();
            ListCatalogResponse res = catalogApi.ListCatalog(null, "ITEM");

            this.Items = new List<CatalogObject>();
            this.Items.AddRange(res.Objects);
        }

        public string FormatMoney(long? amount)
        {
            return string.Format("${0:F2}", amount / 100.0);
        }
    }
}
