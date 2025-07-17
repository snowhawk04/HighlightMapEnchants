using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using Color = SharpDX.Color;

namespace HighlightMapEnchants;

public class HighlightMapEnchantsSettings : ISettings
{
    //Mandatory setting to allow enabling/disabling your plugin
    public ToggleNode Enable { get; set; } = new(false);

    public ToggleNode ShowBreachedMapEnchant { get; set; } = new(true);
    public ColorNode BreachedMapHighlightColor { get; set; } = new(Color.Purple);

    public ToggleNode ShowDemonAbyssEnchant { get; set; } = new(true);
    public ColorNode DemonAbyssHighlightColor { get; set; } = new(Color.Red);

    public ToggleNode ShowEssenceExilesEnchant { get; set; } = new(true);
    public ColorNode EssenceExilesHighlightColor { get; set; } = new(Color.Lavender);

    public ToggleNode ShowFlashBreachesEnchant { get; set; } = new(true);
    public ColorNode FlashBreachesHighlightColor { get; set; } = new(Color.MediumPurple);

    public ToggleNode ShowHarbingerPortalsEnchant { get; set; } = new(true);
    public ColorNode HarbingerPortalsHighlightColor { get; set; } = new(Color.LightSkyBlue);

    public ToggleNode ShowHarvestBeastsEnchant { get; set; } = new(true);
    public ColorNode HarvestBeastsHighlightColor { get; set; } = new(Color.Blue);

    public ToggleNode ShowHugeHarvestEnchant { get; set; } = new(true);
    public ColorNode HugeHarvestHighlightColor { get; set; } = new(Color.DarkBlue);

    public ToggleNode ShowPantheonShrinesEnchant { get; set; } = new(true);
    public ColorNode PantheonShrinesHighlightColor { get; set; } = new(Color.Yellow);

    public ToggleNode ShowPlayerIsHarbingerEnchant { get; set; } = new(true);
    public ColorNode PlayerIsHarbingerHighlightColor { get; set; } = new(Color.White);

    public ToggleNode ShowReverseIncursionEnchant { get; set; } = new(true);
    public ColorNode ReverseIncursionHighlightColor { get; set; } = new(Color.DeepPink);

    public ToggleNode ShowStrongboxChainEnchant { get; set; } = new(true);
    public ColorNode StrongboxChainHighlightColor { get; set; } = new(Color.LightYellow);

    public ToggleNode ShowTormentedMonstersEnchant { get; set; } = new(true);
    public ColorNode TormentedMonstersHighlightColor { get; set; } = new(Color.Green);
}