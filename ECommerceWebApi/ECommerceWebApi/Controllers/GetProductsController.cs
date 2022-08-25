using AutoMapper;
using ECommerceWebApi.DbOperations;
using ECommerceWebApi.ProductOperations.GetProducts;
using ECommerceWebApi.ProductOperations.GetProductsQueryDetail;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GetProductsController : ControllerBase
{
    private readonly ECommerceDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsController(ECommerceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        GetProductsQuery query = new GetProductsQuery(_context);
        var result = query.Handle();
        return Ok(result);
    }
}

