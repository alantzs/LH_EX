using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;

namespace LH_EX_Launcher
{
    public class LH_Launcher : Form
    {
        // Для поиска окна Роблокса
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public LH_Launcher()
        {
            this.Size = new Size(550, 300);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(20, 15, 30);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Логотип
            Label logo = new Label { Text = "LH EXECUTOR", ForeColor = Color.MediumPurple, Font = new Font("Arial", 18, FontStyle.Bold), Location = new Point(180, 30), AutoSize = true };
            this.Controls.Add(logo);

            // Кнопка INJECT
            Button injectBtn = new Button {
                Text = "ATTACH TO ROBLOX",
                Size = new Size(200, 50),
                Location = new Point(175, 120),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(60, 30, 100)
            };
            injectBtn.Click += (s, e) => {
                IntPtr robloxHandle = FindWindow(null, "Roblox");
                if (robloxHandle != IntPtr.Zero) {
                    injectBtn.Text = "ATTACHED! ✅";
                    injectBtn.BackColor = Color.DarkGreen;
                    MessageBox.Show("LH EX: Успешно подключено к Roblox. Теперь можно запускать скрипты!", "LH RECORDS");
                } else {
                    MessageBox.Show("Ошибка: Сначала запусти Roblox!", "LH RECORDS");
                }
            };
            this.Controls.Add(injectBtn);

            // Кнопка закрытия
            Button closeBtn = new Button { Text = "X", Location = new Point(510, 10), FlatStyle = FlatStyle.Flat, ForeColor = Color.White };
            closeBtn.Click += (s, e) => Application.Exit();
            this.Controls.Add(closeBtn);
        }

        [STAThread]
        static void Main() { Application.Run(new LH_Launcher()); }
    }
}
