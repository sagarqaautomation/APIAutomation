using APIGeneric.Environment;
using APIGeneric.JsonProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIGeneric.APIExecution
{
    [TestClass]
    public class APIExecution : APIHelper
    {
        APIHelper apiHelper = new APIHelper();

        [TestMethod]
        public void getPageUser()
        {
            var response = apiHelper.executeAPIEndPoint(APIGenericEnvironment.pageUserEndpoint, HttpVerbs.GET);
            if (response.IsSuccessStatusCode)
            {
                var getPageResponse = JsonConvert.DeserializeObject<GetPageResponse>(checkResponseContent(response));
                Assert.AreEqual("1", getPageResponse.Page);
                Assert.AreEqual("6", getPageResponse.PerPage);
                Assert.AreEqual("cerulean", getPageResponse.datavalues[0].Name);
            }
        }
    }
}