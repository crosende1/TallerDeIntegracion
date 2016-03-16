using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;



namespace Probando.Controllers
{
    public class ValuesController : ApiController
    {
       
            // POST api/values
       public string Post(string value, string hashDado)
     
             {

                StringBuilder Sb = new StringBuilder();

                using (SHA256 hash = SHA256Managed.Create()) {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
                }

                Boolean valido = false;
                string mensaje = "";
                string HashOriginal = hashDado.ToLower();
                string hashCreado = Sb.ToString();
                string hashFinal = hashCreado.ToLower();



                if (hashCreado == HashOriginal)
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        results = new List<Result>()
                {

                    
                     new Result { valido = true, mensaje= hashCreado }
                }
                    });
                }

                else
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        results = new List<Result>()
                {

                    
                     new Result { valido = false, mensaje= hashCreado }
                }
                    });
                }

                return valido + hashCreado; 
              

                     }

                // fuente de el hash: http://stackoverflow.com/questions/16999361/sha-256-hash-in-c-sharp


       public class Result
       {
           public Boolean valido { get; set; }
           public string hashCreado { get; set; }
           public string mensaje { get; set; }
       }

        // GET api/values
        public IEnumerable<string> Get()
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Created));
            //return HttpResponseMessage.HttpStatusCode.Created;
           
        }

        
        }
    
}



