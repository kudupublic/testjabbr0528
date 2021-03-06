﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JabbR.Models
{
    public static class ModelExtensions
    {

        public static void EnsureAllowed(this ChatUser user, ChatRoom room)
        {
            if (room.Private && !room.IsUserAllowed(user))
            {
                throw new InvalidOperationException("You do not have access to " + room.Name);
            }
        }

        public static bool IsUserAllowed(this ChatRoom room, ChatUser user)
        {
            return room.AllowedUsers.Contains(user) || user.IsAdmin;
        }
    }
}