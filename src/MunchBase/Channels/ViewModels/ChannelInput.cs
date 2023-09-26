namespace MunchBase.Channels.ViewModels;

public class ChannelInput
{
    public string Name { get; set; }
    public ChannelProviderInput[] Providers { get; set; }
    public int[] Producers { get; set; }
}