using Candy_SUT21.Models;
using Candy_SUT21.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{
    public class CandyController : Controller 
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;
        public IWebHostEnvironment _hosting;

        public CandyController(ICandyRepository candyRepository , ICategoryRepository categoryRepository, IWebHostEnvironment hosting)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _hosting = hosting;
        }

       public ViewResult List(string category) 
        {
            IEnumerable<Candy> candies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy.OrderBy(c => c.CandyId);
                currentCategory = "All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.Where(c => c.Category.CategoryName == category);

                currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var candy = _candyRepository.GetCandyById(id);
            if (candy == null)
            {
                return NotFound();
            }

            return View(candy);
        }
        public ViewResult AdminList(string category)
        {
            IEnumerable<Candy> candies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy.OrderBy(c => c.CandyId);
                currentCategory = "All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.Where(c => c.Category.CategoryName == category);

                currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        //Create new Candy
        //Post: Candy/Create
        [HttpPost]
        public async Task<IActionResult> Create(CandyViewModel candyItem)
        {
            if(ModelState.IsValid)
            {
                if(candyItem.FileImageThumbnail != null && candyItem.FileImage != null)                
                {
                    string uploadFileImage = Path.Combine(_hosting.WebRootPath, @"\Images\");                   
                    string fullPathFileImage = Path.Combine(uploadFileImage, candyItem.FileImage.FileName );
                    await candyItem.FileImage.CopyToAsync(new FileStream(fullPathFileImage, FileMode.Create));

                    string uploadFileImageThumbnail = Path.Combine(_hosting.WebRootPath, @"\Images\thumbnails\");
                    string fullPathFileImageThumbnail = Path.Combine(uploadFileImageThumbnail, candyItem.FileImageThumbnail.FileName);
                    await candyItem.FileImageThumbnail.CopyToAsync(new FileStream(fullPathFileImageThumbnail, FileMode.Create));
                }
                Candy item = new Candy
                {
                    Name = candyItem.Name,
                    CategoryId = candyItem.CategoryId,
                    Description = candyItem.Description,
                    ImageThumbnailUrl = Path.Combine(@"\Images\thumbnails\", candyItem.FileImageThumbnail.FileName),
                    ImageUrl = Path.Combine(@"\Images\", candyItem.FileImage.FileName),
                    Price = candyItem.Price,
                    StockAmount = candyItem.StockAmount,
                    IsOnSale = candyItem.IsOnSale
                };
                _candyRepository.CreateCandy(item);
            }
        
            return View(candyItem);
        }

        //Get: Candy/Edit/Id
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var candyToGet = _candyRepository.GetCandyById(id);
            if (candyToGet == null)
            {
                return NotFound();
            }
            CandyViewModel candyViewModel = new CandyViewModel
            {
                CandyId = candyToGet.CandyId,
                Name = candyToGet.Name,
                CategoryId = candyToGet.CategoryId,
                Description = candyToGet.Description,
                ImageUrl = candyToGet.ImageUrl,
                ImageThumbnailUrl= candyToGet.ImageThumbnailUrl,
                Price = candyToGet.Price,
                StockAmount = candyToGet.StockAmount,
                IsOnSale = candyToGet.IsOnSale                
            };
            return View(candyViewModel);
        }
        //public IActionResult Edit(CandyViewModel candyItem)
        //{
        //    if(ModelState.IsValid)
        //    {
               

        //    }
        //}
    }
}
