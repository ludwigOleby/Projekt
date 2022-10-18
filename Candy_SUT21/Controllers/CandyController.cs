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
        private readonly IHostingEnvironment _hosting;

        public CandyController(ICandyRepository candyRepository , ICategoryRepository categoryRepository, IHostingEnvironment hosting)
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
        [HttpPost]
        public IActionResult Create(CandyViewModel candy)
        {
            if(ModelState.IsValid)
            {
                if(candy.FileImageThumbnail != null && candy.FileImage != null)
                {
                    string uploadFileImage = Path.Combine(_hosting.WebRootPath, @"Images/");
                    string fullPathFileImage = Path.Combine(uploadFileImage, candy.FileImage.FileName);
                    candy.FileImage.CopyTo(new FileStream(fullPathFileImage, FileMode.Create));

                    string uploadFileImageThumbnail = Path.Combine(_hosting.WebRootPath, @"Images/thumbnails");
                    string fullPathFileImageThumbnail = Path.Combine(uploadFileImageThumbnail, candy.FileImageThumbnail.FileName);
                    candy.FileImageThumbnail.CopyTo(new FileStream(fullPathFileImageThumbnail, FileMode.Create));
                }
                Candy item = new Candy
                {
                    Name = candy.Name,
                    CategoryId = candy.CategoryId,
                    Description = candy.Description,
                    ImageThumbnailUrl = candy.ImageThumbnailUrl,
                    ImageUrl = candy.ImageUrl,
                    Price = candy.Price,
                    StockAmount = candy.StockAmount,
                    IsOnSale = candy.IsOnSale
                };
                _candyRepository.CreateCandy(item);
            }
            return View(candy);
        }
    }
}
