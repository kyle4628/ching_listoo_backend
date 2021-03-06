﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace prjToolist.Models
{
    public class tUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int authority { get; set; }
        public Nullable<System.DateTime> updated { get; set; }
        public Nullable<System.DateTime> created { get; set; }
    }

    // for auth/login
    public class memberLogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    // for auth/register
    public class createMember
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

   

    public class updateMember
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int authority { get; set; }
        public string createdTime { get; set; }
        public string updatedTime { get; set; }
    }
    
    public class queryUserList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int authority { get; set; }
        public string createdTime { get; set; }
        public string updatedTime { get; set; }
    }

    public static class userFactory
    {
        public static int userIsLoginSession(int userlogin)
        {
            if (HttpContext.Current.Session["SK_login"] != null)
            {
                user u = HttpContext.Current.Session["SK_login"] as user;
                userlogin = u.id;
            };
            return userlogin;
        }
        public static void userEventRecord( int userlogin,  int userEventNum, FUENMLEntities db)
        {
            try {
                if (userEventNum == 1 || userEventNum == 2 || userEventNum == 3) {
                    if (userlogin == 0) { userlogin = 2; }
                    userEvent userEventobj = new userEvent();
                    userEventobj.user_id = userlogin;
                    userEventobj.userEvent1 = userEventNum;
                    userEventobj.created = DateTime.Now;
                    db.userEvents.Add(userEventobj);
                    db.SaveChanges(); }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }

}