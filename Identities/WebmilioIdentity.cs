using WebmilioCommons.Identity;

namespace TheChaddening.Identities
{
    public sealed class WebmilioIdentity : SteamIdentity
    {
        public WebmilioIdentity() : base(76561198046878487)
        {
            System.Diagnostics.Debug.WriteLine("REACHED WEBMILIO IDENTITY.");
        }
    }
}