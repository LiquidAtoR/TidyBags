/*
 * Tidy Bags v3.6.1.8 by LiquidAtoR
 *
 * This is a trivial little addon that will tidy up on-use items like Clams and
 * Borean Leather Scraps. It uses a stopwatch to stop it spamming Pulse() and
 * only runs when out of combat. Originally Created by Ryns.
 *
 * Credits to Ryns, MaiN, erenion, TIA, ShamWOW (Bobby53), Gilderoy and Samrick for their contributions
 * I would also like to thank everyone that has reported items that are added here in the list.
 *
 * 2012/11/23  v3.6.1.8
 *				Added Marauder's Gleaming Sack of Gold and Pandaren Tea Set (Archaeology).
 *				Running a test with attachment to Loot Events for plugin to run.
 *				Added destroying of grey items (credits to Pasterke).
 *
 * 2012/11/18  v3.6.1.7
 *				Added a different check to see if there's skinnables around.
 *				TidyBags will (hopefully) not run while skinning.
 *
 * 2012/11/16  v3.6.1.6
 *				Added MoP Archaeology items to be crated.
 *				Some other stuff I forgot to write down ^^
 *
 * 2012/10/05  v3.6.1.5
 *				Added Treasures of the Vale and Sparkling Shards.
 *
 * 2012/10/02  v3.6.1.4
 *				Added Sealed Crate (MoP version).
 *
 * 2012/09/29  v3.6.1.3
 *				Added few MoP items like Plump Intestines, Mote of Harmony,
 *				Cache of Treasures, Plundered Treasure, Good Fortune and Skyshards.
 *
 * 2012/09/24  v3.6.1.2
 *				Even more silly copy/paste faulty thingy.
 *
 * 2012/09/24  v3.6.1.1
 *				Re-added Strange Bloated Stomach (copy/paste faulty thingy).
 *
 * 2012/09/20  v3.6.1.0
 *				Separated items to each own list according to amounts (Samrick).
 *				Latest API changes for state of bot changed in the code.
 *
 * 2012/09/18  v3.6.0.0
 *              Applied suggested codechanges by Samrick.
 *              Temporary commented out the Styx.CommonBot.LootTargeting.LootMobs because it always returns true.
 *				This is a API flaw, since it should only return true on lootable mobs around.
 *
 * 2012/09/16  v3.5.5.1
 *              Removed references to Styx.Combat as they have been removed from the API and
 *              caused compiler errors on startup of HB.
 *
 * 2012/09/08  v3.5.5.0
 *              Adding and updating for the new API changes (Which are numerous).
 *              Also started to add requested items from the forum thread which are in-game already.
 *
 * 2012/08/28  v3.5.1.0
 *              Testing extra delays between looting corpses and activating TidyBags scripts to prevent lootbug.
 *
 * 2012/03/06  v3.5.0.8
 *              Added Sealed Crate (Darkmoon Faire Fishing) and Lovely Charm (Love is in the Air event).
 *
 * 2012/01/28  v3.5.0.7
 *              Added Canopic Jar on request of Laria.
 *              Sorted the list numerically (streamlining).
 *
 * 2011/12/26  v3.5.0.6
 *              Added Pouch and Sack o' Coins (Darkmoon Fair) on request of Laria.
 *              Added Lucky Red Envelopes (Lunar Festival Elder reward).
 *
 * 2011/12/26  v3.5.0.5
 *              Added the DragonSoul geodes on request of Laria.
 *              Added Jewelcrafting Daily Cooldowns (Brilliant Glass, Icy Prism and Fire Prism).
 *
 * 2011/11/22  v3.5.0.0
 *              Testing StyxWoW.SleepForLagDuration(); with Tidybags instead of hardcoded delays.
 *
 * 2011/10/20  v3.1.2.2
 *              Increased sleep time for special cases (Croga reported still lootbug).
 *              Added a break when loottime passes 6 seconds.
 *
 * 2011/10/19  v3.1.2.1
 *              Added Tiny Treasure Chest to the special handlers (SBS and HS) as it's soulbound too.
 *              (as reported by Inrego).
 *
 * 2011/10/19  v3.1.2.0
 *              Added accounting for player's lag while opening soulbound containers.
 *              Which could possibly prevent the lootbug appear for SBS and Hidden Stash.
 *
 * 2011/10/19  v3.1.1.3
 *              Added the CloseLoot command to the lua line for Soulbound items to use.
 *
 * 2011/10/19  v3.1.1.2
 *              Added the Hidden Stash to the same code as Strange Bloated Stomache (Lua wise).
 *              Seems that it's soulbound bags and items that are opened are the possible problem.
 *
 * 2011/10/18  v3.1.1.1
 *              Cleaned up the Strange Bloated Stomache lootcode.
 *
 * 2011/10/07  v3.1.1.0
 *              First attempt to a possible fix for the Bloated Stomach issue.
 *              This issue is reported by several people, but I can't reproduce it.
 *
 * 2011/08/30  v3.1.0.5
 *              Added Satchel of Exotic Mysteries (Level 85 LFD reward for performing missing roles in the group).
 *
 * 2011/08/27  v3.1.0.4
 *              Added Slimy Bag a per request Laria.
 *
 * 2011/06/02  v3.1.0.2
 *              Too hasty with adding stuff. Corrected as reported by Tomei.
 *
 * 2011/06/02  v3.1.0.1
 *              Added Satchels of Helpful Goods as reported by TheBuster.
 *              Added a extra satchel which was missing from the list.
 *              Added Sludge-Covered Object as reported by BlackBook.
 *              Added Hidden Stash as reported by tjhasty.
 *
 * 2011/02/02  v3.1.0.0
 *              Changed some behaviour regarding inventory checks (Only character inventory is checked now).
 *              Tested with latest test release (2.0.0.3895).
 *
 * 2010/12/28  v3.0.1.8
 *              Added the first Cataclysm Items (as reported and added by Maffyx).
 *              More items may possibly follow (when reported and tested).
 *
 * 2010/09/5   v3.0.0.0
 *              Reloaded Codebase and tested against HB 1.9.5.9 and AutoAngler9007. Success!!
 *              Added Oozing Bag and many Fished Items to the itemlist.
 *              More items may possibly follow (when reported and tested).
 *
 * 2010/06/11   v2.1.0.0 - Gilderoy update
 *              Removed the Lua code spam now the check for quantities is done internaly.
 *              Added a little log of the operation bone by the plugin.
 *
 * 2010/04/25   v2.0.0.0
 *              Adapted Code to HB2 Beta (LiquidAtoR).
 *
 * 2010/01/21   v1.3.1.0
 *              Added more items to the list, tried resolve problem with Jaggal Clam opening.
 *
 * 2009/12/26   v1.3.0.0
 *              Added more items to the list, added hack for motes & eternals.
 *
 * 2009/12/26   v1.2.0.0
 *              Added more items to the list.
 *
 * 2009/12/26   v1.1.0.0
 *              Fix for error "Missing reagent: Borean Leather Scraps" if you
 *              have >1 but <5 in your bags.
 *
 * 2009/12/26   v1.0.0.0
 *              First release of the plugin, seems to work for me!
 *
 */
