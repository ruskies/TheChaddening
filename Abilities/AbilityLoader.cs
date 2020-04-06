using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using TheChaddening.Abilities.Body;
using TheChaddening.Abilities.Fists.Melee.Normal;
using TheChaddening.Abilities.Fists.Ranged.ShockwavePunch;
using TheChaddening.Abilities.Fists.Ranged.WindBlow;
using TheChaddening.Players;
using WebmilioCommons.Loaders;

namespace TheChaddening.Abilities
{
    public sealed class AbilityLoader : SingletonLoader<AbilityLoader, Ability>
    {
        private readonly SortedList<ulong, Ability> byIndex = new SortedList<ulong, Ability>();


        public Ability GetLastAbility(TheChaddeningPlayer player, AbilityTypes abilityType)
        {
            ulong requiredStrength = 0; // We store the current strength to avoid having to inline methods. Its a bit faster but takes more RAM.
            Ability ability = null;

            foreach (var fAbility in byIndex.Values)
            {
                ulong useStrength = fAbility.GetRequiredStrengthToUse(player);

                if (fAbility.CanUse(player) && fAbility.RequiredStrengthToUnlock <= player.Strength && useStrength >= requiredStrength && useStrength < player.ChargedStrength && fAbility.AbilityType == abilityType)
                {
                    ability = fAbility;
                    requiredStrength = fAbility.GetRequiredStrengthToUse(player);
                }
            }

            return ability;
        }


        protected override void PostAdd(Mod mod, Ability item, Type type)
        {
            byIndex.Add(item.RequiredStrengthToUnlock, item);
        }
    }
}
