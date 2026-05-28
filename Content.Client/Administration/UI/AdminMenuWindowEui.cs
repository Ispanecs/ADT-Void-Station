using Content.Client.Eui;
using Content.Shared.Administration;
using Content.Shared.Eui;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Utility;
using Robust.Shared.Audio;

namespace Content.Client.Administration.UI
{
    public sealed class AdminAnnounceEui : BaseEui
    {
        private readonly AdminAnnounceWindow _window;

        public AdminAnnounceEui()
        {
            _window = new AdminAnnounceWindow();
            _window.OnClose += () => SendMessage(new CloseEuiMessage());
            _window.AnnounceButton.OnPressed += AnnounceButtonOnOnPressed;
        }

        private void AnnounceButtonOnOnPressed(BaseButton.ButtonEventArgs obj)
        {
            SendMessage(new AdminAnnounceEuiMsg.DoAnnounce
            {
                Announcement = Rope.Collapse(_window.Announcement.TextRope),
                Announcer = _window.Announcer.Text,
                AnnounceType = (AdminAnnounceType)(_window.AnnounceMethod.SelectedMetadata ?? AdminAnnounceType.Station),
                CloseAfter = !_window.KeepWindowOpen.Pressed,
                // Void Sector start
                AnnounceColor = Color.FromHex(_window.Color.Text),
                SoundSpecifier = new SoundPathSpecifier(_window.AnnounceSound.Text.Trim(),
                    AudioParams.Default.WithVolume(_window.AnnounceVolume.Value)),
                // Void Sector start
            });

        }

        public override void Opened()
        {
            _window.OpenCentered();
        }

        public override void Closed()
        {
            _window.Close();
        }
    }
}
