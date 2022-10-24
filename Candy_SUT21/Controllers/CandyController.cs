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
        public IWebHostEnvironment _hosting;

        public CandyController(ICandyRepository candyRepository, ICategoryRepository categoryRepository, IWebHostEnvironment hosting)
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
                
        //Get: Candy/Create
        public IActionResult Create()
        {
            return View();
        }

        //Create new Candy
        //Post: Candy/Create
        [HttpPost]
        public IActionResult Create(CandyCreateViewModel candyItem)
        {
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
                    IsOnSale = candyItem.IsOnSale
                };
                _candyRepository.CreateCandy(item);
            }
            return RedirectToAction("List");
        }

        //Get: Candy/Edit/Id
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            string currentCategory;
            if (id == null)
            {
                return NotFound();
            }
            Candy candyToGet = _candyRepository.GetCandyById(id);
            currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == candyToGet.Category.CategoryName)?.CategoryName;

            if (candyToGet == null)
            {
                return NotFound();
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
                IsOnSale = candyToGet.IsOnSale
            };
            return View(candyEditViewModel);
        }
        //Post: Candy/Edit/Id
        [HttpPost]
        public IActionResult Edit(int id, CandyEditViewModel candyItem)
        {
            if (id != candyItem.CandyId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Candy candyToUpdate = _candyRepository.GetCandyById(candyItem.CandyId);

                candyToUpdate.CandyId = candyItem.CandyId;
                candyToUpdate.Name = candyItem.Name;
                candyToUpdate.CategoryId = candyItem.CategoryId;
                candyToUpdate.Description = candyItem.Description;
                candyToUpdate.Price = candyItem.Price;
                candyToUpdate.StockAmount = candyItem.StockAmount;
                candyToUpdate.IsOnSale = candyItem.IsOnSale;
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

                _candyRepository.UpdateCandy(candyToUpdate);
                return RedirectToAction("List");
            }
            return View(candyItem);
        }

        //Get: Candy/Delete/Id
        public IActionResult Delete(int? id)
        {            
            string currentCategory;
            if (id == null)
            {
                return NotFound();
            }
            Candy candyToGet = _candyRepository.GetCandyById(id);
            currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == candyToGet.Category.CategoryName)?.CategoryName;

            if (candyToGet == null)
            {
                return NotFound();
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
                IsOnSale = candyToGet.IsOnSale
            };
            return View(candyEditViewModel);
        }

        //Post: Candy/Delete/Id
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCandy(int id, CandyEditViewModel candyItem)
        {
            if (id != candyItem.CandyId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Candy candyToDelete = _candyRepository.GetCandyById(candyItem.CandyId);

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
                _candyRepository.DeleteCandy(candyToDelete.CandyId);
                return RedirectToAction("List");
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
