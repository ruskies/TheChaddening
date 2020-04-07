using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using TheChaddening.Abilities;
using TheChaddening.Players;

namespace TheChaddening.Items
{
    public sealed class Fist : ChadItem
    {
        private bool _abilityLocked = false;

        public Fist() : base("Your Fists", "These are your fists, the only weapons you'll ever need.\nYou could drop them, but that wouldn't make any sense.", 26, 30, rarity: ItemRarityID.Expert)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTime = 1;
            item.useAnimation = 1;

            item.noUseGraphic = true;
            item.useTurn = true;

            item.damage = 0;
            item.melee = true;

            item.channel = true;
            item.autoReuse = true;
        }


        public override bool UseItem(Player player)
        {
            if (ChargedForFrames == 0)
            {
                CurrentAbility = null;
                LockedInAbility = null;
            }

            if (player.channel)
            {
                ChargedForFrames++;

                TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(player);
                TriggersSet triggersSet = tcp.TriggersSet;

                tcp.ChargeStrength(percentagePerSecond: 0.25f);

                if (LockedInAbility == null)
                    CurrentAbility = AbilityLoader.Instance.GetLastAbility(tcp, tcp.PunchingMode);

                if (triggersSet != null && triggersSet.MouseRight)
                    LockedInAbility = AbilityLoader.Instance.GetLastAbility(tcp, tcp.PunchingMode);

                return true;
            }

            return base.UseItem(player);
        }


        public override void UpdateInventory(Player player)
        {
            if (ChargedForFrames == 0 || player.channel && player.HeldItem.modItem is Fist)
                return;

            ChargedForFrames = 0;

            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(player);

            if (LockedInAbility == null)
                LockedInAbility = CurrentAbility;

            CurrentAbility = null;

            if (LockedInAbility != null)
            {
                LockedInAbility.DoOnChargeRelease(tcp, ChargedForFrames, tcp.ChargedStrength);
            }

            tcp.ResetChargedStrength();
        }


        public int ChargedForFrames { get; private set; }

        public Ability CurrentAbility { get; private set; }
        public Ability LockedInAbility { get; private set; }
    }
}