namespace PluginTidyBags3
{
    using Styx;
    using Styx.Common;
    using Styx.Common.Helpers;
	using Styx.CommonBot;
    using Styx.CommonBot.Frames;
    using Styx.CommonBot.Inventory;
    using Styx.CommonBot.Profiles;
    using Styx.Helpers;
    using Styx.Pathing;
    using Styx.Plugins;
    using Styx.WoWInternals;
	using Styx.WoWInternals.Misc;
	using Styx.WoWInternals.World;
    using Styx.WoWInternals.WoWObjects;

    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
	using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Media;
    using System.Xml.Linq;

    public class TidyBags3 : HBPlugin
    {
        public override string Name { get { return "Tidy Bags 3.6 Reloaded"; } }
        public override string Author { get { return "LiquidAtoR"; } }
        public override Version Version { get { return new Version(3,6,1,8); } }
		
		public bool InventoryCheck = false;
		
		private bool _init;
        public override void Initialize()
        {
            if (_init) return;
            base.Initialize();
			Lua.Events.AttachEvent("LOOT_CLOSED", LootFinished);
            Logging.Write(LogLevel.Normal, Colors.DarkRed, "TidyBags 3.6 ready for use...");
            _init = true;
        }
		
        private void LootFinished(object sender, LuaEventArgs args)
        {
            if (InventoryCheck == false)
            {
                InventoryCheck = true;
            }
        }

