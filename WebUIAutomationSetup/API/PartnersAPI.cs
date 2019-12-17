using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUIAutomationSetup.POM;

namespace WebUIAutomationSetup.API
{
    public class PartnersAPI
    {
        private static string _baseUrlAPI = "https://pickle.rick/api/reviews";

        public static HttpResponseMessage ServeReviewToPartner()
        {
            var reviewUrl = _baseUrlAPI + "/ServeReview/";
            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(reviewUrl), Method = HttpMethod.Get })
                {
                    var response = httpClient.SendAsync(request).Result;
                    CheckFor200Response(response);
                    return response;
                }
            }
        }


        public static HttpResponseMessage SubmitReviewToPlatform(ReviewModel reviews)
        {
            var reviewUrl = _baseUrlAPI + "/SubmitReview/";

            string strReviewData = JsonConvert.SerializeObject(reviews);
            HttpContent content = new StringContent(strReviewData, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(reviewUrl), Method = HttpMethod.Post, Content = content })
                {
                    var response = httpClient.SendAsync(request).Result;
                    CheckFor200Response(response);
                    return response;
                }
            }
        }


        public static void CheckFor200Response(HttpResponseMessage response)
        {
            if ((int)response.StatusCode != 200)
            {
                throw new HttpRequestException(string.Format("{0} : Request returned a non-200 response: {1}", (int)response.StatusCode, response.RequestMessage));
            }
        }

    }
}
