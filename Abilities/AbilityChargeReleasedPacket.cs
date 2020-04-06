using System.IO;
using TheChaddening.Players;
using WebmilioCommons.Networking.Packets;

namespace TheChaddening.Abilities
{
    public class AbilityChargeReleasedPacket : ModPlayerNetworkPacket<TheChaddeningPlayer>
    {
        public AbilityChargeReleasedPacket()
        {
        }

        public AbilityChargeReleasedPacket(Ability ability, int chargedForFrames, ulong strengthCharged)
        {
            AbilityId = AbilityLoader.Instance.GetId(ability);
            ChargedForFrames = chargedForFrames;
            StrengthCharged = strengthCharged;
        }


        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            AbilityLoader.Instance.GetGeneric(AbilityId).OnChargeRelease(ModPlayer, ChargedForFrames, StrengthCharged, false);
            return true;
        }


        public int AbilityId { get; set; }

        public int ChargedForFrames { get; set; }

        public ulong StrengthCharged { get; set; }
    }
}