
using Microsoft.AspNetCore.Mvc;
using AACLIENTE.AAAPI.Models.Site;
using AACLIENTE.AAAPI.Models.Category;

using AACLIENTE.AAAPI.Controllers.SitesRepo;
using AACLIENTE.AAAPI.Controllers.SitesController;

using AACLIENTE.AAAPI.Controllers.CategoriesController;
using AACLIENTE.AAAPI.Controllers.CategoriesRepo;

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

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Site> Get (int id){
        var site = Sites.Find (x =>x.id == id);
        return site == null ? NotFound() : Ok(site);
    }
    



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
