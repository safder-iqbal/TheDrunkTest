﻿using System;
using System.Linq;

namespace DrunkCheck.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool OverrideEnabled
        {
            get { return OverrideUntil > DateTime.Now; }
        }

        public DateTime OverrideUntil { get; set; }

        public int SupervisorId { get; set; }

        public string Mobile { get; set; }

        public string CardCvc { get; set; }

        public string CardExpirationMonth { get; set; }

        public string CardExpirationYear { get; set; }

        public string CardNumber { get; set; }

        public string EmergancyContact { get; set; }

        public static User Get(int userId = -1, string email = null)
        {
            if (userId == -1 && email == null)
                throw new Exception("User id or email required.");

            using (DrunkCheckerContext db = new DrunkCheckerContext())
            {
                return userId != -1
                    ? db.Users.FirstOrDefault(u => u.Id == userId)
                    : db.Users.FirstOrDefault(u => u.Email == email);
            }
        }
    }
}