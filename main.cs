using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LH_EX_Launcher
{
    public class LH_Launcher : Form
    {
        // Магия для перетаскивания окна без рамки
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public LH_Launcher()
        {
            // Настройки окна
            this.Size = new Size(600, 350);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(15, 10, 25); // Глубокий фиолетово-черный
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Боковая панель ---
            Panel sideBar = new Panel { Width = 60, Dock = DockStyle.Left, BackColor = Color.FromArgb(20, 15, 35) };
            this.Controls.Add(sideBar);

            // Логотип LH
            Label logo = new Label {
                Text = "LH",
                ForeColor = Color.MediumPurple,
                Font = new Font("Arial Black", 20, FontStyle.Bold),
                Location = new Point(5, 15),
                AutoSize = true
            };
            sideBar.Controls.Add(logo);

            // --- Главный заголовок ---
            Label title = new Label {
                Text = "LH EXECUTOR SYSTEM v1.0",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(80, 20),
                AutoSize = true
            };
            this.Controls.Add(title);

            // --- Кнопка запуска (LAUNCH) ---
            Button launchBtn = new Button {
                Text = "LAUNCH ROBLOX 🚀",
                Size = new Size(250, 60),
                Location = new Point(200, 130),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(45, 25, 90),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            launchBtn.FlatAppearance.BorderSize = 2;
            launchBtn.FlatAppearance.BorderColor = Color.MediumPurple;
            launchBtn.Click += (s, e) => {
                try {
                    Process.Start("roblox-player:1"); // Запуск игры
                    MessageBox.Show("LH EX: Ожидание подключения к Roblox...", "LH RECORDS");
                } catch {
                    MessageBox.Show("Ошибка: Roblox не найден на ПК!", "LH RECORDS");
                }
            };
            this.Controls.Add(launchBtn);

            // --- Кнопка выхода ---
            Button closeBtn = new Button {
                Text = "✕",
                Size = new Size(30, 30),
                Location = new Point(560, 10),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.Click += (s, e) => Application.Exit();
            this.Controls.Add(closeBtn);

            // Подпись снизу
            Label footer = new Label {
                Text = "Developed by Azer for LH RECORDS",
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 8),
                Location = new Point(240, 320),
                AutoSize = true
            };
            this.Controls.Add(footer);

            // Позволяем таскать окно мышкой
            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left) {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LH_Launcher());
        }
    }
}
