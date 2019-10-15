using Newtonsoft.Json;
using orkut2x.model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace orkut2x.service
{
    class DataExchanger : WebClient
    {
        private string baseEndpoint = "http://10.0.3.2:3000";
        public int Timeout { get; set; }


        public DataExchanger() {

            this.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
        }

        protected override WebRequest GetWebRequest(Uri address) {
            var request = base.GetWebRequest(address);
            request.Timeout = 5000;
            return request;
        }

        public User[] getUsers() {
            string response = DownloadString(baseEndpoint + "/users");
            return JsonConvert.DeserializeObject<User[]>(response);
        }

        private Response sendPost(string endpoint, object payload) {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            Console.WriteLine(jsonPayload);
            string responseString = UploadString(baseEndpoint + endpoint, "POST", jsonPayload);
            return JsonConvert.DeserializeObject<Response>(responseString);
        }

        public bool getUser(string uuid) {
            try {
                string response = DownloadString(baseEndpoint + "/user?uuid=" + uuid);
                AuthProvider.User = JsonConvert.DeserializeObject<User>(response);
                return true;
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool sharePost(string postUuid) {
            try {
                var payload = new { uuid = postUuid, userUuid = AuthProvider.Uuid, user = AuthProvider.Username };
                Response response = sendPost("/shared", payload);
                if (response.result.Equals("ok")) {
                    return true;
                }
                return false;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        public Post[] getPosts() {
            try {
                string response = DownloadString(baseEndpoint + "/posts?userUuid=" + AuthProvider.Uuid);
                return JsonConvert.DeserializeObject<Post[]>(response);
            } catch (Exception e) {
                return new List<Post>().ToArray();
            }
        }

        public User[] getFriends(string uuid) {
            try {
                string response = DownloadString(baseEndpoint + "/friends?uuid=" + uuid);
                return JsonConvert.DeserializeObject<User[]>(response);
            } catch (Exception e) {
                return new List<User>().ToArray();
            }

        }

        public bool publishPost(Post post) {
            try {
                Response response = sendPost("/post", post);
                if (response.result.Equals("ok")) {
                    return true;
                }
                return false;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
            
        }

        public bool removeFriend(string uuid, string friendUuid) {
            try {
                var payload = new { user = uuid, friend = friendUuid };
                Response response = sendPost("/disaffection", payload);
                return true;
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool signInUser(string userValue, string passwordValue) {
            try {
                var payload = new { user = userValue, password = passwordValue };
                Response response = sendPost("/signin", payload);

                if (response.result.Equals("ok")) {
                    AuthProvider.Token = response.uuid; //currently using the uuid as token
                }
                return true;
            } catch (Exception e) {
                return false;
            } 
        }

        public bool addFriend(string currentUser, string friendUuid) {
            try {
                var payload = new { user = currentUser, friend= friendUuid };
                Response response = sendPost("/friendship", payload);
                return true;
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool signUpNewUser(string userValue, string passwordValue, string profilePic) {
            try {
                var payload = new { user = userValue, password = passwordValue, pic = profilePic };
                Response response = sendPost("/signup", payload);

                if (response.result.Equals("error")) {
                    return false;
                }
                return true;
            } catch(Exception e) {
                return false;
            }
        }

        
    }
}
