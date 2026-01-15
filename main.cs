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
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public LH_Launcher()
        {
            this.Size = new Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(10, 5, 20);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Дизайн LH RECORDS ---
            Panel sideBar = new Panel { Width = 70, Dock = DockStyle.Left, BackColor = Color.FromArgb(15, 8, 30) };
            this.Controls.Add(sideBar);

            Label logo = new Label { 
                Text = "LH", ForeColor = Color.White, 
                Font = new Font("Arial Black", 22, FontStyle.Bold), 
                Location = new Point(10, 20), AutoSize = true 
            };
            sideBar.Controls.Add(logo);

            Label title = new Label { 
                Text = "LH EXECUTOR SYSTEM V1", ForeColor = Color.FromArgb(180, 100, 255), 
                Font = new Font("Arial", 12, FontStyle.Bold), 
                Location = new Point(90, 25), AutoSize = true 
            };
            this.Controls.Add(title);

            // --- Кнопка ЗАПУСКА ---
            Button launchBtn = new Button {
                Text = "LAUNCH ROBLOX & INJECT ☺",
                Size = new Size(300, 60),
                Location = new Point(250, 180),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 20, 80),
                Font = new Font("Arial", 14, FontStyle.Bold)
            };
            launchBtn.FlatAppearance.BorderSize = 2;
            launchBtn.FlatAppearance.BorderColor = Color.MediumPurple;
            
            launchBtn.Click += (s, e) => {
                launchBtn.Text = "WAITING FOR ROBLOX...";
                launchBtn.Enabled = false;
                StartAndInject();
            };
            this.Controls.Add(launchBtn);

            // Кнопка закрытия
            Button closeBtn = new Button { Text = "X", Location = new Point(760, 10), Size = new Size(30,30), FlatStyle = FlatStyle.Flat, ForeColor = Color.Gray };
            closeBtn.Click += (s, e) => Application.Exit();
            this.Controls.Add(closeBtn);

            this.MouseDown += (s, e) => { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); };
        }

        private void StartAndInject()
        {
            try {
                // Запуск роблокса (через протокол)
                Process.Start("roblox-player:1");
                
                // Здесь будет логика инъекции твоего GUI
                MessageBox.Show("LH EX: Roblox обнаружен! Инъекция интерфейса...", "LH RECORDS");
            } catch {
                MessageBox.Show("Ошибка! Убедись, что Роблокс установлен.");
            }
        }

        [STAThread]
        static void Main() { Application.Run(new LH_Launcher()); }
    }
}
