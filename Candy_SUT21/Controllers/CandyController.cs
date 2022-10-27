﻿using Candy_SUT21.Models;
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
        private readonly IDiscountRepository _discountRepository;
        public IWebHostEnvironment _hosting;

        public CandyController(ICandyRepository candyRepository, ICategoryRepository categoryRepository, IDiscountRepository discountRepository, IWebHostEnvironment hosting)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _discountRepository = discountRepository;
            _hosting = hosting;
        }

        public async Task<ViewResult> List(string category)
        {
            IEnumerable<Candy> candies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                candies = await _candyRepository.GetAllCandy();
                var candiesByName = candies.OrderBy(c => c.Name);
                candies = candiesByName;
                currentCategory = "All Candy";
            }
            else
            {
                candies = await _candyRepository.GetAllCandy(); 
                var candyCategory = candies.Where(c => c.Category.CategoryName == category);
                candies = candyCategory;
                currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new CandyListViewModel
            {
                Candies = candies,                
                CurrentCategory = currentCategory
            });
        }

        public async Task<IActionResult> Details(int? id)
        {
            var candy = await _candyRepository.GetCandyById(id);
            if (candy == null)
            {                
                return NotFound();
            }

            return View(candy);
        }
        public async Task<IActionResult> AdminList(string category, string sortOrder)
        {
            IEnumerable<Candy> candies;
            string currentCategory;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParam = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.StockSortParam = sortOrder == "Stock" ? "stock_desc" : "Stock";
            ViewBag.PriceSortParam = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.DiscountSortParam = sortOrder == "Discount" ? "discount_desc" : "Discount";

            if (string.IsNullOrEmpty(category))
            {
                candies = await _candyRepository.GetAllCandy();

                switch(sortOrder)
                {
                    case "name_desc":
                        candies = candies.OrderByDescending(c => c.Name);
                        break;
                    case "category_desc":
                        candies = candies.OrderByDescending(c => c.CategoryId);
                        break;
                    case "Category":
                        candies = candies.OrderBy(c => c.CategoryId);
                        break;
                    case "stock_desc":
                        candies = candies.OrderByDescending(c => c.StockAmount);
                        break;
                    case "Stock":
                        candies = candies.OrderBy(c => c.StockAmount);
                        break;
                    case "price_desc":
                        candies = candies.OrderByDescending(c => c.Price);
                        break;
                    case "Price":
                        candies = candies.OrderBy(c => c.Price);
                        break;
                    case "discount_desc":
                        candies = candies.OrderByDescending(c => c.DiscountId);
                        break;
                    case "Discount":
                        candies = candies.OrderBy(c => c.DiscountId);
                        break;
                    default:
                        candies = candies.OrderBy(c => c.Name);
                        break;
                }
                currentCategory = "All Candy";
            }
            else
            {
                candies = await _candyRepository.GetAllCandy();
                var candyCategory = candies.Where(c => c.Category.CategoryName == category);

                currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory
            });
        }

        //Get: Candy/Create
        public IActionResult Create()
        {
            return View(); 
        }

        //Create new Candy
        //Post: Candy/Create
        [HttpPost]
        public async Task<IActionResult> Create(CandyEditViewModel candyItem)
        {            
            Candy candyToGet = await _candyRepository.GetCandyById(candyItem.CandyId);
           
            if (ModelState.IsValid)
            {
                Candy item = new Candy
                {
                    Name = candyItem.Name,
                    CategoryId = candyItem.CategoryId,
                    Description = candyItem.Description,
                    ImageUrl = ProcessImageFile(candyItem),
                    ImageThumbnailUrl = ProcessImageThumbnailFile(candyItem),
                    Price = candyItem.Price,
                    StockAmount = candyItem.StockAmount,
                    DiscountId = candyItem.DiscountId

                };
                await _candyRepository.CreateCandy(item);
            }
            return RedirectToAction("AdminList");
        }

        //Get: Candy/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            string currentCategory;
            if (id == null)
            {
                return NotFound();
            }
            Candy candyToGet = await _candyRepository.GetCandyById(id);
            if (candyToGet == null)
            {
                Response.StatusCode = 404;
                return View("CandyNotFound", id.Value);
            }     
            currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == candyToGet.Category.CategoryName)?.CategoryName;
                        
            CandyEditViewModel candyEditViewModel = new CandyEditViewModel
            {
                CandyId = candyToGet.CandyId,
                Name = candyToGet.Name,
                CategoryId = candyToGet.CategoryId,
                CurrentCategory = currentCategory,
                Description = candyToGet.Description,
                ExistingImagePath = candyToGet.ImageUrl,
                ExistingImageThumbnailPath = candyToGet.ImageThumbnailUrl,
                Price = candyToGet.Price,
                StockAmount = candyToGet.StockAmount,
                DiscountId = candyToGet.DiscountId
            };
            return View(candyEditViewModel);
        }
        //Post: Candy/Edit/Id
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CandyEditViewModel candyItem)
        {
            if (id != candyItem.CandyId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Candy candyToUpdate = await _candyRepository.GetCandyById(candyItem.CandyId);
                
                candyToUpdate.CandyId = candyItem.CandyId;
                candyToUpdate.Name = candyItem.Name;
                candyToUpdate.CategoryId = candyItem.CategoryId;
                candyToUpdate.Description = candyItem.Description;
                candyToUpdate.Price = candyItem.Price;
                candyToUpdate.StockAmount = candyItem.StockAmount;
                candyToUpdate.DiscountId = candyItem.DiscountId;
                if (candyItem.FileImage != null)
                {
                    if(candyItem.ExistingImagePath != null)
                    {
                        string imagePath = Path.Combine(_hosting.WebRootPath, "Images", candyItem.ExistingImagePath);
                        System.IO.File.Delete(imagePath);
                    }
                    candyToUpdate.ImageUrl = ProcessImageFile(candyItem);

                }
                if(candyItem.FileImageThumbnail != null)
                {
                    if (candyItem.ExistingImagePath != null)
                    {
                        string imageThumbnailPath = Path.Combine(_hosting.WebRootPath,
                            "Images\\thumbnails",
                            candyItem.ExistingImageThumbnailPath);
                        System.IO.File.Delete(imageThumbnailPath);
                    }
                    candyToUpdate.ImageThumbnailUrl = ProcessImageThumbnailFile(candyItem);
                } 
                await _candyRepository.UpdateCandy(candyToUpdate);
                return RedirectToAction("AdminList");
            }
            return View(candyItem);
        }

        //Get: Candy/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {            
            string currentCategory;
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("CandyNotFound", id.Value);
            }
            Candy candyToGet = await _candyRepository.GetCandyById(id);
            currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == candyToGet.Category.CategoryName)?.CategoryName;
            
            if (candyToGet == null)
            {
                Response.StatusCode = 404;
                return View("CandyNotFound", id.Value);
            }
            CandyEditViewModel candyEditViewModel = new CandyEditViewModel
            {
                CandyId = candyToGet.CandyId,
                Name = candyToGet.Name,
                CategoryId = candyToGet.CategoryId,
                CurrentCategory = currentCategory,
                Description = candyToGet.Description,
                ExistingImagePath = candyToGet.ImageUrl,
                ExistingImageThumbnailPath = candyToGet.ImageThumbnailUrl,
                Price = candyToGet.Price,
                StockAmount = candyToGet.StockAmount,
                DiscountId = candyToGet.DiscountId                
            };
            return View(candyEditViewModel);
        }

        //Post: Candy/Delete/Id
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCandy(int id, CandyEditViewModel candyItem)
        {
            if (id != candyItem.CandyId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Candy candyToDelete = await _candyRepository.GetCandyById(candyItem.CandyId);

                    if (candyToDelete.ImageUrl != null)
                    {
                        string imagePath = Path.Combine(_hosting.WebRootPath, "Images", candyToDelete.ImageUrl);
                        System.IO.File.Delete(imagePath);
                    } 
               
                    if (candyToDelete.ImageThumbnailUrl != null)
                    {
                        string imageThumbnailPath = Path.Combine(_hosting.WebRootPath,
                            "Images\\thumbnails",
                            candyToDelete.ImageThumbnailUrl);
                        System.IO.File.Delete(imageThumbnailPath);
                    }
                await _candyRepository.DeleteCandy(candyToDelete.CandyId);
                return RedirectToAction("AdminList");
            }
            return View(candyItem);
        }

        private string ProcessImageFile(CandyCreateViewModel candyItem)
        {
            string uniqueImageName = null;

            if (candyItem.FileImage != null)
            {
                string uploadFileImage = Path.Combine(_hosting.WebRootPath, "Images");
                uniqueImageName = Guid.NewGuid().ToString() + "_" + candyItem.FileImage.FileName;
                string imagePath = Path.Combine(uploadFileImage, uniqueImageName);
                using (var filestream = new FileStream(imagePath, FileMode.Create))
                {
                    candyItem.FileImage.CopyTo(filestream);
                }
            }
            return uniqueImageName;
        }
        private string ProcessImageThumbnailFile(CandyCreateViewModel candyItem)
        {
            string uniqueImageThumbnailName = null;

            if (candyItem.FileImageThumbnail != null)
            {
                string uploadFileImageThumbnail = Path.Combine(_hosting.WebRootPath, "Images\\thumbnails");
                uniqueImageThumbnailName = Guid.NewGuid().ToString() + "_" + candyItem.FileImageThumbnail.FileName;
                string imageThumbnailPath = Path.Combine(uploadFileImageThumbnail, uniqueImageThumbnailName);
                using (var filestream = new FileStream(imageThumbnailPath, FileMode.Create))
                {
                    candyItem.FileImageThumbnail.CopyTo(filestream);
                }
            }
            return uniqueImageThumbnailName;
        }     
            
    }
}
