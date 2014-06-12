using Spedycja.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spedycja.Site.Helpers
{
    public static class HeatMapHelper
    {
        /// <summary>
        ///     OpenStreetMaps helper
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HeatMap HeatMap(this HtmlHelper helper)
        {
            return new HeatMap();
        }
    }

    public class HeatMap : IHtmlString
    {
        #region Parameters

        /// <summary>
        ///     Wyśrodkowanie: szerokość geograficzna
        /// </summary>
        private string centerLatitude = "0.0";

        /// <summary>
        ///     Wyśrodkowanie: długość geograficzna
        /// </summary>
        private string centerLongtitude = "0.0";

        /// <summary>
        ///     Ustawienie możliwości edycji mapy
        /// </summary>
        private bool isEditable;

        /// <summary>
        ///     Wysokość wyświetlanej mapy
        /// </summary>
        private int mapHeight = 200;

        /// <summary>
        ///     Szerokość wyświetlanej mapy
        /// </summary>
        private int mapWidth = -1;

        /// <summary>
        ///     Ustala ikonę markera
        /// </summary>
        private string markerIcon = "greenIcon";

        /// <summary>
        ///     Wyłączenie powiększania przez scrollowanie
        /// </summary>
        private bool mouseScrollZoom = true;

        /// <summary>
        ///     Nazwa instancji kontrolki
        /// </summary>
        private string name;

        /// <summary>
        ///     Wyświetlanie wszystkich POI z listy
        /// </summary>
        private IList<POIModel> poiList;

        /// <summary>
        /// Lista punktow heat
        /// </summary>
        private IList<POIModel> heatPointList;

        /// <summary>
        ///     Poziom przybliżenia mapy
        /// </summary>
        private int zoomLevel = 15;

        public HeatMap Name(string name)
        {
            this.name = name;

            return this;
        }

        public HeatMap CenterLatitude(string centerLatitude)
        {
            this.centerLatitude = centerLatitude;
            this.centerLatitude = centerLatitude.Replace(',', '.');

            return this;
        }

        public HeatMap CenterLatitude(float centerLatitude)
        {
            this.centerLatitude = centerLatitude.ToString();
            this.centerLatitude = this.centerLatitude.Replace(',', '.');

            return this;
        }

        public HeatMap CenterLongtitude(string centerLongtitude)
        {
            this.centerLongtitude = centerLongtitude;
            this.centerLongtitude = centerLongtitude.Replace(',', '.');

            return this;
        }

        public HeatMap CenterLongtitude(float centerLongtitude)
        {
            this.centerLongtitude = centerLongtitude.ToString();
            this.centerLongtitude = this.centerLongtitude.Replace(',', '.');

            return this;
        }

        public HeatMap ZoomLevel(string zoomLevel)
        {
            zoomLevel = zoomLevel.Replace('.', ',');
            this.zoomLevel = int.Parse(zoomLevel);

            return this;
        }

        public HeatMap ZoomLevel(int zoomLevel)
        {
            this.zoomLevel = zoomLevel;

            return this;
        }

        public HeatMap MapHeight(string mapHeight)
        {
            this.mapHeight = int.Parse(mapHeight);

            return this;
        }

        public HeatMap MapHeight(int mapHeight)
        {
            this.mapHeight = mapHeight;

            return this;
        }

        public HeatMap MapWidth(string mapWidth)
        {
            this.mapWidth = int.Parse(mapWidth);

            return this;
        }

        public HeatMap MapWidth(int mapWidth)
        {
            this.mapWidth = mapWidth;

            return this;
        }

        public HeatMap MapEditableTrue(bool isEditable)
        {
            this.isEditable = isEditable;

            return this;
        }

        public HeatMap MouseScrollZoom(bool mouseScrollZoom)
        {
            this.mouseScrollZoom = mouseScrollZoom;

            return this;
        }

        public HeatMap MarkerIcon(string markerIcon)
        {
            this.markerIcon = markerIcon;
            return this;
        }

        public HeatMap PoiList(IList<POIModel> poiList)
        {
            this.poiList = poiList;
            return this;
        }

        public HeatMap HeatPointList(IList<POIModel> heatPointList)
        {
            this.heatPointList = heatPointList;
            return this;
        }

        #endregion

        /// <summary>
        ///     Renderowanie gotowego Html'a + JS
        /// </summary>
        /// <returns></returns>
        private string render()
        {
            string returnString = "";

            if (name == null)
            {
                name = "Map_" + Guid.NewGuid().ToString().Substring(0, 5);
            }

            if (mapWidth != null)
            {
                returnString += "<div id=" + name + " style=\"height: " + mapHeight + "px; width:" + mapWidth +
                                "px\"></div>";
            }
            else if (mapWidth == -1)
            {
                returnString += "<div id=" + name + " style=\"height: " + mapHeight + "px\"></div>";
            }

            if (isEditable)
            {
                returnString += "<input type='hidden' id='map_" + name + "_lat'></input><input type='hidden' id='map_" +
                                name + "_long'></input>";
            }

            returnString += "<script>";
            if (mouseScrollZoom == false)
            {
                returnString += "var map = L.map('" + name + "',{scrollWheelZoom: false, doubleClickZoom: " +
                                ((!isEditable).ToString()).ToLower() + ", center:[" + centerLatitude + ", " +
                                centerLongtitude + "], zoom: " + zoomLevel + "});";
            }
            else if (mouseScrollZoom)
            {
                returnString += "var map = L.map('" + name + "',{doubleClickZoom : " +
                                ((!isEditable).ToString()).ToLower() + ", center:[" + centerLatitude + ", " +
                                centerLongtitude + "], zoom: " + zoomLevel + "});";
            }

            returnString += @"var CustomIcon = L.Icon.extend({
                                options: {
                                    shadowUrl: 'http://oi57.tinypic.com/2vvwfit.jpg'
                                }
                            });

                             var greenIcon = new CustomIcon({iconUrl: 'http://oi62.tinypic.com/23licna.jpg', iconAnchor: [12, 41], popupAnchor:  [0, -41]});


                             L.icon = function (options) {
                                    return new L.Icon(options);
                                };
//
//var polygon = L.polygon([
//    [32.509, -0.08],
//    [41.503, -20.12]
//]).addTo(map);



";

            returnString +=
                "L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { attribution: 'Map data &copy; <a href=\"http://openstreetmap.org\">OpenStreetMap</a> contributors, <a href=\"http://creativecommons.org/licenses/by-sa/2.0/\">CC-BY-SA</a>.', maxZoom: 18 }).addTo(map);";

            if (isEditable)
            {
                returnString +=
                    @"map.on('dblclick', onMapClick);
                               function onMapClick(e) {   
                               var marker = L.marker([e.latlng.lat, e.latlng.lng], {draggable: true, title: 'Poi Name', icon: " +
                    markerIcon + @"}).addTo(map);
                               marker.bindPopup(e.latlng.toString()).openPopup();
                               marker.on('move', onMarkerMove);

                               document.getElementById('map_" + name + @"_lat').value = e.latlng.lat;
                               document.getElementById('map_" + name +
                    @"_long').value =e.latlng.lng;                               
                              }

                              function onMarkerMove(e){

                               e.target.bindPopup( e.latlng.toString()).openPopup();
                               document.getElementById('map_" + name + @"_lat').value = e.latlng.lat;
                               document.getElementById('map_" + name + @"_long').value =e.latlng.lng;
                              }

                              function onMarkerClick(e){
   
                               e.target.bindPopup(e.latlng.toString()).openPopup();
                               
                              }";
            }

            if (poiList != null)
            {
                if (poiList.Count != 0)
                {
                    string lat, lng, bounds = "";
                    string poiNo = "";

                    foreach (POIModel x in poiList)
                    {
                        lat = (x.Latitude.ToString()).Replace(',', '.');
                        lng = (x.Longtitude.ToString()).Replace(',', '.');
                        poiNo = x.No;
                        poiNo = poiNo.Replace("/", "");

                        returnString += "var marker" + poiNo + " = L.marker([" + lat + ", " + lng +
                                        "], {draggable: true, icon:" + markerIcon + @"}).addTo(map);";
                        returnString += "marker" + poiNo + ".bindPopup('" + x.Name + "').openPopup();";
                        //linia
                        //returnString += "var polygon = L.polygon([" +
                        //                    "[32.509, -0.08]," +
                        //                    "[41.503, -20.12]" +
                        //                "]).addTo(map);";

                        bounds += "[" + lat + ", " + lng + "],";
                    }

                    #region linia
                    string startLat = "0.0";
                    string statyLong = "0.0";
                    string endLat = "0.0";
                    string endLong = "0.0";
                    int counter = 0;
                    foreach (POIModel x in poiList)
                    {
                        lat = (x.Latitude.ToString()).Replace(',', '.');
                        lng = (x.Longtitude.ToString()).Replace(',', '.');
                        poiNo = x.No;
                        poiNo = poiNo.Replace("/", "");

                        if (counter == 0)
                        {
                            startLat = lat;
                            statyLong = lng;
                        }

                        if (counter == 1)
                        {
                            endLat = lat;
                            endLong = lng;

                            returnString += "var polygon = L.polygon([" +
                                                "[" + startLat + ", " + statyLong + "]," +
                                                "[" + endLat + ", " + endLong + "]" +
                                            "]).addTo(map);";
                        }
                        counter++;
                        if (counter == 2)
                        {
                            counter = 0;
                        }
                        //linia

                        //returnString += "var polygon = L.polygon([" +
                        //                    "[" + lat + ", " + lng + "]," +
                        //                    "[41.503, -20.12]" +
                        //                "]).addTo(map);";


                    }
                    #endregion

                    bounds = bounds.Remove(bounds.Length - 1);

                    returnString += @"map.fitBounds([" + bounds + "]);";
                }
            }

            if (heatPointList != null)
            {
                if (heatPointList.Count != 0)
                {
                    //string lat, lng, bounds = "";
                    //string poiNo = "";
                    //int counterArray = 0;

                    //returnString += "var addressPoints = new Array();";

                    //foreach (POIModel x in heatPointList)
                    //{
                    //    lat = (x.Latitude.ToString()).Replace(',', '.');
                    //    lng = (x.Longtitude.ToString()).Replace(',', '.');
                    //    poiNo = x.No;
                    //    poiNo = poiNo.Replace("/", "");

                    //    returnString += "addressPoints[" + counterArray + "] = [" + x.Latitude + "," + x.Longtitude + ",1000]";

                    //}

                    //returnString += "var heat = L.heatLayer(addressPoints).addTo(map);";

                }
            }

            returnString += "</script>";

            return returnString;
        }

        #region ReturnHtml

        public string ToHtmlString()
        {
            return render();
        }

        public override string ToString()
        {
            return render();
        }

        #endregion
    }
}