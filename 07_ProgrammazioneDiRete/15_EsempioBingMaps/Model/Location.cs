using System.Text.Json.Serialization;

namespace _15_EsempioBingMaps.Model
{
    public class Address
    {
        [JsonPropertyName("addressLine")]
        public string? AddressLine { get; set; }

        [JsonPropertyName("adminDistrict")]
        public string? AdminDistrict { get; set; }

        [JsonPropertyName("adminDistrict2")]
        public string? AdminDistrict2 { get; set; }

        [JsonPropertyName("countryRegion")]
        public string CountryRegion { get; set; }

        [JsonPropertyName("formattedAddress")]
        public string? FormattedAddress { get; set; }

        [JsonPropertyName("locality")]
        public string? Locality { get; set; }

        [JsonPropertyName("postalCode")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("countryRegionIso2")]
        public string? CountryRegionIso2 { get; set; }
    }

    public class GeocodePoint
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; } = null!;

        [JsonPropertyName("coordinates")]
        public List<double?> Coordinates { get; set; } = null!;

        [JsonPropertyName("calculationMethod")]
        public string? CalculationMethod { get; set; } = null!;

        [JsonPropertyName("usageTypes")]
        public List<string>? UsageTypes { get; set; } = null!;
    }

    public class Point
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double?>? Coordinates { get; set; }
    }

    public class Resource
    {
        [JsonPropertyName("__type")]
        public string? Type { get; set; }

        [JsonPropertyName("bbox")]
        public List<double?>? Bbox { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("point")]
        public Point? Point { get; set; }

        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("confidence")]
        public string? Confidence { get; set; }

        [JsonPropertyName("entityType")]
        public string? EntityType { get; set; }

        [JsonPropertyName("geocodePoints")]
        public List<GeocodePoint?>? GeocodePoints { get; set; }

        [JsonPropertyName("matchCodes")]
        public List<string>? MatchCodes { get; set; }
    }

    public class ResourceSet
    {
        [JsonPropertyName("estimatedTotal")]
        public int? EstimatedTotal { get; set; }

        [JsonPropertyName("resources")]
        public List<Resource>? Resources { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("authenticationResultCode")]
        public string? AuthenticationResultCode { get; set; } = null!;

        [JsonPropertyName("brandLogoUri")]
        public string? BrandLogoUri { get; set; } = null!;

        [JsonPropertyName("copyright")]
        public string? Copyright { get; set; } = null!;

        [JsonPropertyName("resourceSets")]
        public List<ResourceSet>? ResourceSets { get; set; } = null!;

        [JsonPropertyName("statusCode")]
        public int? StatusCode { get; set; } = null!;

        [JsonPropertyName("statusDescription")]
        public string? StatusDescription { get; set; } = null!;

        [JsonPropertyName("traceId")]
        public string? TraceId { get; set; } = null!;

    }
}