        private HashSet<uint> _itemUseOnOne = new HashSet<uint>() {
            3352,  // Ooze-covered Bag
            6351,  // Dented Crate
            6352,  // Waterlogged Crate
            6353,  // Small Chest
            6356,  // Battered Chest
            6357,  // Sealed Crate
            5523,  // Small Barnacled Clam
            5524,  // Thick-shelled Clam
            7973,  // Big-mouth Clam
            13874, // Heavy Crate
            20708, // Tightly Sealed Trunk
            20766, // Slimy Bag
            20767, // Scum Covered Bag
            20768, // Oozing Bag
            21113, // Watertight Trunk
            21150, // Iron Bound Trunk
            21228, // Mithril Bound Trunk
            21746, // Lucky Red Envelope (Lunar Festival item)
            24476, // Jaggal Clam
            24881, // Satchel of Helpful Goods (5-15 1st)
            24889, // Satchel of Helpful Goods (5-15 others)
            24882, // Satchel of Helpful Goods (15-25 1st)
            24890, // Satchel of Helpful Goods (15-25 others)
            27481, // Heavy Supply Crate
            27511, // Inscribed Scrollcase
            27513, // Curious Crate
            32724, // Sludge Covered Object
            35945, // Brilliant Glass (Daily Cooldown for Jewelcrafting - The Burning Crusade Edition)
            36781, // Darkwater Clam
            44475, // Reinforced Crate
            44663, // Abandoned Adventurer's Satchel
            44700, // Brooding Darkwater Clam
            45909, // Giant Darkwater Clam
            49655, // Lovely Charm (Love is in the Air item)
            51999, // Satchel of Helpful Goods (iLevel 25)
            52000, // Satchel of Helpful Goods (31)
            52001, // Satchel of Helpful Goods (41)
            52002, // Satchel of Helpful Goods (50)
            52003, // Satchel of Helpful Goods (57)
            52004, // Satchel of Helpful Goods (62)
            52005, // Satchel of Helpful Goods (66)
            52340, // Abyssal Clam
            61387, // Hidden Stash
            62242, // Icy Prism (Daily Cooldown for Jewelcrafting - Wrath Edition)
            64657, // Canopic Jar (Archaeology Tol'vir relic)
            67248, // Satchel of Helpful Goods (39)
            67250, // Satchel of Helpful Goods (85)
            67495, // Strange Bloated Stomach (Cataclysm Skinning)
            67539, // Tiny Treasure Chest
            67597, // Sealed Crate (level 85 version)
            69903, // Satchel of Exotic Mysteries (LFD - Extra Reward)
			72201, // Plump Intestines (MoP Skinning)
            73478, // Fire Prism (Daily Cooldown for Jewelcrafting - Cataclysm Edition)
            78890, // Crystalline Geode (Dragon Soul Raid - Normal 10/25 every bossloot)
            78891, // Elementium-Coated Geode (Dragon Soul Raid - Normal 10/25 Deathwing Kill)
            78892, // Perfect Geode (Dragon Soul Raid - Heroic Hardmode 10/25 Deathwing Kill)
            78897, // Pouch o' Tokens (5 Darkmoon Faire Game Coins)
            78898, // Sack o' Tokens (20 Darkmoon Faire Game Coins)
            78899, // Pouch o' Tokens (5 Darkmoon Faire Game Coins)
            78900, // Pouch o' Tokens (5 Darkmoon Faire Game Coins)
            78901, // Pouch o' Tokens (5 Darkmoon Faire Game Coins)
            78902, // Pouch o' Tokens (5 Darkmoon Faire Game Coins)
            78903, // Pouch o' Tokens (5 Darkmoon Faire Game Coins)
            78905, // Sack o' Tokens (20 Darkmoon Faire Game Coins)
            78906, // Sack o' Tokens (20 Darkmoon Faire Game Coins)
            78907, // Sack o' Tokens (20 Darkmoon Faire Game Coins)
            78908, // Sack o' Tokens (20 Darkmoon Faire Game Coins)
            78909, // Sack o' Tokens (20 Darkmoon Faire Game Coins)
            78930, // Sealed Crate (around the Darkmoon Faire Island)
			79896, // Pandaren Tea Set (Archaeology)
			79897, // Pandaren Game Board (Archaeology)
			79898, // Twin Stein Set (Archaeology)
			79899, // Walking Cane (Archaeology)
			79900, // Empty Keg (Archaeology)
			79901, // Carved Bronze Mirror (Archaeology)
			79902, // Gold-Inlaid Figurine (Archaeology)
			79903, // Apothecary Tins (Archaeology)
			79904, // Pearl of Yu'lon (Archaeology)
			79905, // Standard of Niuzao (Archaeology)
			79908, // Manacles of Rebellion (Archaeology)
			79909, // Cracked Mogu Runestone (Archaeology)
			79910, // Terracotta Arm (Archaeology)
			79911, // Petrified Bone Whip (Archaeology)
			79912, // Thunder King Insignia (Archaeology)
			79913, // Edicts of the Thunder King (Archaeology)
			79914, // Iron Amulet (Archaeology)
			79915, // Warlord's Branding Iron (Archaeology)
			79916, // Mogu Coin (Archaeology)
			79917, // Worn Monument Ledger (Archaeology)
			87391, // Plundered Treasure (Luck of the Lotus Buff)
			88496, // Sealed Crate (MoP version)
			89613, // Cache of Treasures
            89810, // Bounty of a Sundered Land (LFR Contains 25G if you don't win gear)
			90625, // Treasures of the Vale (Daily Quest Reward)
			90716, // Good Fortune (when using a Lucky Charm on a boss for loot)
			90840  // Marauder's Gleaming Sack of Gold (World Boss gold drop)
        };

