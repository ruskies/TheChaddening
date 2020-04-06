using Terraria;
using Terraria.ModLoader.IO;
using TheChaddening.Buffs.Primordial;
using TheChaddening.Helpers;
using WebmilioCommons.Extensions;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer
    {
        private bool _isPrimordialLifter;


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


        private void OnEnterWorldPrimordialLifter(Player player)
        {
            if (!player.IsLocalPlayer()) return;

            IsPrimordialLifter = player.name.Equals("$THECHAD") && SteamHelper.Webmilio;
        }

        private void PreUpdatePrimordialLifter()
        {
            if (TrueChad)
            {
                if (IsPrimordialLifter)
                {
                    IsPrimordialChild = false;

                    if (!player.HasBuff<PrimordialLifterBuff>())
                        player.AddBuff<PrimordialLifterBuff>(int.MaxValue);
                }
                else if (IsPrimordialChild && !player.HasBuff<PrimordialLiftersBlessingBuff>())
                    player.AddBuff<PrimordialLiftersBlessingBuff>(int.MaxValue);
            }
            else
            {
                if (IsPrimordialChild)
                {
                    IsPrimordialChild = false;
                    player.ClearBuff<PrimordialLiftersBlessingBuff>();
                }
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


        public bool IsPrimordialLifter
        {
            get => _isPrimordialLifter;
            internal set => _isPrimordialLifter = value;
        }

        public bool IsPrimordialChild { get; internal set; }
        public int PrimordialGeneration { get; internal set; }
    }
}
