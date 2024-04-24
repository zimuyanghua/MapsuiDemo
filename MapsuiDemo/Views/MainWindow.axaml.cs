using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Widgets;

namespace MapsuiDemo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

            var memoryLayer = new MemoryLayer()
            {
                Name = "MemoryLayer",
            };


            mapControl.Map?.Layers.Add(memoryLayer);
            mapControl.Map?.Layers.Add(CreatePointsLayer());
            mapControl.Map.Widgets.Add(new MapInfoWidget(mapControl.Map));
        }

        private static MemoryLayer CreatePointsLayer()
        {
            var feature = new PointFeature(SphericalMercator.FromLonLat(116, 39).ToMPoint());
            feature["name"] = "北京";
            var memoryLayer = new MemoryLayer()
            {
                Name = "Points",
                IsMapInfoLayer = true,
                
                Features = new[]
                {
                    feature
                },
                Style = CreateBitmapStyle()
            };
            return memoryLayer;
        }

        private static SymbolStyle CreateBitmapStyle()
        {
            
            return new SymbolStyle
            {
                BitmapId = typeof(MainWindow).LoadBitmapId("location.png"),
            };
        }
    }
}