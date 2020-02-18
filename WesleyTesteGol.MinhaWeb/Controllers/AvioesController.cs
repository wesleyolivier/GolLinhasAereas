using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WesleyTesteGol.MinhaWeb.Controllers
{
    public class AvioesController : Controller
    {
        // GET: Avioes
        public ActionResult Index()
        {
            string resultadoDoGet = MeuGetOuDelete("http://localhost:50083/api/Avioes", "GET");            

            List<Comum.Entidade.POCO.Airplane> avioesCadastrados =
                new JavaScriptSerializer()
                .Deserialize<List<Comum.Entidade.POCO.Airplane>>(resultadoDoGet);
            
            return View(avioesCadastrados);
        }

        [HttpGet]
        // GET: Avioes/Details/5
        public ActionResult Details(int id)
        {
            string resultadoDoGet = MeuGetOuDelete("http://localhost:50083/api/Avioes/RetornarPorCodigo?id=" + id, "GET");
                        
            Comum.Entidade.POCO.Airplane aviao =
                new JavaScriptSerializer().Deserialize<Comum.Entidade.POCO.Airplane>(resultadoDoGet);

            return View(aviao);
        }

        // GET: Avioes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avioes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var x =
                    new Comum.Entidade.POCO.Airplane
                    {
                        Codigo = 0,
                        Modelo = collection["Modelo"],
                        QuantidadePassageiros = Convert.ToInt32(collection["QuantidadePassageiros"]),
                        DataCriacaoRegistro = DateTime.Now
                    };

                MeuPostOuPut("http://localhost:50083/api/Avioes/Criar", "POST", x);
                
                

                //WebRequest webRequest = WebRequest.Create("http://localhost:50083/api/Avioes/Criar");
                //webRequest.Method = "POST";
                //webRequest.ContentType = "application/json";

                //string jsonParaEnvio = new JavaScriptSerializer().Serialize(x);

                //using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                //{
                //    streamWriter.Write(jsonParaEnvio);
                //    streamWriter.Flush();
                //    streamWriter.Close();

                //    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                //    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                //    {
                //        var resultado = streamReader.ReadToEnd();
                //    }
                //}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avioes/Edit/5
        public ActionResult Edit(int id)
        {
            string resultadoDoGet = MeuGetOuDelete("http://localhost:50083/api/Avioes/RetornarPorCodigo?id=" + id, "GET");
            
            Comum.Entidade.POCO.Airplane aviao =
                new JavaScriptSerializer()
                .Deserialize<Comum.Entidade.POCO.Airplane>(resultadoDoGet);

            return View(aviao);
        }

        // POST: Avioes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var aviao =
                    new Comum.Entidade.POCO.Airplane
                    {
                        Codigo = id,
                        Modelo = collection["Modelo"],
                        QuantidadePassageiros = Convert.ToInt32(collection["QuantidadePassageiros"]),
                        DataCriacaoRegistro = DateTime.Now
                    };

                MeuPostOuPut("http://localhost:50083/api/Avioes/Alterar", "PUT", aviao);

                //WebRequest webRequest = WebRequest.Create("http://localhost:50083/api/Avioes/Alterar");
                //webRequest.Method = "PUT";
                //webRequest.ContentType = "application/json";

                //string jsonParaEnvio = new JavaScriptSerializer().Serialize(aviao);

                //using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                //{
                //    streamWriter.Write(jsonParaEnvio);
                //    streamWriter.Flush();
                //    streamWriter.Close();

                //    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                //    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                //    {
                //        var resultado = streamReader.ReadToEnd();
                //    }
                //}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avioes/Delete/5
        public ActionResult Delete(int id)
        {
            string resultadoDoGet = MeuGetOuDelete("http://localhost:50083/api/Avioes/RetornarPorCodigo?id=" + id, "GET");
                        
            Comum.Entidade.POCO.Airplane aviao =
                new JavaScriptSerializer().Deserialize<Comum.Entidade.POCO.Airplane>(resultadoDoGet);

            return View(aviao);
        }

        // POST: Avioes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                string resultadoDeDelete = MeuGetOuDelete("http://localhost:50083/api/Avioes/Apagar?id=" + id, "DELETE");
                                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private string MeuGetOuDelete(string endpoint, string verbo) 
        {
            WebRequest webRequest = WebRequest.Create(endpoint);
            webRequest.Method = verbo;
            HttpWebResponse httpWebResponse = null;
            httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
            string resultado = string.Empty;

            using (Stream stream = httpWebResponse.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                resultado = streamReader.ReadToEnd();
            }

            return resultado;
        }

        private string MeuPostOuPut(string endpoint, string verbo, Comum.Entidade.POCO.Airplane aviao) 
        {
            string resultado;
            
            WebRequest webRequest = WebRequest.Create(endpoint);
            webRequest.Method = verbo;
            webRequest.ContentType = "application/json";

            string jsonParaEnvio = new JavaScriptSerializer().Serialize(aviao);

            using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonParaEnvio);
                streamWriter.Flush();
                streamWriter.Close();

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    resultado = streamReader.ReadToEnd();
                }
            }

            return resultado;
        }
    
        
    }
}
