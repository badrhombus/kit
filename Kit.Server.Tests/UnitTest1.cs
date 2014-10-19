using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;


namespace Kit.Server.Tests
{
    [TestClass]
    public class UnitTest1
    {

        string url =  "http://localhost:61125";

        [TestMethod]
        public void TestMethod1()
        {
            string result = "waiting...";
            //var client = new RestClient("http://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/");
            //var request = new RestRequest(String.Format("{0}/allinfo", "198440"));
            //client.ExecuteAsync(request, response => Console.WriteLine(response.Content));

            var client = new RestClient(url);
            var request = new RestRequest("Me");
            var response = client.Execute(request).Content;
            Console.WriteLine(response);

            request = new RestRequest("api/Me");
            response = client.Execute(request).Content;
            Console.WriteLine(response);
            


            
        }
    }
}
