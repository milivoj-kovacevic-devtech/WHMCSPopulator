namespace WhmcsPopulator.Api
{
    public class GetProductsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("pid")]
        public string ProductId;
        [ApiParamName("gid")]
        public string GroupId;

        [ApiParamName("module")]    // can be passed to just retrieve products assigned to a specific module
        public string Module;       // could be usefull since only cPanel product will be used

        public GetProductsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetProducts;
        }
    }
}
