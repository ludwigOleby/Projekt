using Microsoft.AspNetCore.Http;

namespace Candy_SUT21.ViewModels
{
    public class CandyEditViewModel : CandyCreateViewModel
    {
        public int CandyId { get; set; }
        public string ExistingImagePath { get; set; }
        public string ExistingImageThumbnailPath { get; set; }   
    }
}
