using APIGeneric.APIGeneric;
using APIGeneric.Environment;
using APIGeneric.JsonProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace APIGeneric.APIExecution
{
    [TestClass]
    public class APIExecution : APIHelper
    {
        APIHelper apiHelper = new APIHelper();
        static Dictionary<string, string> responedata = new();

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
                responedata.Add("DataId", getPageResponse.datavalues[0].Id);
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
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
            //{
            //    data = new
            //    {
            //        id = 2,
            //        email = "janet.weaver@reqres.in",
            //        first_name = "janet",
            //        last_name = "weaver",
            //        avatar = "https=//reqres.in/img/faces/2-image.jpg"
            //    },
            //    support = new
            //    {
            //        url = "https=//reqres.in/#support-heading",
            //        text = "to keep reqres free, contributions towards server costs are appreciated!"
            //    }
            //};

            var jsonBody = JsonConvert.SerializeObject(postBody);

            var response = apiHelper.executeAPIEndPoint(APIGenericEnvironment.postPageUser, HttpVerbs.POST, jsonBody);
            if (response.IsSuccessStatusCode)
            {
                var postPageResponse = JsonConvert.DeserializeObject<PostPageResonse>(checkResponseContent(response));
                Assert.AreEqual("morpheus", postPageResponse.Name);
                Assert.AreEqual("leader", postPageResponse.Job);
                Assert.AreNotEqual("", postPageResponse.Id);
                responedata.Add("Id", postPageResponse.Id);
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }


        [TestMethod]
        public void getUserById()
        {
            var response = apiHelper.executeAPIEndPoint(APIGenericEnvironment.getUserById(responedata["DataId"]), HttpVerbs.GET);
            if (response.IsSuccessStatusCode)
            {
                var getPageResponse = JsonConvert.DeserializeObject<GetPageResponse>(checkResponseContent(response));
                Assert.AreEqual("1", getPageResponse.dataByIDs.Email);
            }
            else
            {
                throw new Exception(response.ErrorException.Message + "  " + (int)response.StatusCode);
            }
        }

    }
}