using Content.Shared.Eui;
using Robust.Shared.Serialization;
using Robust.Shared.Audio;

namespace Content.Shared.Administration
{
    public enum AdminAnnounceType
    {
        Station,
        Server,
    }

    [Serializable, NetSerializable]
    public sealed class AdminAnnounceEuiState : EuiStateBase
    {
    }

    public static class AdminAnnounceEuiMsg
    {
        [Serializable, NetSerializable]
        public sealed class DoAnnounce : EuiMessageBase
        {
            public bool CloseAfter;
            public string Announcer = default!;
            public string Announcement = default!;
            public AdminAnnounceType AnnounceType;
            //Void Sector tweak start
            public SoundSpecifier SoundSpecifier = default!;
            public Color AnnounceColor = default!;
            //Void Sector tweak end
        }
    }
}
