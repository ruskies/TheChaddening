using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace TheChaddening.Commands
{
    public class ChadDebugCommand : DebugCommand
    {
        public ChadDebugCommand(string command, CommandType type) : base(command, type)
        {
        }


        public override bool Autoload(ref string name) => true;
    }
}