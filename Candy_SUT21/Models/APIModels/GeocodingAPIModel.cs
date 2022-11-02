using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models.APIModels
{
    public class GeocodingAPIModel
    {

        public Result[] Results { get; set; }
        public GeocodeQuery Query { get; set; }


    }
    public class GeocodeQuery
    {
        public string Text { get; set; }
        public Parsed Parsed { get; set; }
    }

    public class Parsed
    {
        public string Housenumber { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Expected_type { get; set; }
    }

    public class Result
    {
        public Datasource Datasource { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Country_code { get; set; }
        public string Municipality { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Distance { get; set; }
        public string Formatted { get; set; }
        public string Address_line1 { get; set; }
        public string Address_line2 { get; set; }
        public string Category { get; set; }
        public Timezone Timezone { get; set; }
        public string Tesult_type { get; set; }
        public Rank Tank { get; set; }
        public string Place_id { get; set; }
        public Bbox Bbox { get; set; }
        public string State { get; set; }
        public string District { get; set; }
    }

    public class Datasource
    {
        public string Sourcename { get; set; }
        public string Attribution { get; set; }
        public string License { get; set; }
        public string Url { get; set; }
    }

    public class Timezone
    {
        public string Name { get; set; }
        public string Name_alt { get; set; }
        public string Offset_STD { get; set; }
        public int Offset_STD_seconds { get; set; }
        public string Offset_DST { get; set; }
        public int Offset_DST_seconds { get; set; }
        public string Abbreviation_STD { get; set; }
        public string Abbreviation_DST { get; set; }
    }

    public class Rank
    {
        public float Importance { get; set; }
        public float Popularity { get; set; }
        public float Confidence { get; set; }
        public int Confidence_city_level { get; set; }
        public string Match_type { get; set; }
    }

    public class Bbox
    {
        public float Lon1 { get; set; }
        public float Lat1 { get; set; }
        public float Lon2 { get; set; }
        public float Lat2 { get; set; }
    }
}
