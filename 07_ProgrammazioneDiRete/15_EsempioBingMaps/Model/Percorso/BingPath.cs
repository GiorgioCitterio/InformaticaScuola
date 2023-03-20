using System.Text.Json.Serialization;

namespace _15_EsempioBingMaps.Model.Percorso
{
    public class ActualEnd
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class ActualStart
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("addressLine")]
        public string AddressLine { get; set; }

        [JsonPropertyName("adminDistrict")]
        public string AdminDistrict { get; set; }

        [JsonPropertyName("adminDistrict2")]
        public string AdminDistrict2 { get; set; }

        [JsonPropertyName("countryRegion")]
        public string CountryRegion { get; set; }

        [JsonPropertyName("formattedAddress")]
        public string FormattedAddress { get; set; }

        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
    }

    public class Detail
    {
        [JsonPropertyName("compassDegrees")]
        public int CompassDegrees { get; set; }

        [JsonPropertyName("endPathIndices")]
        public List<int> EndPathIndices { get; set; }

        [JsonPropertyName("maneuverType")]
        public string ManeuverType { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("names")]
        public List<string> Names { get; set; }

        [JsonPropertyName("roadType")]
        public string RoadType { get; set; }

        [JsonPropertyName("startPathIndices")]
        public List<int> StartPathIndices { get; set; }

        [JsonPropertyName("locationCodes")]
        public List<string> LocationCodes { get; set; }

        [JsonPropertyName("roadShieldRequestParameters")]
        public RoadShieldRequestParameters RoadShieldRequestParameters { get; set; }
    }

    public class EndLocation
    {
        [JsonPropertyName("bbox")]
        public List<double> Bbox { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("point")]
        public Point Point { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("confidence")]
        public string Confidence { get; set; }

        [JsonPropertyName("entityType")]
        public string EntityType { get; set; }

        [JsonPropertyName("geocodePoints")]
        public List<GeocodePoint> GeocodePoints { get; set; }

        [JsonPropertyName("matchCodes")]
        public List<string> MatchCodes { get; set; }
    }

    public class EndTime
    {
        [JsonPropertyName("DateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("OffsetMinutes")]
        public int OffsetMinutes { get; set; }
    }

    public class EndWaypoint
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("isVia")]
        public bool IsVia { get; set; }

        [JsonPropertyName("locationIdentifier")]
        public string LocationIdentifier { get; set; }

        [JsonPropertyName("routePathIndex")]
        public int RoutePathIndex { get; set; }
    }

    public class GeocodePoint
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonPropertyName("calculationMethod")]
        public string CalculationMethod { get; set; }

        [JsonPropertyName("usageTypes")]
        public List<string> UsageTypes { get; set; }
    }

    public class Hint
    {
        [JsonPropertyName("hintType")]
        public string HintType { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Instruction
    {
        [JsonPropertyName("formattedText")]
        public object FormattedText { get; set; }

        [JsonPropertyName("maneuverType")]
        public string ManeuverType { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class ItineraryItem
    {
        [JsonPropertyName("compassDirection")]
        public string CompassDirection { get; set; }

        [JsonPropertyName("details")]
        public List<Detail> Details { get; set; }

        [JsonPropertyName("exit")]
        public string Exit { get; set; }

        [JsonPropertyName("iconType")]
        public string IconType { get; set; }

        [JsonPropertyName("instruction")]
        public Instruction Instruction { get; set; }

        [JsonPropertyName("isRealTimeTransit")]
        public bool IsRealTimeTransit { get; set; }

        [JsonPropertyName("maneuverPoint")]
        public ManeuverPoint ManeuverPoint { get; set; }

        [JsonPropertyName("realTimeTransitDelay")]
        public int RealTimeTransitDelay { get; set; }

        [JsonPropertyName("sideOfStreet")]
        public string SideOfStreet { get; set; }

        [JsonPropertyName("tollZone")]
        public string TollZone { get; set; }

        [JsonPropertyName("towardsRoadName")]
        public string TowardsRoadName { get; set; }

        [JsonPropertyName("transitTerminus")]
        public string TransitTerminus { get; set; }

        [JsonPropertyName("travelDistance")]
        public double TravelDistance { get; set; }

        [JsonPropertyName("travelDuration")]
        public int TravelDuration { get; set; }

        [JsonPropertyName("travelMode")]
        public string TravelMode { get; set; }

        [JsonPropertyName("signs")]
        public List<string> Signs { get; set; }

        [JsonPropertyName("warnings")]
        public List<Warning> Warnings { get; set; }

        [JsonPropertyName("hints")]
        public List<Hint> Hints { get; set; }
    }

    public class ManeuverPoint
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class Point
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class RegionTravelSummary
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("subregions")]
        public List<Subregion> Subregions { get; set; }

        [JsonPropertyName("tollDistance")]
        public double TollDistance { get; set; }

        [JsonPropertyName("travelDistance")]
        public double TravelDistance { get; set; }

        [JsonPropertyName("travelDuration")]
        public int TravelDuration { get; set; }

        [JsonPropertyName("travelDurationTraffic")]
        public int TravelDurationTraffic { get; set; }
    }

    public class Resource
    {
        [JsonPropertyName("__type")]
        public string Type { get; set; }

        [JsonPropertyName("bbox")]
        public List<double> Bbox { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("distanceUnit")]
        public string DistanceUnit { get; set; }

        [JsonPropertyName("durationUnit")]
        public string DurationUnit { get; set; }

        [JsonPropertyName("routeLegs")]
        public List<RouteLeg> RouteLegs { get; set; }

        [JsonPropertyName("trafficCongestion")]
        public string TrafficCongestion { get; set; }

        [JsonPropertyName("trafficDataUsed")]
        public string TrafficDataUsed { get; set; }

        [JsonPropertyName("travelDistance")]
        public double TravelDistance { get; set; }

        [JsonPropertyName("travelDuration")]
        public int TravelDuration { get; set; }

        [JsonPropertyName("travelDurationTraffic")]
        public int TravelDurationTraffic { get; set; }

        [JsonPropertyName("travelMode")]
        public string TravelMode { get; set; }
    }

    public class ResourceSet
    {
        [JsonPropertyName("estimatedTotal")]
        public int EstimatedTotal { get; set; }

        [JsonPropertyName("resources")]
        public List<Resource> Resources { get; set; }
    }

    public class RoadShieldRequestParameters
    {
        [JsonPropertyName("bucket")]
        public int Bucket { get; set; }

        [JsonPropertyName("shields")]
        public List<Shield> Shields { get; set; }
    }

    public class BingPath
    {
        [JsonPropertyName("authenticationResultCode")]
        public string AuthenticationResultCode { get; set; }

        [JsonPropertyName("brandLogoUri")]
        public string BrandLogoUri { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("resourceSets")]
        public List<ResourceSet> ResourceSets { get; set; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("statusDescription")]
        public string StatusDescription { get; set; }

        [JsonPropertyName("traceId")]
        public string TraceId { get; set; }
    }

    public class RouteLeg
    {
        [JsonPropertyName("actualEnd")]
        public ActualEnd ActualEnd { get; set; }

        [JsonPropertyName("actualStart")]
        public ActualStart ActualStart { get; set; }

        [JsonPropertyName("alternateVias")]
        public List<object> AlternateVias { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("endLocation")]
        public EndLocation EndLocation { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("itineraryItems")]
        public List<ItineraryItem> ItineraryItems { get; set; }

        [JsonPropertyName("regionTravelSummary")]
        public List<RegionTravelSummary> RegionTravelSummary { get; set; }

        [JsonPropertyName("routeRegion")]
        public string RouteRegion { get; set; }

        [JsonPropertyName("routeSubLegs")]
        public List<RouteSubLeg> RouteSubLegs { get; set; }

        [JsonPropertyName("startLocation")]
        public StartLocation StartLocation { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("travelDistance")]
        public double TravelDistance { get; set; }

        [JsonPropertyName("travelDuration")]
        public int TravelDuration { get; set; }

        [JsonPropertyName("travelMode")]
        public string TravelMode { get; set; }
    }

    public class RouteSubLeg
    {
        [JsonPropertyName("endWaypoint")]
        public EndWaypoint EndWaypoint { get; set; }

        [JsonPropertyName("startWaypoint")]
        public StartWaypoint StartWaypoint { get; set; }

        [JsonPropertyName("travelDistance")]
        public double TravelDistance { get; set; }

        [JsonPropertyName("travelDuration")]
        public int TravelDuration { get; set; }
    }

    public class Shield
    {
        [JsonPropertyName("labels")]
        public List<string> Labels { get; set; }

        [JsonPropertyName("roadShieldType")]
        public int RoadShieldType { get; set; }
    }

    public class StartLocation
    {
        [JsonPropertyName("bbox")]
        public List<double> Bbox { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("point")]
        public Point Point { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("confidence")]
        public string Confidence { get; set; }

        [JsonPropertyName("entityType")]
        public string EntityType { get; set; }

        [JsonPropertyName("geocodePoints")]
        public List<GeocodePoint> GeocodePoints { get; set; }

        [JsonPropertyName("matchCodes")]
        public List<string> MatchCodes { get; set; }
    }

    public class StartTime
    {
        [JsonPropertyName("DateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("OffsetMinutes")]
        public int OffsetMinutes { get; set; }
    }

    public class StartWaypoint
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("isVia")]
        public bool IsVia { get; set; }

        [JsonPropertyName("locationIdentifier")]
        public string LocationIdentifier { get; set; }

        [JsonPropertyName("routePathIndex")]
        public int RoutePathIndex { get; set; }
    }

    public class Subregion
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tollDistance")]
        public double TollDistance { get; set; }

        [JsonPropertyName("travelDistance")]
        public double TravelDistance { get; set; }

        [JsonPropertyName("travelDuration")]
        public int TravelDuration { get; set; }

        [JsonPropertyName("travelDurationTraffic")]
        public int TravelDurationTraffic { get; set; }
    }

    public class Warning
    {
        [JsonPropertyName("severity")]
        public string Severity { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("warningType")]
        public string WarningType { get; set; }

        [JsonPropertyName("endTime")]
        public EndTime EndTime { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("startTime")]
        public StartTime StartTime { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }
    }


}
