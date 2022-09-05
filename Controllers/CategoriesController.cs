

using Microsoft.AspNetCore.Mvc;


using AACLIENTE.AAAPI.Models.Category;


namespace AACLIENTE.AAAPI.Controllers.CategoriesController;


    [ApiController]
    [Route("[Controller]")]
    public class CategoriesController : ControllerBase
    {
        private static List<Category> Categories = new List<Category>{
            new Category { id=1 ,name="categoria1",description="uno"},
            new Category { id=2 ,name="categoria2",description="dos"}

        };
 
/// <summary>
    /// Mostrar todos los categorias
    /// </summary>
    /// <returns>Todos los categorias</returns>
    /// <response code="200">Devuelve el listado de categorias</response>
    /// <response code="500">Si hay algún error</response>
[HttpGet]
    public ActionResult<List<Category>> Get(){
        return Ok(Categories);
    }
/// <summary>
    /// Mostrar todos los categorias
    /// </summary>
    /// <returns>Todos los categorias</returns>
    /// <response code="200">Devuelve el listado de categorias</response>
    /// <response code="500">Si hay algún error</response>
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Category> Get (int id){
        var category = Categories.Find (x =>x.id == id);
        return category == null ? NotFound() : Ok(category);
    }
    


/// <summary>
    /// añadir categorias
    /// </summary>
    /// <returns>Todos los categorias</returns>
    /// <response code="201">Se ha creado correctamente</response>
    /// <response code="500">Si hay algún error</response>
    [HttpPost]
     public ActionResult<Category> Post([FromBody] Category category){
        var existingCategory = Categories.Find(x=>x.id== category.id);
        var prueba = Categories.Find(x=>x.id== category.id);
        if (existingCategory != null){
          
          String url = Request.Path.ToString() + "/" + category.id;
            return Conflict("ya existe esa categoria");
        } 
        if (prueba != null){
          
          String url = Request.Path.ToString() + "/" + category.id;
            return NotFound("error");
        } else 
        
        {
            Categories.Add(category);
            var resourceUrl = Request.Path.ToString()+ "/" + category.id;
            return Created(resourceUrl, category);
            
        }
        }
 /// <summary>
    ///Actualizar los categotias
    /// </summary>
    /// <returns>Todos los categorias</returns>
    /// <response code="201">Devuelve el listado de categorias</response>
    /// <response code="500">Si hay algún error</response>
    
     [HttpPut]
    public ActionResult Put (Category category){
        var existingCategory = Categories.Find(x=>x.id== category.id);
        if (existingCategory == null){
            return Conflict("no existe esa categoria");
        } else {
            existingCategory.name = category.name;
            return Ok();
        }
        }
               
               
    /// <summary>
    /// Eliminar categorias seleccionados
    /// </summary>
    /// <returns>Todos los categorias</returns>
    /// <response code="200">Se ha eliminado</response>
    /// <response code="500">Si hay algún error</response>
     [HttpDelete]
    [Route("{id}")]
    public ActionResult<Category> Delete (int id){
        var category = Categories.Find (x =>x.id == id);
        if (category == null){
            return NotFound("no funciona");
        } else{
            Categories.Remove(category);
            return NoContent();
        }
    }
    
    
    }


    
   


