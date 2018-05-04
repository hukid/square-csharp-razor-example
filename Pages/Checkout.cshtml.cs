using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Square.Connect.Api;
using Square.Connect.Model;

namespace sqRazorSample.Pages
{
    public class CheckoutModel : PageModel
    {
        public CatalogObject Item { get; set; }
        public string ApplicationId { get; set; }
        public string LocationId { get; set; }

        public String ItemName {
            get {
                return this.Item.ItemVariationData.ItemId;
            }
        }

        public bool IsSandbox { get; set; }

        public string PriceAmountString {
            get {
                return this.Item.ItemVariationData.PriceMoney.Amount.ToString();
            }
        }

        public long? PriceAmount
        {
            get
            {
                return this.Item.ItemVariationData.PriceMoney.Amount;
            }
        }

        public CheckoutModel(IConfiguration configuration)
        {
            this.ApplicationId = configuration["AppSettings:ApplicationId"];
            this.LocationId = configuration["AppSettings:LocationId"];

            this.IsSandbox = (configuration["AppSettings:Sandbox"] != null && configuration["AppSettings:Sandbox"].ToLower() == "true") ?
                true : false;
        }

        public void OnGet()
        {
            if (this.IsSandbox)
            {
                this.Item = new CatalogObject(CatalogObject.TypeEnum.ITEM, "Sandbox");
                this.Item.ItemVariationData = new CatalogItemVariation();
                this.Item.ItemVariationData.PriceMoney = new Money(100, Money.CurrencyEnum.USD);
                this.Item.ItemVariationData.ItemId = "SandboxItem";
            }
            else
            {
                string itemVarId = Request.Query["itemVarId"];
                CatalogApi catalogApi = new CatalogApi();
                RetrieveCatalogObjectResponse res = catalogApi.RetrieveCatalogObject(itemVarId, true);
                this.Item = res._Object;
            }
        }

        public string FormatMoney(long? amount)
        {
            return string.Format("${0:F2}", amount / 100.0);
        }
    }
}
