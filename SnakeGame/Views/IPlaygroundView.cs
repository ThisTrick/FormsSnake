using System;
using System.Windows.Forms;

namespace FormsSnake.Views
{
    public interface IPlaygroundView
    {
        event KeyEventHandler KeyDown;

        event EventHandler GameTick;

        event EventHandler Load;

        void Close();

        void AddControl(Control control);
        void RemoveControl(Control control);

        void SetScore(int score);
    }
}