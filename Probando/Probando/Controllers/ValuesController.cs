using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;


namespace Probando.Controllers
{
    public class ValuesController : ApiController
    {

            // POST api/values
        public string Post([FromBody]string value, string hashDado)
        {

                StringBuilder Sb = new StringBuilder();

                using (SHA256 hash = SHA256Managed.Create()) {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
                }

                if (hashDado == Sb.ToString()) {
                    return "True";
                }
                else {
                return "False";
                }
                
                     }

                // fuente de el hash: http://stackoverflow.com/questions/16999361/sha-256-hash-in-c-sharp

             
       

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "kiwi", "banana", "apple" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "tomate";
        }

     

        // PUT api/values/5
        public string Put([FromBody]string value)
        {
            return "Put returning: " + value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    
}}