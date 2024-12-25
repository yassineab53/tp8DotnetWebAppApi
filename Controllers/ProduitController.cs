using Microsoft.AspNetCore.Mvc;
using AppWeb1.Models;
using AppWeb1.Repositories;

namespace AppWeb1.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ProduitController
    {
        private readonly ILogger<ProduitController> _logger;
        private ProduitRepository db;

        public ProduitController(ILogger<ProduitController> logger, IConfiguration config)
        {
            _logger = logger;
            db = new ProduitRepository(config.GetValue<string>("ConnectionStrings:db"));
        }

        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<ProduitModel> GetAllProducts()
        {
            return db.GetAllProducts();
        }

        [HttpPost(Name = "{libelle}/{prix}")]
        public void AddProduct(string libelle, float prix)
        {
            db.AddProduct(libelle, prix);
        }

        [HttpPost(Name = "{id}/{libelle}/{prix}")]
        public void UpdateProduct(int id, string libelle, float prix)
        {
            db.UpdateProduct(id, libelle, prix);
        }

        [HttpGet(Name = "{id}")]
        public void DeleteProduct(int id)
        {
            db.DeleteProduct(id);
        }
    }
}
