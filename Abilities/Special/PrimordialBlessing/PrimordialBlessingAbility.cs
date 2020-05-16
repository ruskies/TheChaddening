using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TheChaddening.Players;
using WebmilioCommons.Extensions;

namespace TheChaddening.Abilities.Special.PrimordialBlessing
{
    public sealed class PrimordialBlessingAbility : Ability
    {
        public PrimordialBlessingAbility() : base("special.giveBlessing", "Bless", 1, AbilityTypes.Special)
        {
        }


        public override ulong GetRequiredStrengthToUse(TheChaddeningPlayer chad) => chad.Strength * 1;


        public override bool OnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged, bool local)
        {
            if (!chad.IsPrimordial())
                return false;


            if (Main.dedServ)
                Console.WriteLine("{0} created a blessing!", chad.player.name);


            PrimordialLiftersBlessing blessing = Main.item[Item.NewItem(chad.player.position - new Vector2(0, chad.player.height), 22, 28,
                ModContent.ItemType<PrimordialLiftersBlessing>(), 1)].modItem as PrimordialLiftersBlessing;

            blessing.PrimordialGeneration = chad.PrimordialGeneration + 1;


            return true;
        }


        public override bool CanUse(TheChaddeningPlayer chad) => chad.IsPrimordial();
    }
}