using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TheChaddening.Players;

namespace TheChaddening.Abilities.Body.PrimordialBlessing
{
    public sealed class PrimordialBlessingAbility : Ability
    {
        public PrimordialBlessingAbility() : base("body.giveBlessing", "Bless", 1, AbilityTypes.Body)
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