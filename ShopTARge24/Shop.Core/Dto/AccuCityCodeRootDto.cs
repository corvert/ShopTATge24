using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dto
{
    public class AccuCityCodeRootDto
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public RegionDto Region { get; set; }
        public CountryDto Country { get; set; }
        public AdministrativeAreaDto AdministrativeArea { get; set; }
        public TimeZoneDto TimeZone { get; set; }
        public GeoPositionDto GeoPosition { get; set; }
        public bool IsAlias { get; set; }
        public List<SupplementalAdminAreasDto> SupplementalAdminAreas { get; set; }
        public List<string> DataSets { get; set; }

    }

    public class RegionDto
    {
        public string Id { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class CountryDto
    {
        public string Id { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class AdministrativeAreaDto
    {
        public string Id { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public int Level { get; set; }
        public string LocalizedType { get; set; }
        public string EnglishType { get; set; }
        public string CountryID { get; set; }
    }

    public class TimeZoneDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public string NextOffsetChange { get; set; }
    }

    public class GeoPositionDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ElevationDto Metric { get; set; }
        public ElevationDto Imperial { get; set; }
    }

    public class ElevationDto
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class SupplementalAdminAreasDto
    {
        public int Level { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }
   
}
