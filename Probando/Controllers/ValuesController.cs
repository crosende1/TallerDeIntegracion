﻿using System;
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
       public string Post(string value, string hashDado)
    //public string Post ()    
    {

                StringBuilder Sb = new StringBuilder();

                using (SHA256 hash = SHA256Managed.Create()) {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
                }

                Boolean iguales = false;
                string HashOriginal = hashDado.ToLower();
                string hashCreado = Sb.ToString();
                string hashFinal = hashCreado.ToLower();
                if (HashOriginal==hashFinal) {
                    iguales = true;
                    return "valido:" + iguales + "\r\n" + "mensaje: " + value;
                }
                else {
                    return "valido: " + iguales + "\r\n" + "mensaje: " + hashCreado ;
                }
                
                     }

                // fuente de el hash: http://stackoverflow.com/questions/16999361/sha-256-hash-in-c-sharp

             
       

        // GET api/values
        public IEnumerable<string> Get()
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Created));
           
        }

        
        }
    
}



