using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace LicenseAgreementApp
{
    public class MainForm : Form
    {
        private RichTextBox richTextBoxAgreement;
        private CheckBox checkBoxAgree;
        private Button buttonConfirm;
        private System.Windows.Forms.Timer timeoutTimer; // Explicitly specify Windows.Forms.Timer
        private const int TIMEOUT_SECONDS = 55; // Less than 60 seconds to ensure completion

        public MainForm()
        {
            InitializeComponent();
            SetupTimeoutTimer();
            LoadTextFile();
        }

        private void SetupTimeoutTimer()
        {
            timeoutTimer = new System.Windows.Forms.Timer(); // Use fully qualified name
            timeoutTimer.Interval = TIMEOUT_SECONDS * 1000; // Convert to milliseconds
            timeoutTimer.Tick += (sender, e) =>
            {
                MessageBox.Show("The license agreement has timed out. Installation cannot continue.",
                    "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExitWithFailure("Timeout occurred waiting for user response");
            };
            timeoutTimer.Start();
        }

        private void InitializeComponent()
        {
            this.Text = "License Agreement";
            this.Width = 600;
            this.Height = 400;
            this.FormClosing += MainForm_FormClosing;

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
                TabStop = true,
                ShortcutsEnabled = true
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

            // Add a cancel button
            Button buttonCancel = new Button
            {
                Text = "Cancel",
                Left = 130,
                Top = 320,
                Width = 100,
                AccessibleName = "Cancel",
                AccessibleDescription = "Cancel the installation."
            };
            buttonCancel.Click += (sender, e) => ExitWithFailure("User canceled the agreement");

            this.Controls.Add(richTextBoxAgreement);
            this.Controls.Add(checkBoxAgree);
            this.Controls.Add(buttonConfirm);
            this.Controls.Add(buttonCancel);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ExitWithFailure("User closed the dialog");
                e.Cancel = true; // We'll handle the exit
            }
        }

        private void LoadTextFile()
        {
            try
            {
                string exeDir = Path.GetDirectoryName(Application.ExecutablePath);
                string filePath = Path.Combine(exeDir, "..", "MSIX_LICENSE.txt");
                if (File.Exists(filePath))
                {
                    richTextBoxAgreement.Text = File.ReadAllText(filePath);
                    // Set cursor to beginning for screen readers
                    richTextBoxAgreement.SelectionStart = 0;
                    richTextBoxAgreement.SelectionLength = 0;
                }
                else
                {
                    LogError("License file not found at path: " + Path.GetFullPath(filePath));
                    richTextBoxAgreement.Text = "License file not found! Installation cannot continue.";
                    checkBoxAgree.Enabled = false;
                    buttonConfirm.Enabled = false;
                    // Wait briefly to show the error message before exiting
                    Thread.Sleep(3000);
                    ExitWithFailure("License file not found");
                }
            }
            catch (Exception ex)
            {
                LogError("Error loading license file: " + ex.Message);
                ExitWithFailure("Error: " + ex.Message);
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            timeoutTimer.Stop();

            if (checkBoxAgree.Checked)
            {
                LogMessage("User accepted the agreement");
                ExitWithSuccess();
            }
            else
            {
                MessageBox.Show("Please agree to continue. Installation cannot proceed without accepting the license agreement.",
                    "Agreement Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LogMessage(string message)
        {
            try
            {
                string logPath = Path.Combine(Path.GetTempPath(), "license_agreement.log");
                File.AppendAllText(logPath, DateTime.Now + ": " + message + Environment.NewLine);
            }
            catch
            {
                // Silent failure for logging - shouldn't stop execution
            }
        }

        private void LogError(string error)
        {
            LogMessage("ERROR: " + error);
        }

        private void ExitWithSuccess()
        {
            LogMessage("Installation continuing - agreement accepted");
            Environment.Exit(0); // Success
        }

        private void ExitWithFailure(string reason)
        {
            LogMessage("Installation cancelled: " + reason);
            Environment.Exit(1); // Failure
        }

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                try
                {
                    File.AppendAllText("license_agreement.log",
                        DateTime.Now + ": CRITICAL ERROR: " + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                }
                catch
                {
                    // Can't even log the error
                }
                Environment.Exit(2); // Critical failure
            }
        }
    }
}