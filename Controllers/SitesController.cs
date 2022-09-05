
using Microsoft.AspNetCore.Mvc;
using AACLIENTE.AAAPI.Models.Site;
using AACLIENTE.AAAPI.Models.Category;



namespace AACLIENTE.AAAPI.Controllers.SitesController;





[ApiController]
[Route("[Controller]")]

public class SitesController : ControllerBase
{

   private static List<Site> Sites = new List<Site>{           

         new Site{id = 1, name = "site1", userName = "Andrea", password = "123", IdCategory=3},
          new Site{id = 2, name = "site1", userName = "Andrea", password = "123", IdCategory=3},
};
   

[HttpGet]
    public ActionResult<List<Category>> Get(){
        return Ok(Sites);
    }
/// <summary>
    /// Mostrar todos los sites
    /// </summary>
    /// <returns>Todos los sites</returns>
    /// <response code="200">Devuelve el listado de sites</response>
    /// <response code="500">Si hay algún error</response>
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Site> Get (int id){
        var site = Sites.Find (x =>x.id == id);
        return site == null ? NotFound() : Ok(site);
    }
    


/// <summary>
    /// añadir sites
    /// </summary>
    /// <returns>Todos los sites</returns>
    /// <response code="201">Se ha creado correctamente</response>
    /// <response code="500">Si hay algún error</response>
    [HttpPost]
     public ActionResult<Site> Post([FromBody] Site site){
        var existingCategory = Sites.Find(x=>x.id== site.id);
        if (existingCategory != null){
          
          String url = Request.Path.ToString() + "/" + site.id;
            return Conflict("ya existe esa categoria");
        } else {
            Sites.Add(site);
            var resourceUrl = Request.Path.ToString()+ "/" + site.id;
            return Created(resourceUrl, site);
        }
        }
 /// <summary>
    ///Actualizar los sites
    /// </summary>
    /// <returns>Todos los sites</returns>
    /// <response code="201">Devuelve el listado de sites</response>
    /// <response code="500">Si hay algún error</response>
     [HttpPut]
    public ActionResult Put (Site site){
        var existingSite = Sites.Find(x=>x.id== site.id);
        if (existingSite == null){
            return Conflict("no existe esa categoria");
        } else {
            existingSite.name = site.name;
            return Ok();
        }
        }

               
    /// <summary>
    /// Eliminar sites seleccionados
    /// </summary>
    /// <returns>Todos los sites</returns>
    /// <response code="200">Se ha eliminado</response>
    /// <response code="500">Si hay algún error</response>
     [HttpDelete]
    [Route("{id}")]
    public ActionResult<Category> Delete (int id){
        var site = Sites.Find (x =>x.id == id);
        if (site == null){
            return NotFound();
        } else{
            Sites.Remove(site);
            return NoContent();
        }
    }
    
    
    }
