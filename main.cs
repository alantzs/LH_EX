using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LH_EX
{
    public class LH_EX_Form : Form
    {
        // Импорт для перетаскивания окна без рамок
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private Panel sidebar;
        private Label logo;
        private RichTextBox editor;
        private Button injectBtn;
        private Button executeBtn;

        public LH_EX_Form()
        {
            // Настройки окна
            this.Size = new Size(700, 450);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(13, 5, 26); // Твой фиолетовый
            this.StartPosition = FormStartPosition.CenterScreen;

            // Боковая панель (как в Дельте)
            sidebar = new Panel();
            sidebar.Size = new Size(60, 450);
            sidebar.Dock = DockStyle.Left;
            sidebar.BackColor = Color.FromArgb(20, 10, 40);
            this.Controls.Add(sidebar);

            // Логотип LH (Текстом)
            logo = new Label();
            logo.Text = "LH";
            logo.Font = new Font("Arial Black", 24, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(5, 20);
            logo.AutoSize = true;
            sidebar.Controls.Add(logo);

            // Поле для скриптов
            editor = new RichTextBox();
            editor.Size = new Size(600, 300);
            editor.Location = new Point(80, 60);
            editor.BackColor = Color.FromArgb(8, 3, 18);
            editor.ForeColor = Color.Lime;
            editor.BorderStyle = BorderStyle.None;
            editor.Text = "-- LH EX SYSTEM READY\n-- Paste your script here...";
            this.Controls.Add(editor);

            // Кнопка ATTACH (Инжект)
            injectBtn = new Button();
            injectBtn.Text = "ATTACH ☹";
            injectBtn.Size = new Size(120, 40);
            injectBtn.Location = new Point(80, 380);
            injectBtn.FlatStyle = FlatStyle.Flat;
            injectBtn.ForeColor = Color.White;
            injectBtn.FlatAppearance.BorderColor = Color.Purple;
            injectBtn.Click += (s, e) => {
                injectBtn.Text = "READY ☺";
                injectBtn.BackColor = Color.DarkGreen;
                // Тут будет вызов API
            };
            this.Controls.Add(injectBtn);

            // Кнопка EXECUTE
            executeBtn = new Button();
            executeBtn.Text = "EXECUTE";
            executeBtn.Size = new Size(120, 40);
            executeBtn.Location = new Point(210, 380);
            executeBtn.FlatStyle = FlatStyle.Flat;
            executeBtn.ForeColor = Color.White;
            executeBtn.FlatAppearance.BorderColor = Color.Purple;
            this.Controls.Add(executeBtn);

            // Кнопка закрытия
            Button close = new Button();
            close.Text = "X";
            close.Size = new Size(30, 30);
            close.Location = new Point(660, 10);
            close.FlatStyle = FlatStyle.Flat;
            close.ForeColor = Color.White;
            close.Click += (s, e) => Application.Exit();
            this.Controls.Add(close);

            // Перетаскивание
            this.MouseDown += (s, e) => {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            };
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new LH_EX_Form());
        }
    }
}
