using Terraria.ModLoader.IO;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer
    {
        public override void Load(TagCompound tag)
        {
            Strength = tag.Get<ulong>(nameof(Strength));
            TrueChad = tag.GetBool(nameof(TrueChad));

            LoadCharge(tag);
            LoadCurls(tag);
            LoadPrimordialLifter(tag);
        }

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound()
            {
                [nameof(Strength)] = Strength,
                [nameof(TrueChad)] = TrueChad
            };

            SaveCharge(tag);
            SaveCurls(tag);
            SavePrimordialLifter(tag);

            return tag;
        }
    }
}
