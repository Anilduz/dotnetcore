using AutoMapper;
using ECommerceWebApi.DbOperations;
using ECommerceWebApi.ProductOperations.GetProducts;
using ECommerceWebApi.ProductOperations.GetProductsQueryDetail;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GetProductController : ControllerBase
{
    private readonly ECommerceDbContext _context;
    private readonly IMapper _mapper;

    public GetProductController(ECommerceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        ProductDetailViewModel result;
        try
        {
            GetProductQueryDetail query = new GetProductQueryDetail(_context, _mapper);
            query.ProductId = id;
            result = query.Handle();
        }
         
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


        return Ok(result);
    }
}

