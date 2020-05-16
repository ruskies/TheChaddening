using System.Collections.Generic;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using TheChaddening.Commons;
using TheChaddening.Items;
using TheChaddening.Items.Dumbbells;
using WebmilioCommons.Extensions;
using WebmilioCommons.Networking;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        public static TheChaddeningPlayer Get() => Get(Main.LocalPlayer);

        public static TheChaddeningPlayer Get(Player player) => player.GetModPlayer<TheChaddeningPlayer>();


        public ulong AddStrength(ulong strengthGain, bool quiet = false)
        {
            Strength += strengthGain;

            if (!quiet)
                OnStrengthGained(strengthGain);

            return Strength;
        }


        private void OnStrengthGained(ulong strengthGain)
        {
            OnStrengthGainedVisuals(strengthGain);
        }


        public override void Initialize()
        {
            InitializeCharge();
            InitializePrimordialLifter();

            Strength = 1;
            TrueChad = true;

            TriggersSet = null;
        }


        public override void OnEnterWorld(Player plr)
        {
            OnEnterWorldPrimordialLifter(plr);
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            new PlayerSynchronizationPacket(this).Send(fromWho, toWho);
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            TriggersSet = triggersSet;

            ProcessTriggersCharge(triggersSet);
            ProcessTriggersFists(triggersSet);
            ProcessTriggersMovements(triggersSet);
        }


        public override void PreUpdate()
        {
            if (!ModContent.GetInstance<ChadGlobalConfiguration>().ChadChallenge)
                TrueChad = false;

            if (player.GetItemsByType<Hand>(inventory: true).Count == 0)
                player.PutItemInInventory(ModContent.ItemType<Hand>());

            if (player.GetItemsByType<ChopHand>(inventory: true).Count == 0)
                player.PutItemInInventory(ModContent.ItemType<ChopHand>());

            if (player.GetItemsByType<Fist>(inventory: true).Count == 0)
                player.PutItemInInventory(ModContent.ItemType<Fist>());


            PreUpdatePrimordialLifter();
        }

        public override void PreUpdateMovement()
        {
            PreUpdateMovementGains();
        }


        public override void ResetEffects()
        {
            ResetEffectsGains();
            ResetEffectsCharge();
            ResetEffectsMovements();
            ResetEffectsPrimordialLifter();


            player.statLifeMax2 += ChadMath.GetExtraHealth(Strength);
        }


        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            List<Item> toRemove = new List<Item>();


            foreach (Item item in items)
                if (item.type == ItemID.CopperPickaxe || item.type == ItemID.CopperAxe || item.type == ItemID.CopperShortsword)
                    toRemove.Add(item);


            for (int i = 0; i < toRemove.Count; i++)
                items.Remove(toRemove[i]);


            ModItem dumbbell = new BasicDumbbell();
            dumbbell.item.SetDefaults(ModContent.ItemType<BasicDumbbell>());


            items.Add(dumbbell.item);
        }


        public ulong Strength { get; private set; }
        public bool TrueChad { get; internal set; }


        public TriggersSet TriggersSet { get; private set; }
    }
}
