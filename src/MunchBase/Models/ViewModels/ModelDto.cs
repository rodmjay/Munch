using System;
using MunchBase.Models.Interfaces;

namespace MunchBase.Models.ViewModels
{
    public class ModelDto : IModel
    {
        public bool Active { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int MediaSetCount { get; set; }
        public DateTime MemberSince { get; set; }
        public virtual string TwitterUsername { get; set; }
        public virtual string InstagramUsername { get; set; }
        public virtual string SnapChatUsername { get; set; }
        public virtual string OnlyFansUsername { get; set; }
        public int Id { get; set; }
    }
}
