using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    // May not be needed, product could be added via admin panel
    public class AddProductRequest : WhmcsBaseRequest
    {
        // Required parameters
        [ApiParamName("type")] // one of hostingaccount, reselleraccount, server or other
        public string Type { get; set; }
        [ApiParamName("gid")] // the product group id to add it to
        public string GroupId { get; set; }
        [ApiParamName("name")] // the product name
        public string Name { get; set; }
        [ApiParamName("paytype")] // free, onetime or reccuring
        public string PayType { get; set; }

        // Optional parameters
        [ApiParamName("description")] // the product description
        public string Description { get; set; }
        [ApiParamName("hidden")] // set true to hide
        public string Hidden { get; set; }
        [ApiParamName("showdomainoptions")] // set true to show
        public string ShowDomainOptions { get; set; }
        [ApiParamName("welcomeemail")] //the email template id for a welcome email
        public string WelcomeEmail { get; set; }
        [ApiParamName("qty")] // set quantity to enable stock control
        public string Qty { get; set; }
        [ApiParamName("autosetup")] // on, payment, order or blank for none
        public string AutoSetup { get; set; }
        [ApiParamName("Module")] // module name
        public string Module { get; set; }
        [ApiParamName("servergroupid")] // server group id
        public string ServerGroupId { get; set; }
        [ApiParamName("subdomain")] // subdomain to offer with product
        public string Subdomain { get; set; }
        [ApiParamName("tax")] // set true to apply tax
        public string Tax { get; set; }
        [ApiParamName("order")] // set sort order to overide default
        public string Order { get; set; }
        [ApiParamName("pricing")] // an array of pricing in the format pricing[currencyid][cycle]
        public List<string> Pricing { get; set; }

        public AddProductRequest()
            : base()
        {
            ApiAction = WhmcsApi.AddProduct;
        }
    }
}
