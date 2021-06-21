using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ZakatApp.Models;

namespace ZakatApp.Controllers
{
    public class UserController : Controller
    {
        [System.Web.Http.HttpPost]
        public void Store(HttpPostedFileBase file)
        {
            if(Path.GetExtension(file.FileName) != ".txt")
            {
                var resp = new HttpResponseMessage(System.Net.HttpStatusCode.NotAcceptable)
                {
                    Content = new StringContent("Please insert valid file."),
                    ReasonPhrase = "Only Text File allowed"
                };
                throw new HttpResponseException(resp);
            }
            List<Dictionary<string, string>> users = new List<Dictionary<string, string>>();
            StreamReader reader = new StreamReader(file.InputStream);
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Dictionary<string, string > user = new Dictionary<string, string>();
                user.Add("ic_number", line.Substring(0, 12));
                user.Add("name", line.Substring(12, 49));
                user.Add("zakat_type", line.Substring(62, 2));
                user.Add("deduct_amt", line.Substring(64, 12));
                user.Add("district_code", line.Substring(76, 2));
                users.Add(user);
            }

            User userzakat = new User();
            userzakat.Insert(users);

        }
    }
}