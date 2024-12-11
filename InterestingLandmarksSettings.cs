using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;
using System.Drawing;

namespace InterestingLandmarks
{
    public class InterestingLandmarksSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(false);

        [Menu("Show chests")]
        public ToggleNode ShowChests { get; set; } = new ToggleNode(true);

        [Menu("Chests", 100, CollapsedByDefault = true)]
        public EmptyNode SettingsEmptyChest { get; set; }

        [Menu("White chests", parentIndex = 100)]
        public ToggleNode ShowWhiteChests { get; set; } = new ToggleNode(true);
        [Menu("White chest color", parentIndex = 100)]
        public ColorNode WhiteChestColor { get; set; } = new ColorNode(Color.White);

        [Menu("Magic chests", parentIndex = 100)]
        public ToggleNode ShowMagicChests { get; set; } = new ToggleNode(true);
        [Menu("Magic chest color", parentIndex = 100)]
        public ColorNode MagicChestColor { get; set; } = new ColorNode(Color.Blue);

        [Menu("Rare chests", parentIndex = 100)]
        public ToggleNode ShowRareChests { get; set; } = new ToggleNode(true);
        [Menu("Rare chest color", parentIndex = 100)]
        public ColorNode RareChestColor { get; set; } = new ColorNode(Color.Yellow);

        [Menu("Unique chests", parentIndex = 100)]
        public ToggleNode ShowUniqueChests { get; set; } = new ToggleNode(true);
        [Menu("Unique chest color", parentIndex = 100)]
        public ColorNode UniqueChestColor { get; set; } = new ColorNode(Color.Orange);

        [Menu("Other (?) chests", parentIndex = 100)]
        public ToggleNode ShowOtherChests { get; set; } = new ToggleNode(true);
        [Menu("Other chest color", parentIndex = 100)]
        public ColorNode OtherChestColor { get; set; } = new ColorNode(Color.Gray);

        [Menu("Show area transitions")]
        public ToggleNode ShowTransitions { get; set; } = new ToggleNode(true);
        [Menu("Area transition color")]
        public ColorNode TransitionsColor { get; set; } = new ColorNode(Color.White);

        [Menu("Show waypoints")]
        public ToggleNode ShowWaypoints { get; set; } = new ToggleNode(true);
        [Menu("Waypoint color")]
        public ColorNode WaypointsColor { get; set; } = new ColorNode(Color.LightBlue);

        [Menu("Show points of interest (minimap icons)")]
        public ToggleNode ShowPoI { get; set; } = new ToggleNode(true);
        [Menu("Point of interest color")]
        public ColorNode PoIColor { get; set; } = new ColorNode(Color.LightGreen);

        [Menu("Show essences")]
        public ToggleNode ShowEssence { get; set; } = new ToggleNode(true);
        [Menu("Essence transition color")]
        public ColorNode EssenceColor { get; set; } = new ColorNode(Color.Purple);
    }
}