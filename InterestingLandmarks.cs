using ExileCore2;
using ExileCore2.PoEMemory.Components;
using ExileCore2.PoEMemory.MemoryObjects;
using ExileCore2.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using Vector2 = System.Numerics.Vector2;

namespace InterestingLandmarks
{
    public class InterestingLandmarks : BaseSettingsPlugin<InterestingLandmarksSettings>
    {
        public override void AreaChange(AreaInstance area)
        {
            base.AreaChange(area);
        }

        public override void Render()
        {
            try
            {
                if (!Settings.Enable || GameController.Area.CurrentArea == null || GameController.Area.CurrentArea.IsTown
                    || GameController.Area.CurrentArea.IsHideout || GameController.IsLoading || !GameController.InGame
                    || GameController.Game.IngameState.IngameUi.StashElement.IsVisibleLocal
                    || !GameController.Game.IngameState.IngameUi.Map.LargeMap.IsVisible)
                {
                    return;
                }

                var allEntities = GameController.EntityListWrapper;
                // Render entities based on type and settings using helpers
                RenderEntities(allEntities, Settings.ShowChests, EntityType.Chest, RenderChest);
                RenderEntities(allEntities, Settings.ShowWisps, EntityType.Monster, RenderWisps);
                RenderEntities(allEntities, Settings.ShowStrongboxs, EntityType.Chest, RenderStrongbox);
                RenderEntities(allEntities, Settings.ShowTransitions, EntityType.AreaTransition, RenderTransition);
                RenderEntities(allEntities, Settings.ShowPoI, EntityType.IngameIcon, RenderPoI);
                RenderEntities(allEntities, Settings.ShowWaypoints, EntityType.Waypoint, RenderWaypoint);
                RenderEntities(allEntities, Settings.ShowSwitch, EntityType.Terrain, RenderSwitch);
                RenderEntities(allEntities, Settings.ShowEssence, EntityType.Monolith, RenderEssence);
                RenderEntities(allEntities, Settings.ShowShrine, EntityType.Shrine, RenderShrine);
                RenderEntities(allEntities, Settings.ShowBreach, EntityType.Breach, RenderBreach);
                RenderEntities(allEntities, Settings.ShowRituals, EntityType.Terrain, RenderRitual);
                RenderEntities(allEntities, Settings.ShowDeliSpawns, EntityType.Monster, RenderDeliSpawns);
            }
            catch { }
        }

        private void RenderEntities(EntityListWrapper allEntities, bool show, EntityType type, Action<Entity, InterestingLandmarksSettings> renderAction)
        {
            if (show)
            {
                foreach (var entity in allEntities.ValidEntitiesByType[type])
                {
                    renderAction(entity, Settings);
                }
            }
        }

