using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;
using System.Drawing;

namespace InterestingLandmarks
{
    public class InterestingLandmarksSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(false);

        [Menu("Show Chests")]
        public ToggleNode ShowChests { get; set; } = new ToggleNode(true);

        [Menu("Chests", 100, CollapsedByDefault = true)]
        public EmptyNode SettingsEmptyChest { get; set; }

        [Menu("White Chests", parentIndex = 100)]
        public ToggleNode ShowWhiteChests { get; set; } = new ToggleNode(true);
        [Menu("Magic Chests", parentIndex = 100)]
        public ToggleNode ShowMagicChests { get; set; } = new ToggleNode(true);
        [Menu("Rare Chests", parentIndex = 100)]
        public ToggleNode ShowRareChests { get; set; } = new ToggleNode(true);
        [Menu("Unique Chests", parentIndex = 100)]
        public ToggleNode ShowUniqueChests { get; set; } = new ToggleNode(true);
        [Menu("Other (?) Chests", parentIndex = 100)]
        public ToggleNode ShowOtherChests { get; set; } = new ToggleNode(true);

        [Menu("White Chest color", parentIndex = 100)]
        public ColorNode WhiteChestColor { get; set; } = new ColorNode(Color.White);
        [Menu("Magic Chest color", parentIndex = 100)]
        public ColorNode MagicChestColor { get; set; } = new ColorNode(Color.Blue);
        [Menu("Rare Chest Color", parentIndex = 100)]
        public ColorNode RareChestColor { get; set; } = new ColorNode(Color.Yellow);
        [Menu("Unique Chest Color", parentIndex = 100)]
        public ColorNode UniqueChestColor { get; set; } = new ColorNode(Color.Orange);
        [Menu("Other Chest Color", parentIndex = 100)]
        public ColorNode OtherChestColor { get; set; } = new ColorNode(Color.Gray);

        [Menu("Show Area Transitions")]
        public ToggleNode ShowTransitions { get; set; } = new ToggleNode(true);
        [Menu("Show Waypoints")]
        public ToggleNode ShowWaypoints { get; set; } = new ToggleNode(true);
        [Menu("Show Points of Interest (Minimap Icons)")]
        public ToggleNode ShowPoI { get; set; } = new ToggleNode(true);
        [Menu("Show Essences")]
        public ToggleNode ShowEssence { get; set; } = new ToggleNode(true);
	    [Menu("Show Switches")]
        public ToggleNode ShowSwitch { get; set; } = new ToggleNode(true);
        [Menu("Show Breaches")]
        public ToggleNode ShowBreach { get; set; } = new ToggleNode(true);


        [Menu("Area Transition Color")]
        public ColorNode TransitionsColor { get; set; } = new ColorNode(Color.White);
        [Menu("Waypoint Color")]
        public ColorNode WaypointsColor { get; set; } = new ColorNode(Color.LightBlue);
        [Menu("Point of Interest Color")]
        public ColorNode PoIColor { get; set; } = new ColorNode(Color.LightGreen);
        [Menu("Essence Color")]
        public ColorNode EssenceColor { get; set; } = new ColorNode(Color.Pink);
        [Menu("Switch Color")]
        public ColorNode SwitchColor { get; set; } = new ColorNode(Color.Red);
        [Menu("Breach Color")]
        public ColorNode BreachColor { get; set; } = new ColorNode(Color.Purple);
    }
}
