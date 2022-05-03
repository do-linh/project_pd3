using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MotelManager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "post_id",
                url: "Post/SavePost",
                defaults: new { controller = "Post", action = "SavePost" }
            );
            //routes.MapRoute(
            //    name: "createPost",
            //    url: "user/verified",
            //    defaults: new { controller = "Sms", action = "Verification" }
            //);
            //routes.MapRoute(
            //    name: "removeFavorite",
            //    url: "Post/RemovePostSave",
            //    defaults: new { controller = "Post", action = "RemovePostSave" }
            //);
            routes.MapRoute(
                name: "createPost",
                url: "Post/CreatePost",
                defaults: new { controller = "Post", action = "CreatePost" }
            );
            routes.MapRoute(
                name: "report",
                url: "Post/Report",
                defaults: new { controller = "Post", action = "Report" }
            );
            routes.MapRoute(
                name: "slug",
                url: "Post/{*slug}",
                defaults: new { controller = "Post", action = "Detail" }
            );
            routes.MapRoute(
               name: "listpost",
               url: "user/{username}/list",
               defaults: new { controller = "UserManager", action = "ListPostUser" }
           );
            routes.MapRoute(
                name: "savedPost",
                url: "user/{username}/savedpost",
                defaults: new { controller = "UserManager", action = "SavedPost" }
            );
            //routes.MapRoute(
            //    name: "createPost",
            //    url: "user/{username}/createpost",
            //    defaults: new { controller = "UserManager", action = "CreatePost" }
            //);
            routes.MapRoute(
                name: "changepassword",
                url: "user/changepassword",
                defaults: new { controller = "UserManager", action = "ChangePassword" }
            );
            routes.MapRoute(
                name: "user",
                url: "user/{*username}",
                defaults: new { controller = "UserManager", action = "EditProfile" }
            );
            routes.MapRoute(
                name: "home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
