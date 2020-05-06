using Microsoft.AspNetCore.Mvc;
using ES.WineShop.Core.Services.Interfaces;
using System.Collections.Generic;
using ES.WineShop.Web.Models;
using System.Threading.Tasks;
using ES.WineShop.Common.Mapper;
using ES.WineShop.Core.Dto;
using ES.WineShop.Common.Enum;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ES.WineShop.Web.Controllers
{
    public class ProductsController : Controller
   {
        #region Fields & Constructors
        private readonly IProductService _productService;
        private readonly IEsProductService _eSProductService;
        private readonly IWsMapper _mapper;

		public ProductsController(IProductService productService, IEsProductService eSProductService, IWsMapper mapper)
		{
            _productService = productService;
            _eSProductService = eSProductService;
            _mapper = mapper;
		}
        #endregion

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            var dtoList = await _eSProductService.GetAllAsync(searchString);
            ViewBag.dataSource = _mapper.Map<IEnumerable<ProductViewModel>>(dtoList);

            return View();
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var productDtos = await _productService.GetAllAsync();
            ViewBag.dataSource = _mapper.Map<IEnumerable<ProductViewModel>>(productDtos);

            ViewData["Categories"] = new SelectList(Enum.GetNames(typeof(ProductCategory)).ToList());
            ViewData["AvailabilityOprions"] = new SelectList(Enum.GetNames(typeof(Availability)).ToList());
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SKU", "Name", "Description", "ShortDescription", "ImageUrl", "Category", "Cost", "ListPrice", "SalePrice", "ShippingCost", "Availability", "IsFreeShipping")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(_mapper.Map<ProductDto>(product));
                await _productService.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}