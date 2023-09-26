namespace MunchBase.Models.ViewModels;

public class ModelInput
{
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public ModelProviderInput[] Providers { get; set; }
}