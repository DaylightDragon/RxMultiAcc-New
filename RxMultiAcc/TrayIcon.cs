using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using static RbxMultiAcc.MainClass;
using static RbxMultiAcc.Texts;

namespace RbxMultiAcc {
    internal class TrayIcon {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;

        public void Init() {
            contextMenu = new ContextMenuStrip();
            var exitItem = new ToolStripMenuItem(
                Texts.TranslateTrayIconExitButtonText(),
                null,
                Exit_Click
                );
            contextMenu.Items.Add(exitItem);

            notifyIcon = new NotifyIcon {
                Icon = Properties.Resources.MainIcon,
                ContextMenuStrip = contextMenu,
                Visible = true,
                Text = Texts.TranslateTrayIconDescription()
            };

            notifyIcon.MouseClick += NotifyIcon_MouseClick;
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                //MessageBox.Show("The icon has been clicked");
            }
        }

        private void Exit_Click(object sender, EventArgs e) {
            notifyIcon.Dispose();
            MainClass.ExitApplication();
        }
    }
}
