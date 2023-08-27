namespace MainProject.Pages
{
    public partial class Index
    {
        string googleMapApi = "";
        string googleMapSrc = "";
        string googleMapZoom = "9";

        public void InitialMapAsync()
        {
            googleMapApi = configuration["GoogleMapAPI"] ?? "";
            googleMapSrc = $"https://www.google.com/maps/embed/v1/search?key={googleMapApi}&q=foodbank+in+Melbourne&zoom={googleMapZoom}";
        }
    }
}
