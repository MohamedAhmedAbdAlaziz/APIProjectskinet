using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
       private readonly  StoreContext _context;
        public ProductsController(StoreContext context){
                 _context = context;
        }
        [HttpGet]
        public async Task< ActionResult <List<Product>>> GetProducts(){
          //  return "this will be a list of products";
 
      var products = await _context.Products.ToListAsync();
      return Ok(products);
        }


        // [HttpGet("{id}")]
        //  public string GetProduct(int id){
        //     return "Single Product";
        // }



   [HttpGet("{id}")]
         public   async Task<ActionResult<Product>> GetProduct(int id){
           // return "Single Product";
           var pro = await _context.Products.Where(x=>x.Id==id).FirstOrDefaultAsync();
            return Ok(pro);

        }

    }
}    