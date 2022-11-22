using APIGeneric.APIGeneric;
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
            var response = apiHelper.executeAPIEndPoint(APIGenericEnvironment.getPageUser, HttpVerbs.GET);
            if (response.IsSuccessStatusCode)
            {
                var getPageResponse = JsonConvert.DeserializeObject<GetPageResponse>(checkResponseContent(response));
                Assert.AreEqual("1", getPageResponse.Page);
                Assert.AreEqual("6", getPageResponse.PerPage);
                Assert.AreEqual("cerulean", getPageResponse.datavalues[0].Name);
            }

        }
        [TestMethod]
        public void postPageUser()
        {
            var postBody = new
            {
                name = "morpheus",
                job = "leader"
            };

            var jsonBody = JsonConvert.SerializeObject(postBody);

            var response = apiHelper.executeAPIEndPoint(APIGenericEnvironment.postPageUser, HttpVerbs.POST, jsonBody);
            if (response.IsSuccessStatusCode)
            {
                var postPageResponse = JsonConvert.DeserializeObject<PostPageResonse>(checkResponseContent(response));
                Assert.AreEqual("morpheus", postPageResponse.Name);
                Assert.AreEqual("leader", postPageResponse.Job);
                Assert.AreNotEqual("", postPageResponse.Id);
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}