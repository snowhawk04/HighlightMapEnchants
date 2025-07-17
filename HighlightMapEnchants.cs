using ExileCore;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.MemoryObjects;
using SharpDX;
using System.Collections.Generic;
using System.Linq;
using Vector2 = System.Numerics.Vector2;

namespace HighlightMapEnchants;

public class EnchantSettings
{
    public string Name { get; set; }
    public Color Color { get; set; }
}

public class HighlightMapEnchants : BaseSettingsPlugin<HighlightMapEnchantsSettings>
{
    private List<EnchantSettings> GetSettings()
    {
        if (Settings == null || !Settings.Enable)
            return [];

        var result = new List<EnchantSettings>();

        if (Settings.ShowBreachedMapEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayBreachedMap", Color = Settings.BreachedMapHighlightColor });
        }

        if (Settings.ShowDemonAbyssEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayDemonAbyss", Color = Settings.DemonAbyssHighlightColor });
        }

        if (Settings.ShowEssenceExilesEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayEssenceExiles", Color = Settings.EssenceExilesHighlightColor });
        }

        if (Settings.ShowFlashBreachesEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayFlashBreaches", Color = Settings.FlashBreachesHighlightColor });
        }

        if (Settings.ShowHarbingerPortalsEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayHarbingerPortals", Color = Settings.HarbingerPortalsHighlightColor });
        }

        if (Settings.ShowHarvestBeastsEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayHarvestBeasts", Color = Settings.HarvestBeastsHighlightColor });
        }

        if (Settings.ShowHugeHarvestEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayHugeHarvest", Color = Settings.HugeHarvestHighlightColor });
        }

        if (Settings.ShowPantheonShrinesEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayPantheonShrines", Color = Settings.PantheonShrinesHighlightColor });
        }

        if (Settings.ShowPlayerIsHarbingerEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayPlayerIsHarbinger", Color = Settings.PlayerIsHarbingerHighlightColor });
        }

        if (Settings.ShowReverseIncursionEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayReverseIncursion", Color = Settings.ReverseIncursionHighlightColor });
        }

        if (Settings.ShowStrongboxChainEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayStrongboxChain", Color = Settings.StrongboxChainHighlightColor });
        }

        if (Settings.ShowTormentedMonstersEnchant)
        {
            result.Add(new EnchantSettings { Name = "MapMissionDisplayTormentedMonsters", Color = Settings.TormentedMonstersHighlightColor });
        }
        
        return result;
    }

    public override bool Initialise()
    {
        return true;
    }

    public override void AreaChange(AreaInstance area)
    {
    }

    public override Job Tick()
    {

        return null;
    }

    public override void Render()
    {
        var missionPanel = GameController.IngameState.IngameUi.ZanaMissionChoice;
        var npcInventoryPanel = GameController.IngameState.Data.ServerData.NPCInventories.FirstOrDefault();
        
        if (missionPanel is not { IsValid: true, IsVisible: true } || npcInventoryPanel == null) return;

        var inventoryItems = npcInventoryPanel.Inventory.InventorySlotItems.Where(slot => slot != null && slot.Item.HasComponent<Mods>() && slot.Item.GetComponent<Mods>().EnchantedMods.Count > 0);

        foreach ( var inventoryItem in inventoryItems )
        {
            var enchantedMods = inventoryItem.Item.GetComponent<Mods>().EnchantedMods;
            foreach ( var enchantedMod in enchantedMods )
            {
                var enchantSettings = GetSettings().FirstOrDefault(x => enchantedMod.RawName.Equals(x.Name, System.StringComparison.OrdinalIgnoreCase));

                if (enchantSettings == null)
                    continue;

                var color = enchantSettings.Color;
                var cell = missionPanel.GetChildAtIndex(0).GetChildAtIndex(3).GetChildAtIndex(inventoryItem.PosX);
                var rect = cell.GetClientRect();
                var boxPoints = new List<Vector2>
                {
                    new(rect.BottomLeft.X, rect.BottomLeft.Y),
                    new(rect.BottomRight.X, rect.BottomRight.Y),
                    new(rect.TopRight.X , rect.TopRight.Y ),
                    new(rect.TopLeft.X , rect.TopLeft.Y ),
                    new(rect.BottomLeft.X , rect.BottomLeft.Y )
                };
                Graphics.DrawPolyLine(boxPoints.ToArray(), color, 2);
                Graphics.DrawConvexPolyFilled(boxPoints.ToArray(), color with { A = Color.ToByte((int)((double)0.2f * byte.MaxValue)) });
                break;
            }
        }
    }

    public override void EntityAdded(Entity entity)
    {
        //If you have a reason to process every entity only once,
        //this is a good place to do so.
        //You may want to use a queue and run the actual
        //processing (if any) inside the Tick method.
    }
}