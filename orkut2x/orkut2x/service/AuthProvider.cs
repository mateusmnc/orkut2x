using orkut2x.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace orkut2x.service
{
    class AuthProvider
    {
        public static string Token { get; set; }
        public static string Uuid { get { return User.uuid; } internal set { } }
        public static string Pic { get { return User.pic; } internal set { } }
        public static string Username { get { return User.user; } internal set { } }
        public static User User { get; set; }
    }
}