        private void RenderChest(Entity e, InterestingLandmarksSettings settings)
        {
            var chestComponent = e.GetComponent<Chest>();
            if (!e.IsOpened && e.IsTargetable && chestComponent.IsLarge && !e.Path.Contains("Sanctum"))
            {
                var color = GetChestColor(e.Rarity, settings);
                if (color.HasValue)
                {
                    Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), color.Value, FontAlign.Center, Color.Black);
                }
            }
        }        
        private void RenderStrongbox(Entity e, InterestingLandmarksSettings settings)
        {
            var chestComponent = e.GetComponent<Chest>();
            if (!e.IsOpened && e.IsTargetable && e.Path.Contains("Strongbox") && !e.Path.Contains("Sanctum"))
            {
                var color = GetStrongboxColor(e.Rarity, settings);
                if (color.HasValue)
                {
                    Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), color.Value, FontAlign.Center, Color.Black);
                }
            }
        }
		
		// Chests code updated, put this here to remind that may need reverted if errors
        private Color? GetChestColor(MonsterRarity rarity, InterestingLandmarksSettings settings)
        {
            return rarity switch
            {
                MonsterRarity.White => settings.ShowWhiteChests ? settings.WhiteChestColor : (Color?)null,
                MonsterRarity.Magic => settings.ShowMagicChests ? settings.MagicChestColor : (Color?)null,
                MonsterRarity.Rare => settings.ShowRareChests ? settings.RareChestColor : (Color?)null,
                MonsterRarity.Unique => settings.ShowUniqueChests ? settings.UniqueChestColor : (Color?)null,
                _ => settings.ShowOtherChests ? settings.OtherChestColor : (Color?)null,
            };
        }        
        private Color? GetStrongboxColor(MonsterRarity rarity, InterestingLandmarksSettings settings)
        {
            return rarity switch
            {
                MonsterRarity.White => settings.ShowWhiteStrongboxs ? settings.WhiteStrongboxColor : (Color?)null,
                MonsterRarity.Magic => settings.ShowMagicStrongboxs ? settings.MagicStrongboxColor : (Color?)null,
                MonsterRarity.Rare => settings.ShowRareStrongboxs ? settings.RareStrongboxColor : (Color?)null,
                MonsterRarity.Unique => settings.ShowUniqueStrongboxs ? settings.UniqueStrongboxColor : (Color?)null,
                _ => settings.ShowOtherStrongboxs ? settings.OtherStrongboxColor : (Color?)null,
            };
        }

        private void RenderTransition(Entity e, InterestingLandmarksSettings settings)
        {
            Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.TransitionsColor, FontAlign.Center, Color.Black);
        }

        private void RenderPoI(Entity e, InterestingLandmarksSettings settings)
        {
            if (!e.Path.Contains("Expedition") && !e.Path.Contains("Ritual"))
            {
                Graphics.DrawTextWithBackground(e.GetComponent<MinimapIcon>().Name, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.PoIColor, FontAlign.Center, Color.Black);
            }
        }

        private void RenderWaypoint(Entity e, InterestingLandmarksSettings settings)
        {
            Graphics.DrawTextWithBackground(e.GetComponent<MinimapIcon>().Name, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.WaypointsColor, FontAlign.Center, Color.Black);
        }

        private void RenderSwitch(Entity e, InterestingLandmarksSettings settings)
        {
            if (e.Path.Contains("Switch"))
            {
                Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.SwitchColor, FontAlign.Center, Color.Black);
            }
        }

        private void RenderEssence(Entity e, InterestingLandmarksSettings settings)
        {
            if (!e.GetComponent<Monolith>().IsOpened)
            {
                Graphics.DrawTextWithBackground("Essence", GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.EssenceColor, FontAlign.Center, Color.Black);
            }
        }

        private void RenderShrine(Entity e, InterestingLandmarksSettings settings)
        {
            if (e.IsTargetable)
            {
                Graphics.DrawTextWithBackground(e.RenderName, GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.ShrineColor, FontAlign.Center, Color.Black);
            }
        }

        private void RenderBreach(Entity e, InterestingLandmarksSettings settings)
        {
            Graphics.DrawTextWithBackground("Breach", GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.BreachColor, Color.Black);
        }
		
		// Added RitualRune which shows up in maps but may not work during campaign
        private void RenderRitual(Entity e, InterestingLandmarksSettings settings)
        {
            if (e.Path.Contains("RitualRune"))
            {
                Graphics.DrawTextWithBackground("Ritual", GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.RitualColor, FontAlign.Center, Color.Black);
            }
        }		// Added RitualRune which shows up in maps but may not work during campaign
		
        private void RenderDeliSpawns(Entity e, InterestingLandmarksSettings settings)
        {
            if (e.Path.Contains("DoodadDaemonShardPack"))
            {
                Graphics.DrawTextWithBackground("Deli", GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.DeliSpawnColor, FontAlign.Center, Color.Black);
            }
        }        
        private void RenderWisps(Entity e, InterestingLandmarksSettings settings)
        {
            if (e.Path.Contains("Metadata/Monsters/TormentedSpirits/TormentedSpirit"))
            {
                Graphics.DrawTextWithBackground("Wisp", GameController.IngameState.Data.GetGridMapScreenPosition(e.GridPos), settings.WispsColor, FontAlign.Center, Color.Black);
            }
        }
    }
}
