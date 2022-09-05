
using AACLIENTE.AAAPI.Models.Site;
using AACLIENTE.AAAPI.Models.Category;

using AACLIENTE.AAAPI.Controllers.SitesRepo;
using AACLIENTE.AAAPI.Controllers.SitesController;

using AACLIENTE.AAAPI.Controllers.CategoriesController;
using AACLIENTE.AAAPI.Controllers.CategoriesRepo;


namespace AACLIENTE.AAAPI.Models.Site;


public class Site {
    public int id {get; set;}
    public string name {get; set;}
    public string userName {get; set;}
    public string password {get; set;}
    public int IdCategory {get; set;}
    
    }