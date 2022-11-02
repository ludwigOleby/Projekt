using Candy_SUT21.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candy_SUT21.ViewModels
{
    public class CandyEditViewModel : CandyCreateViewModel
    {
        public int CandyId { get; set; }
        public string ExistingImagePath { get; set; }
        public string ExistingImageThumbnailPath { get; set; }   
    }
}
