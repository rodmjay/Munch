#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Users.Interfaces;

namespace MunchBase.Users.ViewModels
{
    public class UserDto : IUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsEditor { get; set; }
        public bool IsModel { get; set; }
        public bool IsProducer { get; set; }
        public bool IsConsumer { get; set; }
    }
}