using System;
using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApp.Models
{
    public class NotificationDataModel
    {
        public IEnumerable<Notification>? Notifications { get; set; }
        public int UnreadMessages { get; set; } = default!;
    }
}