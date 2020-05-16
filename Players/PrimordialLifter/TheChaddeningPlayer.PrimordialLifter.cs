using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TheChaddening.Abilities.Special.PrimordialBlessing;
using TheChaddening.Buffs.Primordial;
using TheChaddening.Identities;
using WebmilioCommons.Extensions;
using WebmilioCommons.Identity;
using WebmilioCommons.Networking;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer
    {
        public const float 
            PRIMORDIAL_LIFTER_MULTIPLIER = 4f,
            PRIMORDIAL_CHILDREN_MULTIPLIER = 2.5f;

        private const string PRIMORDIAL_LIFTER = "PrimordialLifter";


        private bool
            _isPrimordialLifter,
            _isPrimordialChild;


        internal void BecomePrimordialChild(Item item)
        {
            if (!(item.modItem is PrimordialLiftersBlessing primordialBlessing))
                return;

            PrimordialGeneration = primordialBlessing.PrimordialGeneration;
            IsPrimordialChild = true;
        }


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


        private void InitializePrimordialLifter()
        {
            if (!this.IsLocalPlayer())
                return;
        }


        private void OnEnterWorldPrimordialLifter(Player plr)
        {
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
            if (TheChaddeningMod.Instance.PrimordialGenes)
                IsPrimordialLifter = tag.ContainsKey(PRIMORDIAL_LIFTER) && tag.GetBool(PRIMORDIAL_LIFTER) && IdentityManager.Is<WebmilioIdentity>();


            IsPrimordialChild = tag.GetBool(nameof(IsPrimordialChild)) && !IsPrimordialLifter;
            PrimordialGeneration = tag.GetInt(nameof(PrimordialGeneration));
        }

        private void SavePrimordialLifter(TagCompound tag)
        {
            if (IsPrimordialLifter)
                tag.Add(PRIMORDIAL_LIFTER, true);


            tag.Add(nameof(IsPrimordialChild), IsPrimordialChild);
            tag.Add(nameof(PrimordialGeneration), PrimordialGeneration);
        }


        public bool IsPrimordialLifter
        {
            get => _isPrimordialLifter;
            internal set
            {
                if (!IdentityManager.Is<WebmilioIdentity>() || _isPrimordialLifter == value)
                    return;

                _isPrimordialLifter = value;

                NetworkPacketLoader.Instance.SendPacket<PrimordialLifterStatusChangedPacket>();
            }
        }


        public bool IsPrimordialChild
        {
            get => _isPrimordialChild;
            internal set
            {
                if (_isPrimordialChild == value)
                    return;

                _isPrimordialChild = value;

                NetworkPacketLoader.Instance.SendPacket<PrimordialChildStatusChangedPacket>();
            }
        }

        public int PrimordialGeneration { get; internal set; }
    }
}
