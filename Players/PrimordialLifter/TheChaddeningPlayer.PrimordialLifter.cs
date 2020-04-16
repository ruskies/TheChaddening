using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TheChaddening.Buffs.Primordial;
using TheChaddening.Identities;
using WebmilioCommons.Extensions;
using WebmilioCommons.Identity;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer
    {
        public const float 
            PRIMORDIAL_LIFTER_MULTIPLIER = 4f,
            PRIMORDIAL_CHILDREN_MULTIPLIER = 2.5f;

        public bool IsPrimordial() => IsPrimordialLifter || IsPrimordialChild;

        public float GetPrimordialBlessingMultiplier()
        {
            if (IsPrimordialLifter)
                return PRIMORDIAL_LIFTER_MULTIPLIER;

            float multiplier = PRIMORDIAL_CHILDREN_MULTIPLIER - 0.25f * PrimordialGeneration;

            if (multiplier < 1.25f)
                multiplier = 1.25f;

            return multiplier;
        }


        private void OnEnterWorldPrimordialLifter(Player plr)
        {
            if (!plr.IsLocalPlayer())
                return;

            IsPrimordialLifter = plr.name.Equals("$THECHAD") && IdentityManager.Is<WebmilioIdentity>();
        }

        private void PreUpdatePrimordialLifter()
        {
            if (TrueChad && TheChaddeningMod.Instance.PrimordialGenes)
            {
                if (IsPrimordialLifter)
                {
                    IsPrimordialChild = false;

                    player.AddBuff<PrimordialLifterBuff>(3);
                }
                else if (IsPrimordialChild)
                    player.AddBuff<PrimordialLiftersBlessingBuff>(3);
            }
            else
            {
                if (IsPrimordialChild)
                    IsPrimordialChild = false;

                player.ClearBuff<PrimordialLifterBuff>();
                player.ClearBuff<PrimordialLiftersBlessingBuff>();
            }
        }


        private void ResetEffectsPrimordialLifter()
        {
            if (IsPrimordialLifter)
                IsPrimordialChild = false;
        }


        private void LoadPrimordialLifter(TagCompound tag)
        {
            IsPrimordialChild = tag.GetBool(nameof(IsPrimordialChild));
            PrimordialGeneration = tag.GetInt(nameof(PrimordialGeneration));
        }

        private void SavePrimordialLifter(TagCompound tag)
        {
            tag.Add(nameof(IsPrimordialChild), IsPrimordialChild);
            tag.Add(nameof(PrimordialGeneration), PrimordialGeneration);
        }


        public bool IsPrimordialLifter { get; internal set; }

        public bool IsPrimordialChild { get; internal set; }
        public int PrimordialGeneration { get; internal set; }
    }
}
