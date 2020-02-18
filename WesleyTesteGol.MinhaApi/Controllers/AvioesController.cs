using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WesleyTesteGol.MinhaApi.Controllers
{
    public class AvioesController : ApiController
    {        
        
        [HttpGet]
        public IHttpActionResult RetornarTodos() 
        {
            var avioesRetornados = new Negocio.ProcessoDeNegocio().GetAvioes();

            if (avioesRetornados.Count > 0)            
                return Ok(avioesRetornados);
            return BadRequest("Nenhuma aeronave encontrada");
        }

        [HttpPost]
        public IHttpActionResult Criar(Comum.Entidade.POCO.Airplane aviao) 
        {            
            try
            {
                new Negocio.ProcessoDeNegocio().Insert(aviao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao criar a aeronave");
            }            
        }

        [HttpGet]
        public IHttpActionResult RetornarPorCodigo(int id)
        {
            var aviaoRetornado = new Negocio.ProcessoDeNegocio().GetAviao(id);

            if (aviaoRetornado != null)
                return Ok(aviaoRetornado);
            return BadRequest("Aeronave encontrada");
        }

        [HttpPut]
        public IHttpActionResult Alterar(Comum.Entidade.POCO.Airplane aviao)
        {
            try
            {
                new Negocio.ProcessoDeNegocio().Update(aviao);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar os dados da aeronave");
            }            
        }
    
        [HttpDelete]
        public IHttpActionResult Apagar(int id) 
        {
            try
            {
                new Negocio.ProcessoDeNegocio().Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
