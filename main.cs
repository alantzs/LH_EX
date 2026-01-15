using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LH_EX_Launcher
{
    public class LH_Launcher : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public LH_Launcher()
        {
            this.Size = new Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(15, 10, 25);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Заголовок
            Label title = new Label { Text = "LH EXECUTOR SYSTEM V1", ForeColor = Color.MediumPurple, Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            this.Controls.Add(title);

            // ПОЛЕ ДЛЯ СКРИПТА (Тут ты будешь писать код)
            RichTextBox scriptBox = new RichTextBox {
                Location = new Point(20, 70),
                Size = new Size(560, 220),
                BackColor = Color.FromArgb(30, 20, 45),
                ForeColor = Color.Lime,
                BorderStyle = BorderStyle.None,
                Font = new Font("Consolas", 10)
            };
            this.Controls.Add(scriptBox);

            // Кнопка EXECUTE
            Button execBtn = new Button {
                Text = "EXECUTE",
                Size = new Size(120, 40),
                Location = new Point(20, 310),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(60, 30, 100)
            };
            execBtn.Click += (s, e) => {
                MessageBox.Show("LH EX: Скрипт отправлен! (Нужно подключить API DLL)", "LH RECORDS");
            };
            this.Controls.Add(execBtn);

            // Кнопка ATTACH
            Button attachBtn = new Button {
                Text = "ATTACH",
                Size = new Size(120, 40),
                Location = new Point(150, 310),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 80, 40)
            };
            attachBtn.Click += (s, e) => {
                if (FindWindow(null, "Roblox") != IntPtr.Zero) MessageBox.Show("Attached to Roblox!");
                else MessageBox.Show("Roblox not found!");
            };
            this.Controls.Add(attachBtn);

            // Выход
            Button xBtn = new Button { Text = "X", Location = new Point(560, 10), FlatStyle = FlatStyle.Flat, ForeColor = Color.White };
            xBtn.Click += (s, e) => Application.Exit();
            this.Controls.Add(xBtn);
        }

        [STAThread]
        static void Main() { Application.Run(new LH_Launcher()); }
    }
}
