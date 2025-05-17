using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace LicenseAgreementApp
{
    public class MainForm : Form
    {
        private RichTextBox richTextBoxAgreement;
        private CheckBox checkBoxAgree;
        private Button buttonConfirm;

        public MainForm()
        {
            InitializeComponent();
            LoadTextFile();
        }

        private void InitializeComponent()
        {
            this.Text = "License Agreement";
            this.Width = 600;
            this.Height = 400;

            richTextBoxAgreement = new RichTextBox
            {
                Name = "LicenseTextBox",
                AccessibleName = "License Agreement Text",
                AccessibleDescription = "Displays the license agreement text for review.",
                AccessibleRole = AccessibleRole.Document,
                Multiline = true,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                ReadOnly = true,
                BackColor = SystemColors.Window,
                Width = 550,
                Height = 250,
                Top = 20,
                Left = 20,
                TabStop = true,  // Ensure it can receive focus
                ShortcutsEnabled = true  // Enable keyboard shortcuts for accessibility
            };

            checkBoxAgree = new CheckBox
            {
                Text = "I Agree",
                Left = 20,
                Top = 280,
                AccessibleName = "Accept License Agreement",
                AccessibleDescription = "Check this box to accept the license agreement."
            };

            buttonConfirm = new Button
            {
                Text = "Confirm",
                Left = 20,
                Top = 320,
                Width = 100,
                AccessibleName = "Confirm",
                AccessibleDescription = "Click to confirm your choice and continue."
            };
            buttonConfirm.Click += ButtonConfirm_Click;

            this.Controls.Add(richTextBoxAgreement);
            this.Controls.Add(checkBoxAgree);
            this.Controls.Add(buttonConfirm);
        }

        private void LoadTextFile()
        {
            string filePath = "../MSIX_LICENSE.txt";
            if (File.Exists(filePath))
            {
                richTextBoxAgreement.Text = File.ReadAllText(filePath);
                // Set cursor to beginning for screen readers
                richTextBoxAgreement.SelectionStart = 0;
                richTextBoxAgreement.SelectionLength = 0;
            }
            else
            {
                richTextBoxAgreement.Text = "License file not found!";
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (checkBoxAgree.Checked)
            {
                MessageBox.Show("Thank you for accepting the agreement!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Please agree to continue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}