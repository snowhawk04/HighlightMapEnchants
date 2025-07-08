using ExileCore;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.MemoryObjects;
using SharpDX;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vector2 = System.Numerics.Vector2;

namespace HighlightMapEnchants;

public class HighlightMapEnchants : BaseSettingsPlugin<HighlightMapEnchantsSettings>
{
    private readonly string Einhar = "contain Einhar";
    private readonly string Harvest = "contain The Sacred Grove";
    private readonly string Essence = "contain additional Essences";

    public override bool Initialise()
    {
        return true;
    }

    public override void AreaChange(AreaInstance area)
    {
        //Perform once-per-zone processing here
        //For example, Radar builds the zone map texture here
    }

    public override Job Tick()
    {

        return null;
    }

    public override void Render()
    {
        var kiracMissionPanel = GameController.IngameState.IngameUi.ZanaMissionChoice;
        var kiracInv = GameController.IngameState.Data.ServerData.NPCInventories.FirstOrDefault();
        if (kiracMissionPanel != null && kiracMissionPanel.IsValid == true && kiracMissionPanel.IsVisible)
        {
            var avMaps = kiracInv.Inventory.InventorySlotItems;
            foreach ( var av in avMaps )
            {
                if ( av != null && av.Item.GetComponent<Mods>() != null && av.Item.GetComponent<Mods>().EnchantedMods.Count > 0)
                {
                    var enchMods = av.Item.GetComponent<Mods>().EnchantedMods;
                    foreach ( var ench in enchMods )
                    {
                        if ( Settings.ShowBeastEnchant == true && ench.Translation.Contains(Einhar, System.StringComparison.OrdinalIgnoreCase) )
                        {
                            Color color = Settings.BeastHighlightColor;
                            var cell = kiracMissionPanel.GetChildAtIndex(0).GetChildAtIndex(3).GetChildAtIndex(av.PosX);
                            var rect = cell.GetClientRect();
                            
                            var boxPoints = new List<Vector2>();
                            boxPoints.Add(new Vector2(rect.BottomLeft.X, rect.BottomLeft.Y));
                            boxPoints.Add(new Vector2(rect.BottomRight.X , rect.BottomRight.Y ));
                            boxPoints.Add(new Vector2(rect.TopRight.X , rect.TopRight.Y ));
                            boxPoints.Add(new Vector2(rect.TopLeft.X , rect.TopLeft.Y ));
                            boxPoints.Add(new Vector2(rect.BottomLeft.X , rect.BottomLeft.Y ));
                            Graphics.DrawPolyLine(boxPoints.ToArray(), color, 2);
                            Graphics.DrawConvexPolyFilled(boxPoints.ToArray(),
                                color with { A = Color.ToByte((int)((double)0.2f * byte.MaxValue)) });
                        }
                        else if (Settings.ShowHarvestEnchant == true && ench.Translation.Contains(Harvest, System.StringComparison.OrdinalIgnoreCase))
                        {
                            Color color = Settings.HarvestHighlightColor;
                            var cell = kiracMissionPanel.GetChildAtIndex(0).GetChildAtIndex(3).GetChildAtIndex(av.PosX);
                            var rect = cell.GetClientRect();

                            var boxPoints = new List<Vector2>();
                            boxPoints.Add(new Vector2(rect.BottomLeft.X, rect.BottomLeft.Y));
                            boxPoints.Add(new Vector2(rect.BottomRight.X, rect.BottomRight.Y));
                            boxPoints.Add(new Vector2(rect.TopRight.X, rect.TopRight.Y));
                            boxPoints.Add(new Vector2(rect.TopLeft.X, rect.TopLeft.Y));
                            boxPoints.Add(new Vector2(rect.BottomLeft.X, rect.BottomLeft.Y));
                            Graphics.DrawPolyLine(boxPoints.ToArray(), color, 2);
                            Graphics.DrawConvexPolyFilled(boxPoints.ToArray(),
                                color with { A = Color.ToByte((int)((double)0.2f * byte.MaxValue)) });
                        }
                        else if (Settings.ShowCrystalPrisonEnchant == true && ench.Translation.Contains(Essence, System.StringComparison.OrdinalIgnoreCase))
                        {
                            Color color = Settings.EssenceHighlightColor;
                            var cell = kiracMissionPanel.GetChildAtIndex(0).GetChildAtIndex(3).GetChildAtIndex(av.PosX);
                            var rect = cell.GetClientRect();

                            var boxPoints = new List<Vector2>();
                            boxPoints.Add(new Vector2(rect.BottomLeft.X, rect.BottomLeft.Y));
                            boxPoints.Add(new Vector2(rect.BottomRight.X, rect.BottomRight.Y));
                            boxPoints.Add(new Vector2(rect.TopRight.X, rect.TopRight.Y));
                            boxPoints.Add(new Vector2(rect.TopLeft.X, rect.TopLeft.Y));
                            boxPoints.Add(new Vector2(rect.BottomLeft.X, rect.BottomLeft.Y));
                            Graphics.DrawPolyLine(boxPoints.ToArray(), color, 2);
                            Graphics.DrawConvexPolyFilled(boxPoints.ToArray(),
                                color with { A = Color.ToByte((int)((double)0.2f * byte.MaxValue)) });
                        }
                    }
                }
            }
        }
        return;
    }

    public override void EntityAdded(Entity entity)
    {
        //If you have a reason to process every entity only once,
        //this is a good place to do so.
        //You may want to use a queue and run the actual
        //processing (if any) inside the Tick method.
    }
}