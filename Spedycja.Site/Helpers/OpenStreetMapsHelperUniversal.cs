using Spedycja.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spedycja.Site.Helpers
{
//    public static class OpenStreetMapsHelperUniversal
//    {
//        /// <summary>
//        ///     OpenStreetMaps helper
//        /// </summary>
//        /// <param name="helper"></param>
//        /// <returns></returns>
//        public static OpenStreetMapsUniversal OpenStreetMapsUniversal(this HtmlHelper helper)
//        {
//            return new OpenStreetMapsUniversal();
//        }
//    }

//    public class OpenStreetMapsUniversal : IHtmlString
//    {
//        #region Parameters

//        /// <summary>
//        ///     Wyśrodkowanie: szerokość geograficzna
//        /// </summary>
//        private string centerLatitude = "0.0";

//        /// <summary>
//        ///     Wyśrodkowanie: długość geograficzna
//        /// </summary>
//        private string centerLongtitude = "0.0";

//        /// <summary>
//        ///     Ustawienie możliwości edycji mapy
//        /// </summary>
//        private bool isEditable;

//        /// <summary>
//        ///     Wysokość wyświetlanej mapy
//        /// </summary>
//        private int mapHeight = 200;

//        /// <summary>
//        ///     Szerokość wyświetlanej mapy
//        /// </summary>
//        private int mapWidth = -1;

//        /// <summary>
//        ///     Ustala ikonę markera
//        /// </summary>
//        private string markerIcon = "greenIcon";

//        /// <summary>
//        ///     Wyłączenie powiększania przez scrollowanie
//        /// </summary>
//        private bool mouseScrollZoom = true;

//        /// <summary>
//        ///     Nazwa instancji kontrolki
//        /// </summary>
//        private string name;

//        /// <summary>
//        ///     Wyświetlanie wszystkich POI z listy
//        /// </summary>
//        private IList<POIModel> poiList;

//        /// <summary>
//        ///     Poziom przybliżenia mapy
//        /// </summary>
//        private int zoomLevel = 15;

//        /// <summary>
//        ///     Mozliwosc przesuwania punktow na mapie
//        /// </summary>
//        private string markerDraggable = "true";

//        private bool addLabel = false;

//        public OpenStreetMapsUniversal Name(string name)
//        {
//            this.name = name;

//            return this;
//        }

//        public OpenStreetMapsUniversal CenterLatitude(string centerLatitude)
//        {
//            this.centerLatitude = centerLatitude;
//            this.centerLatitude = centerLatitude.Replace(',', '.');

//            return this;
//        }

//        public OpenStreetMapsUniversal CenterLatitude(float centerLatitude)
//        {
//            this.centerLatitude = centerLatitude.ToString();
//            this.centerLatitude = this.centerLatitude.Replace(',', '.');

//            return this;
//        }

//        public OpenStreetMapsUniversal CenterLongtitude(string centerLongtitude)
//        {
//            this.centerLongtitude = centerLongtitude;
//            this.centerLongtitude = centerLongtitude.Replace(',', '.');

//            return this;
//        }

//        public OpenStreetMapsUniversal CenterLongtitude(float centerLongtitude)
//        {
//            this.centerLongtitude = centerLongtitude.ToString();
//            this.centerLongtitude = this.centerLongtitude.Replace(',', '.');

//            return this;
//        }

//        public OpenStreetMapsUniversal ZoomLevel(string zoomLevel)
//        {
//            zoomLevel = zoomLevel.Replace('.', ',');
//            this.zoomLevel = int.Parse(zoomLevel);

//            return this;
//        }

//        public OpenStreetMapsUniversal ZoomLevel(int zoomLevel)
//        {
//            this.zoomLevel = zoomLevel;

//            return this;
//        }

//        public OpenStreetMapsUniversal MapHeight(string mapHeight)
//        {
//            this.mapHeight = int.Parse(mapHeight);

//            return this;
//        }

//        public OpenStreetMapsUniversal MapHeight(int mapHeight)
//        {
//            this.mapHeight = mapHeight;

//            return this;
//        }

//        public OpenStreetMapsUniversal MapWidth(string mapWidth)
//        {
//            this.mapWidth = int.Parse(mapWidth);

//            return this;
//        }

//        public OpenStreetMapsUniversal MapWidth(int mapWidth)
//        {
//            this.mapWidth = mapWidth;

//            return this;
//        }

//        public OpenStreetMapsUniversal MapEditableTrue(bool isEditable)
//        {
//            this.isEditable = isEditable;

//            return this;
//        }

//        public OpenStreetMapsUniversal MouseScrollZoom(bool mouseScrollZoom)
//        {
//            this.mouseScrollZoom = mouseScrollZoom;

//            return this;
//        }

//        public OpenStreetMapsUniversal MarkerIcon(string markerIcon)
//        {
//            this.markerIcon = markerIcon;
//            return this;
//        }

//        public OpenStreetMapsUniversal PoiList(IList<POIModel> poiList)
//        {
//            this.poiList = poiList;
//            return this;
//        }

//        public OpenStreetMapsUniversal MarkerDraggable(string markerDraggable)
//        {
//            this.markerDraggable = markerDraggable;
//            return this;
//        }

//        public OpenStreetMapsUniversal AddLabel(bool addLabel)
//        {
//            this.addLabel = addLabel;
//            return this;
//        }

//        #endregion

//        /// <summary>
//        ///     Renderowanie gotowego Html'a + JS
//        /// </summary>
//        /// <returns></returns>
//        private string render()
//        {
//            string returnString = "";

//            if (name == null)
//            {
//                name = "Map_" + Guid.NewGuid().ToString().Substring(0, 5);
//            }

//            if (mapWidth != null)
//            {
//                returnString += "<div id=" + name + " style=\"height: " + mapHeight + "px; width:" + mapWidth +
//                                "px\"></div>";
//            }
//            else if (mapWidth == -1)
//            {
//                returnString += "<div id=" + name + " style=\"height: " + mapHeight + "px\"></div>";
//            }

//            if (isEditable)
//            {
//                returnString += "<input type='hidden' id='map_" + name + "_lat'></input><input type='hidden' id='map_" +
//                                name + "_long'></input>";
//            }

//            returnString += @"<style>
//                                .sprint-car-label
//                                {
//                                    z-index:99999;
//                                    position:absolute;
//                                    display: block;
//                                    width: 57px;
//                                    text-align: center;
//                                    margin-top: 3px;
//                                    font-size:9px;
//                                }
//                            </style>";

//            returnString += "<script>";
//            if (mouseScrollZoom == false)
//            {
//                returnString += "var map = L.map('" + name + "',{scrollWheelZoom: false, doubleClickZoom: " +
//                                ((!isEditable).ToString()).ToLower() + ", center:[" + centerLatitude + ", " +
//                                centerLongtitude + "], zoom: " + zoomLevel + "});";
//            }
//            else if (mouseScrollZoom)
//            {
//                returnString += "var map = L.map('" + name + "',{doubleClickZoom : " +
//                                ((!isEditable).ToString()).ToLower() + ", center:[" + centerLatitude + ", " +
//                                centerLongtitude + "], zoom: " + zoomLevel + "});";
//            }

//            returnString += @"var CustomIcon = L.Icon.extend({
//                                options: {
//                                    shadowUrl: 'Content/images/maps/marker-shadow.png'
//                                }
//                            });
//
//                             var greenIcon = new CustomIcon({iconUrl: 'Images/marker-icon-green.png'});
//                                 
//
//                             L.icon = function (options) {
//                                    return new L.Icon(options);
//                                };
//
//                            L.Icon.Label = L.Icon.extend({
//	                            options: {
//		                            /*
//		                            labelAnchor: (Point) (top left position of the label within the wrapper, default is right)
//		                            wrapperAnchor: (Point) (position of icon and label relative to Lat/Lng)
//		                            iconAnchor: (Point) (top left position of icon within wrapper)
//		                            labelText: (String) (label's text component, if this is null the element will not be created)
//		                            */
//		                            /* Icon options:
//		                            iconUrl: (String) (required)
//		                            iconSize: (Point) (can be set through CSS)
//		                            iconAnchor: (Point) (centered by default if size is specified, can be set in CSS with negative margins)
//		                            popupAnchor: (Point) (if not specified, popup opens in the anchor point)
//		                            shadowUrl: (Point) (no shadow by default)
//		                            shadowSize: (Point)
//		                            */
//		                            labelClassName: ''
//	                            },
//	
//	                            initialize: function (options) {
//		                            L.Util.setOptions(this, options);
//		                            L.Icon.prototype.initialize.call(this, this.options);
//	                            },
//
//	                            setLabelAsHidden: function () {
//		                            this._labelHidden = true;
//	                            },
//
//	                            createIcon: function () {
//		                            return this._createLabel(L.Icon.prototype.createIcon.call(this));
//	                            },
//	
//	                            createShadow: function () {
//		                            if (!this.options.shadowUrl) {
//			                            return null;
//		                            }
//		                            var shadow = L.Icon.prototype.createShadow.call(this);
//		                            //need to reposition the shadow
//		                            if (shadow) {
//			                            shadow.style.marginLeft = (-this.options.wrapperAnchor.x) + 'px';
//			                            shadow.style.marginTop = (-this.options.wrapperAnchor.y) + 'px';
//		                            }
//		                            return shadow;
//	                            },
//
//	                            updateLabel: function (icon, text) {
//		                            if (icon.nodeName.toUpperCase() === 'DIV') {
//			                            icon.childNodes[1].innerHTML = text;
//			
//			                            this.options.labelText = text;
//		                            }
//	                            },
//
//	                            showLabel: function (icon) {
//		                            if (!this._labelTextIsSet()) {
//			                            return;
//		                            }
//
//		                            icon.childNodes[1].style.display = 'block';
//	                            },
//
//	                            hideLabel: function (icon) {
//		                            if (!this._labelTextIsSet()) {
//			                            return;
//		                            }
//
//		                            icon.childNodes[1].style.display = 'none';
//	                            },
//
//	                            _createLabel: function (img) {
//		                            if (!this._labelTextIsSet()) {
//			                            return img;
//		                            }
//
//		                            var wrapper = document.createElement('div'),
//			                            label = document.createElement('span');
//
//		                            // set up wrapper anchor
//		                            wrapper.style.marginLeft = (-this.options.wrapperAnchor.x) + 'px';
//		                            wrapper.style.marginTop = (-this.options.wrapperAnchor.y) + 'px';
//
//		                            wrapper.className = 'leaflet-marker-icon-wrapper leaflet-zoom-animated';
//
//		                            // set up label
//		                            label.className = 'leaflet-marker-iconlabel ' + this.options.labelClassName;
//
//		                            label.innerHTML = this.options.labelText;
//
//		                            label.style.marginLeft = this.options.labelAnchor.x + 'px';
//		                            label.style.marginTop = this.options.labelAnchor.y + 'px';
//
//		                            if (this._labelHidden) {
//			                            label.style.display = 'none';
//			                            // Ensure that the pointer cursor shows
//			                            img.style.cursor = 'pointer';
//		                            }
//		
//		                            //reset icons margins (as super makes them -ve)
//		                            img.style.marginLeft = this.options.iconAnchor.x + 'px';
//		                            img.style.marginTop = this.options.iconAnchor.y + 'px';
//		
//		                            wrapper.appendChild(img);
//		                            wrapper.appendChild(label);
//
//		                            return wrapper;
//	                            },
//	
//	                            _labelTextIsSet: function () {
//		                            return typeof this.options.labelText !== 'undefined' && this.options.labelText !== null;
//	                            }
//                            });
//
//                            var SprintIcon = L.Icon.Label.extend({
//			                options: {
//				                iconUrl: 'Content/images/maps/TruckPOI.png',
//				                shadowUrl: null,
//				                iconSize: new L.Point(57, 57),
//				                iconAnchor: new L.Point(-28, -57),
//				                labelAnchor: new L.Point(-28, -26),
//				                wrapperAnchor: new L.Point(0, 0),
//                                popupAnchor:  new L.Point(0, -57),
//				                labelClassName: 'sprint-car-label'
//			                }
//		                });";

//            returnString +=
//                "L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { attribution: 'Map data &copy; <a href=\"http://openstreetmap.org\">OpenStreetMap</a> contributors, <a href=\"http://creativecommons.org/licenses/by-sa/2.0/\">CC-BY-SA</a>.', maxZoom: 18 }).addTo(map);";

//            if (isEditable)
//            {
//                returnString +=
//                    @"map.on('dblclick', onMapClick);
//                               function onMapClick(e) {   
//                               var marker = L.marker([e.latlng.lat, e.latlng.lng], {draggable: " + markerDraggable + ", title: 'Poi Name', icon: " +
//                    markerIcon + @"}).addTo(map);
//                               marker.bindPopup(e.latlng.toString()).openPopup();
//                               marker.on('move', onMarkerMove);
//
//                               document.getElementById('map_" + name + @"_lat').value = e.latlng.lat;
//                               document.getElementById('map_" + name +
//                    @"_long').value =e.latlng.lng;                               
//                              }
//
//                              function onMarkerMove(e){
//
//                               e.target.bindPopup( e.latlng.toString()).openPopup();
//                               document.getElementById('map_" + name + @"_lat').value = e.latlng.lat;
//                               document.getElementById('map_" + name + @"_long').value =e.latlng.lng;
//                              }
//
//                              function onMarkerClick(e){
//   
//                               e.target.bindPopup(e.latlng.toString()).openPopup();
//                              }";
//            }

//            if (poiList != null)
//            {
//                if (poiList.Count != 0)
//                {
//                    string lat, lng, bounds = "";
//                    string poiNo = "";

//                    foreach (POIModel x in poiList)
//                    {
//                        lat = (x.Latitude.ToString()).Replace(',', '.');
//                        lng = (x.Longtitude.ToString()).Replace(',', '.');
//                        poiNo = x.No;
//                        poiNo = poiNo.Replace("/", "");

//                        returnString += "var marker" + poiNo + " = L.marker([" + lat + ", " + lng +
//                                        "], {draggable: " + markerDraggable + ",icon: new SprintIcon({ labelText: '" + poiNo + "' }) }).addTo(map);";
//                        returnString += "marker" + poiNo + ".bindPopup('" + x.Name + "').openPopup();";

//                        //if (addLabel)
//                        //{
//                        //   returnString +=  " marker" + poiNo + "" 
//                        //}

//                        bounds += "[" + lat + ", " + lng + "],";
//                    }

//                    bounds = bounds.Remove(bounds.Length - 1);

//                    returnString += @"map.fitBounds([" + bounds + "]);";
//                }
//            }

//            returnString += "</script>";

//            return returnString;
//        }

//        #region ReturnHtml

//        public string ToHtmlString()
//        {
//            return render();
//        }

//        public override string ToString()
//        {
//            return render();
//        }

//        #endregion
//    }




    public static class OpenStreetMapsHelperCustomer
    {
        /// <summary>
        ///     OpenStreetMaps helper
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static OpenStreetMapsCustomer OpenStreetMapsCustomer(this HtmlHelper helper)
        {
            return new OpenStreetMapsCustomer();
        }
    }

    public class OpenStreetMapsCustomer : IHtmlString
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
        ///     Poziom przybliżenia mapy
        /// </summary>
        private int zoomLevel = 15;

        public OpenStreetMapsCustomer Name(string name)
        {
            this.name = name;

            return this;
        }

        public OpenStreetMapsCustomer CenterLatitude(string centerLatitude)
        {
            this.centerLatitude = centerLatitude;
            this.centerLatitude = centerLatitude.Replace(',', '.');

            return this;
        }

        public OpenStreetMapsCustomer CenterLatitude(float centerLatitude)
        {
            this.centerLatitude = centerLatitude.ToString();
            this.centerLatitude = this.centerLatitude.Replace(',', '.');

            return this;
        }

        public OpenStreetMapsCustomer CenterLongtitude(string centerLongtitude)
        {
            this.centerLongtitude = centerLongtitude;
            this.centerLongtitude = centerLongtitude.Replace(',', '.');

            return this;
        }

        public OpenStreetMapsCustomer CenterLongtitude(float centerLongtitude)
        {
            this.centerLongtitude = centerLongtitude.ToString();
            this.centerLongtitude = this.centerLongtitude.Replace(',', '.');

            return this;
        }

        public OpenStreetMapsCustomer ZoomLevel(string zoomLevel)
        {
            zoomLevel = zoomLevel.Replace('.', ',');
            this.zoomLevel = int.Parse(zoomLevel);

            return this;
        }

        public OpenStreetMapsCustomer ZoomLevel(int zoomLevel)
        {
            this.zoomLevel = zoomLevel;

            return this;
        }

        public OpenStreetMapsCustomer MapHeight(string mapHeight)
        {
            this.mapHeight = int.Parse(mapHeight);

            return this;
        }

        public OpenStreetMapsCustomer MapHeight(int mapHeight)
        {
            this.mapHeight = mapHeight;

            return this;
        }

        public OpenStreetMapsCustomer MapWidth(string mapWidth)
        {
            this.mapWidth = int.Parse(mapWidth);

            return this;
        }

        public OpenStreetMapsCustomer MapWidth(int mapWidth)
        {
            this.mapWidth = mapWidth;

            return this;
        }

        public OpenStreetMapsCustomer MapEditableTrue(bool isEditable)
        {
            this.isEditable = isEditable;

            return this;
        }

        public OpenStreetMapsCustomer MouseScrollZoom(bool mouseScrollZoom)
        {
            this.mouseScrollZoom = mouseScrollZoom;

            return this;
        }

        public OpenStreetMapsCustomer MarkerIcon(string markerIcon)
        {
            this.markerIcon = markerIcon;
            return this;
        }

        public OpenStreetMapsCustomer PoiList(IList<POIModel> poiList)
        {
            this.poiList = poiList;
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

                             var greenIcon = new CustomIcon({iconUrl: 'http://oi62.tinypic.com/23licna.jpg'});


                             L.icon = function (options) {
                                    return new L.Icon(options);
                                };

var polygon = L.polygon([
    [32.509, -0.08],
    [41.503, -20.12]
]).addTo(map);



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