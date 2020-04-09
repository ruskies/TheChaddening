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
        private readonly SortedList<ulong, Dictionary<AbilityTypes, Ability>> byIndex = new SortedList<ulong, Dictionary<AbilityTypes, Ability>>();


        public Ability GetLastAbility(TheChaddeningPlayer player, AbilityTypes abilityType)
        {
            ulong requiredStrength = 0; // We store the current strength to avoid having to inline methods. Its a bit faster but takes more RAM.
            Ability ability = null;

            foreach (var dict in byIndex.Values)
            {
                if (!dict.ContainsKey(abilityType))
                    continue;

                var fAbility = dict[abilityType];
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
            if (!byIndex.ContainsKey(item.RequiredStrengthToUnlock))
                byIndex.Add(item.RequiredStrengthToUnlock, new Dictionary<AbilityTypes, Ability>());
            
            byIndex[item.RequiredStrengthToUnlock].Add(item.AbilityType, item);
        }
    }
}
