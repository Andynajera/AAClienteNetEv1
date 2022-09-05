
using AACLIENTE.AAAPI.Models.Site;
using AACLIENTE.AAAPI.Models.Category;

using AACLIENTE.AAAPI.Controllers.SitesRepo;
using AACLIENTE.AAAPI.Controllers.SitesController;

using AACLIENTE.AAAPI.Controllers.CategoriesController;
using AACLIENTE.AAAPI.Controllers.CategoriesRepo;


namespace AACLIENTE.AAAPI.Models.Category;

public class Category {
    public int id {get; set;}
    public string name {get; set;}
    public string description {get; set;}
}

