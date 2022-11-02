namespace Candy_SUT21.Models.APIModels
{
    public class GreetingsApiModel
    {
        public class GreetingModel
        {
            public string type { get; set; }
            public string greeting { get; set; }
            public string locale { get; set; }
            public string language { get; set; }
        }

    }
}
