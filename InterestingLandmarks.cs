using ExileCore2;
using ExileCore2.PoEMemory.Components;
using ExileCore2.PoEMemory.MemoryObjects;
using ExileCore2.Shared.Enums;
using System.Drawing;
using Vector2 = System.Numerics.Vector2;

namespace InterestingLandmarks
{
    public class InterestingLandmarks : BaseSettingsPlugin<InterestingLandmarksSettings>
    {
        public override void Render()
        {
            try
            {
                if (!Settings.Enable
                || GameController.Area.CurrentArea == null
                || GameController.Area.CurrentArea.IsTown
                || GameController.Area.CurrentArea.IsHideout
                || GameController.IsLoading
                || !GameController.InGame
                || GameController.Game.IngameState.IngameUi.StashElement.IsVisibleLocal
                || !GameController.Game.IngameState.IngameUi.Map.LargeMap.IsVisible
            )
                {
                    return;
                }
                var allEntities = GameController.EntityListWrapper;

                // Chests
                if (Settings.ShowChests)
                {
                    foreach (var e in allEntities.ValidEntitiesByType[EntityType.Chest])
                    {
                        var chestComponent = e.GetComponent<Chest>();
                        if (!e.IsOpened && e.IsTargetable && chestComponent.IsLarge && !e.Path.Contains("Sanctum"))
                        {
                            var color = Color.White;
                            switch (e.Rarity)
                            {
                                case MonsterRarity.White:
                                    if (!Settings.ShowWhiteChests) continue;
                                    color = Settings.WhiteChestColor;
                                    break;
                                case MonsterRarity.Magic:
                                    if (!Settings.ShowMagicChests) continue;
                                    color = Settings.MagicChestColor;
                                    break;
                                case MonsterRarity.Rare:
                                    if (!Settings.ShowRareChests) continue;
                                    color = Settings.RareChestColor;
                                    break;
                                case MonsterRarity.Unique:
                                    if (!Settings.ShowUniqueChests) continue;
                                    color = Settings.UniqueChestColor;
                                    break;
                                default:
                                    if (!Settings.ShowOtherChests) continue;
                                    color = Settings.OtherChestColor;
                                    break;
                            }

                            Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), color, FontAlign.Center, Color.Black);
                        }
                    }
                }

                // Area transitions
                if (Settings.ShowTransitions)
                {
                    foreach (var e in allEntities.ValidEntitiesByType[EntityType.AreaTransition])
                    {
                        Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), Settings.TransitionsColor, FontAlign.Center, Color.Black);
                    }
                }

                // Minimap icons
                if (Settings.ShowPoI)
                {
                    foreach (var e in allEntities.ValidEntitiesByType[EntityType.IngameIcon])
                    {
                        {
                            Graphics.DrawTextWithBackground(e.GetComponent<MinimapIcon>().Name, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), Settings.PoIColor, FontAlign.Center, Color.Black);
                        }
                        if (e.Path.Contains ("ExpeditionMarker"))
                        {
                            break;
                        }
                    }
                }

                // Waypoints
                if (Settings.ShowWaypoints)
                {
                    foreach (var e in allEntities.ValidEntitiesByType[EntityType.Waypoint])
                    {
                        Graphics.DrawTextWithBackground(e.GetComponent<MinimapIcon>().Name, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), Settings.WaypointsColor, FontAlign.Center, Color.Black);
                    }
                }
				
		        // Secret Switches
                if (Settings.ShowSwitch)
                {
                    foreach (var e in allEntities.ValidEntitiesByType[EntityType.Terrain])
                    {
                        if (e.Path.Contains ("Switch"))
                        {
                            Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), Settings.SwitchColor, FontAlign.Center, Color.Black);
                        }
                    }
                }

                // Essences
                if (Settings.ShowEssence)
                {
                    foreach (var e in allEntities.ValidEntitiesByType[EntityType.Monolith])
                    {
                        if (!e.GetComponent<Monolith>().IsOpened)
                        {
                            Graphics.DrawTextWithBackground("Essence", GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), Settings.EssenceColor, FontAlign.Center, Color.Black);
                        }
                    }
                }
				
		        // Shrines
                if (Settings.ShowShrine)
                {
                    foreach (var e in allEntities.ValidEntitiesByType[EntityType.Shrine])
                    {
                        if (e.IsTargetable)
                        {
                            Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), Settings.ShrineColor, FontAlign.Center, Color.Black);
                        }
                    }
                }
            }
            catch { }
        }
    }
}
