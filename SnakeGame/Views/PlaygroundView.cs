using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FormsSnake.Presenters;

namespace FormsSnake.Views
{
    public partial class PlaygroundView : Form, IPlaygroundView
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void PlaygroundView_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private readonly PlaygroundPresenter _presenter;
        
        public PlaygroundView()
        {
            InitializeComponent();
            _presenter = new PlaygroundPresenter(this);
        }


        public event EventHandler GameTick
        {
            add => SnakeGo.Tick += value;
            remove => SnakeGo.Tick -= value;
        }
        
        public void AddControl(Control control) => Controls.Add(control);

        public void RemoveControl(Control control) => Controls.Remove(control);

        public void SetScore(int score) => Count.Text = score.ToString();
        
    }
}
