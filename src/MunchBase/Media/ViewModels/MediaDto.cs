namespace MunchBase.Media.ViewModels
{
    public class MediaDto
    {
        public virtual PhotoDto Photo { get; set; }
        public virtual VideoDto Video { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual string RejectionReason { get; set; }
        public virtual bool IsExplicit { get; set; }
        public virtual bool IsDraft { get; set; }
        public virtual string Caption { get; set; }
    }
}