        private HashSet<uint> _itemUseOnFive = new HashSet<uint>() {
            33567 // Borean Leather Scraps
        };

        private HashSet<uint> _itemUseOnTen = new HashSet<uint>() {
            22572, // Mote of Air
            22573, // Mote of Earth
            22574, // Mote of Fire
            22575, // Mote of Life
            22576, // Mote of Mana
            22577, // Mote of Shadow
            22578, // Mote of Water
            37700, // Crystallized Air
            37701, // Crystallized Earth
            37702, // Crystallized Fire
            37703, // Crystallized Shadow
            37704, // Crystallized Life
            37705, // Crystallized Water
			86547, // Skyshard
			89112, // Mote of Harmony
			90407  // Sparkling Shard (from Prospecting ores)
        };

        private HashSet<uint> _itemRequiresSleep = new HashSet<uint>() {
            61387, // Hidden Stash
            67495, // Strange Bloated Stomach
            67539, // Tiny Treasure Chest
			72201, // Plump Intestines
			87391, // Plundered Treasure (Luck of the Lotus Buff)
			88496, // Sealed Crate (MoP version)
			89613, // Cache of Treasures
			90625, // Treasures of the Vale (Daily Quest Reward)
			90716, // Good Fortune
			90840  // Marauder's Gleaming Sack of Gold (World Boss gold drop)
        };
		
		private HashSet<uint> _destroyItems = new HashSet<uint>() {
			45188, //Whitered Kelp
			45189, //Torn Sail
			45190, //Driftwood
			45191, //Empty Clam
			45194, //Tangled Fishing Line
			45195, //Empty Rum Bottle
			45196, //Tattered Cloth
			45197, //Tree Branch
			45198, //Weeds
			45199, //Old Boot
			45200, //Sickly Fish
			45201  //Rock
		};

        public override void Pulse()
        {
		if (_init)
            if (StyxWoW.Me.IsActuallyInCombat
                || StyxWoW.Me.Mounted
                || StyxWoW.Me.IsDead
                || StyxWoW.Me.IsGhost
                ) {
                return;
            }

            if (InventoryCheck) { // Loot Event has Finished
                foreach (WoWItem item in ObjectManager.GetObjectsOfType<WoWItem>()) { // iterate over every item
                    if (item != null && item.BagSlot != -1 && StyxWoW.Me.FreeNormalBagSlots >= 1) { // check if item exists and is in bag and we have space
                        if (_itemUseOnFive.Contains(item.Entry)) { // stacks of 5
                            if (item.StackCount >= 5) {
                                this.useItem(item);
                            }
                        } else if (_itemUseOnTen.Contains(item.Entry)) { // stacks of 10
                            if (item.StackCount >= 10) {
                                this.useItem(item);
                            }
                        } else if (_itemUseOnOne.Contains(item.Entry)) { // stacks of 1
                            if (item.StackCount >= 1) {
                                this.useItem(item);
                            }
                        } else if (_destroyItems.Contains(item.Entry)) {
								this.destroyItem(item);
						}
                    }
                }
				InventoryCheck = false;
                StyxWoW.SleepForLagDuration();
            }
        }

        private void useItem(WoWItem item)
        {
            Logging.Write(LogLevel.Normal, Colors.DarkRed, "[{0} {1}]: Using {2} we have {3}", this.Name, this.Version, item.Name, item.StackCount);
			
            if (_itemRequiresSleep.Contains(item.Entry)) {
                // some (soulbound) items require an additional sleep to prevent a loot bug
                StyxWoW.SleepForLagDuration();
            }
            Lua.DoString("UseItemByName(\"" + item.Name + "\")");
            StyxWoW.SleepForLagDuration();
        }

		private void destroyItem(WoWItem item) 
		{
			Logging.Write(LogLevel.Normal, Colors.DarkRed, "[{0} {1}]: Destroying {2} we have {3}", this.Name, this.Version, item.Name, item.StackCount);
			item.PickUp();
			Lua.DoString("DeleteCursorItem()");
			StyxWoW.SleepForLagDuration();
		}
    }
}