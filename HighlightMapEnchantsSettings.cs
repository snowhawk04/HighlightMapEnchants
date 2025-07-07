using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace HighlightMapEnchants;

public class HighlightMapEnchantsSettings : ISettings
{
    //Mandatory setting to allow enabling/disabling your plugin
    public ToggleNode Enable { get; set; } = new ToggleNode(false);

    public ToggleNode ShowBeastEnchant { get; set; } = new(true);
    public ToggleNode ShowHarvestEnchant { get; set; } = new(true);
}