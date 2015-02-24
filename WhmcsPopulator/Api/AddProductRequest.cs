using System.Collections.Generic;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    // TODO Check if product will be added this way, or via admin panel
    // May not be needed, product could be added via admin panel
    public class AddProductRequest : WhmcsBaseRequest
    {
        // Required parameters
        [MandatoryParameter]
        [ApiParamName("type")] // one of hostingaccount, reselleraccount, server or other
        public string Type;
        [MandatoryParameter]
        [ApiParamName("gid")] // the product group id to add it to
        public string GroupId;
        [MandatoryParameter]
        [ApiParamName("name")] // the product name
        public string Name;
        [MandatoryParameter]
        [ApiParamName("paytype")] // free, onetime or reccuring
        public string PayType;

        // Optional parameters
        [ApiParamName("description")] // the product description
        public string Description;
        [ApiParamName("hidden")] // set true to hide
        public string Hidden;
        [ApiParamName("showdomainoptions")] // set true to show
        public string ShowDomainOptions;
        [ApiParamName("welcomeemail")] //the email template id for a welcome email
        public string WelcomeEmail;
        [ApiParamName("qty")] // set quantity to enable stock control
        public string Qty;
        [ApiParamName("autosetup")] // on, payment, order or blank for none
        public string AutoSetup;
        [ApiParamName("Module")] // module name
        public string Module;
        [ApiParamName("servergroupid")] // server group id
        public string ServerGroupId;
        [ApiParamName("subdomain")] // subdomain to offer with product
        public string Subdomain;
        [ApiParamName("tax")] // set true to apply tax
        public string Tax;
        [ApiParamName("order")] // set sort order to overide default
        public string Order;
        [ApiParamName("pricing")] // an array of pricing in the format pricing[currencyid][cycle]
        public List<string> Pricing;

        public AddProductRequest()
        {
            ApiAction = WhmcsApi.AddProduct;
        }
    }
}
