using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LandmarkViewer.Models;
using LandmarkViewer.ViewModels;

namespace LandmarkViewer.Services
{
    public class LandmarkGenerator
    {
        public async Task<IEnumerable<LandmarkImage>> GetLandmarkDataByLocationAsync(LocationViewModel location)
        {
            var httpClient = new HttpClient();
            var LandmarkImage = new List<LandmarkImage>();
            // use this link to get an api_key : https://www.flickr.com/services/apps/create/noncommercial/?
            // use this website to get the user_id : http://idgettr.com/

            var json = await httpClient.GetStringAsync(
                "https://api.flickr.com/services/rest/?&method=flickr.photos.search&api_key="
                + "3af3dd185652c4f461785ef5031e8254"
                + "&text=" + location.Location + " landmarks&format=json&per_page=30&extras=description,date_upload,owner_name,tags,machine_tags,views,media,path_alias,url_sq,url_m,url_o");

            json = json.Replace("jsonFlickrApi(", "").Replace(")", "");

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var photos = response.Value<JObject>("photos").Value<JArray>("photo");

                var landmarkImages = new List<LandmarkImage>();

                foreach (var photo in photos)
                {
                    var img = new LandmarkImage()
                    {
                        PathAlias = photo.Value<string>("pathalias"),
                        Title = photo.Value<string>("title"),
                        Published = photo.Value<string>("dateupload"),
                        Views = photo.Value<int>("views"),
                        Description = photo.Value<JObject>("description").Value<string>("_content"),
                        MediumImageUrl = photo.Value<string>("url_m")
                    };

                    img.Owner = GetImageOwner(photo);
                    landmarkImages.Add(img);
                }

                LandmarkImage = landmarkImages;

            }
            catch (Exception exception)
            {
            }

            return LandmarkImage;
        }

        public async Task<IEnumerable<LandmarkImage>> GetLandmarkDataByLatLonAsync(LocationViewModel location)
        {
            var httpClient = new HttpClient();
            var LandmarkImage = new List<LandmarkImage>();
            // use this link to get an api_key : https://www.flickr.com/services/apps/create/noncommercial/?
            // use this website to get the user_id : http://idgettr.com/

            var json = await httpClient.GetStringAsync(
                "https://api.flickr.com/services/rest/?&method=flickr.photos.search&api_key="
                + "3af3dd185652c4f461785ef5031e8254"
                + "&text=landmarks&lat="+location.Latitude+"&lon="+location.Logitude+"&format=json&per_page=30&extras=description,date_upload,owner_name,tags,machine_tags,views,media,path_alias,url_sq,url_m,url_o");

            json = json.Replace("jsonFlickrApi(", "").Replace(")", "");

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var photos = response.Value<JObject>("photos").Value<JArray>("photo");

                var landmarkImages = new List<LandmarkImage>();

                foreach (var photo in photos)
                {
                    var img = new LandmarkImage()
                    {
                        PathAlias = photo.Value<string>("pathalias"),
                        Title = photo.Value<string>("title"),
                        Published = photo.Value<string>("dateupload"),
                        Views = photo.Value<int>("views"),
                        Description = photo.Value<JObject>("description").Value<string>("_content"),
                        MediumImageUrl = photo.Value<string>("url_m")
                    };

                    img.Owner = GetImageOwner(photo);
                    landmarkImages.Add(img);
                }

                LandmarkImage = landmarkImages;

            }
            catch (Exception exception)
            {
            }

            return LandmarkImage;
        }


        private ImageOwner GetImageOwner(JToken photo)
        {
            var owner = new ImageOwner()
            {
                OwnerName = photo.Value<string>("ownername"),
                OwnerImageUrl = "http://c1.staticflickr.com/"
                                      + photo.Value<string>("farm")
                                      + "/"
                                      + photo.Value<string>("server")
                                      + "/buddyicons/"
                                      + photo.Value<string>("owner")
                                      + "_l.jpg"
            };

            return owner;
        }
    }
}