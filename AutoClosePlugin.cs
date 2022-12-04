using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Management;

[assembly: AssemblyTitle("Auto Close ACT")]
[assembly: AssemblyDescription("避免重复运行ACT，当游戏关闭时自动安全的关闭ACT")]
[assembly: AssemblyCompany("MapleRecall")]
[assembly: AssemblyVersion("192.168.1.4")]

namespace AutoClose_Plugin
{
    public class AutoClosePlugin : UserControl, IActPluginV1
    {
        #region Designer Created Code (Avoid editing)
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkPrevent = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxAutoKill = new System.Windows.Forms.CheckBox();
            this.checkBoxConfirm = new System.Windows.Forms.CheckBox();
            this.radioButtonSafe = new System.Windows.Forms.RadioButton();
            this.radioButtonFast = new System.Windows.Forms.RadioButton();
            this.radioButtonRu = new System.Windows.Forms.RadioButton();
            this.timerRoll = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.timerResponding = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkBoxResponding = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownResponding = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResponding)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkPrevent
            // 
            this.checkPrevent.AutoSize = true;
            this.checkPrevent.Checked = true;
            this.checkPrevent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPrevent.Location = new System.Drawing.Point(16, 19);
            this.checkPrevent.Name = "checkPrevent";
            this.checkPrevent.Size = new System.Drawing.Size(119, 17);
            this.checkPrevent.TabIndex = 0;
            this.checkPrevent.Text = "阻止重复启动ACT";
            this.checkPrevent.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "立刻关闭FF14并安全的退出ACT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxAutoKill
            // 
            this.checkBoxAutoKill.AutoSize = true;
            this.checkBoxAutoKill.Checked = true;
            this.checkBoxAutoKill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoKill.Location = new System.Drawing.Point(16, 42);
            this.checkBoxAutoKill.Name = "checkBoxAutoKill";
            this.checkBoxAutoKill.Size = new System.Drawing.Size(320, 17);
            this.checkBoxAutoKill.TabIndex = 2;
            this.checkBoxAutoKill.Text = "自动关闭ACT (游戏退出后自动关闭，目前只支持安全版)";
            this.checkBoxAutoKill.UseVisualStyleBackColor = true;
            // 
            // checkBoxConfirm
            // 
            this.checkBoxConfirm.AutoSize = true;
            this.checkBoxConfirm.Checked = true;
            this.checkBoxConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConfirm.Location = new System.Drawing.Point(16, 144);
            this.checkBoxConfirm.Name = "checkBoxConfirm";
            this.checkBoxConfirm.Size = new System.Drawing.Size(134, 17);
            this.checkBoxConfirm.TabIndex = 0;
            this.checkBoxConfirm.Text = "自动关闭前弹窗确认";
            this.checkBoxConfirm.UseVisualStyleBackColor = true;
            // 
            // radioButtonSafe
            // 
            this.radioButtonSafe.AutoSize = true;
            this.radioButtonSafe.Checked = true;
            this.radioButtonSafe.Location = new System.Drawing.Point(40, 65);
            this.radioButtonSafe.Name = "radioButtonSafe";
            this.radioButtonSafe.Size = new System.Drawing.Size(145, 17);
            this.radioButtonSafe.TabIndex = 4;
            this.radioButtonSafe.TabStop = true;
            this.radioButtonSafe.Text = "安全版（不会炸配置）";
            this.radioButtonSafe.UseVisualStyleBackColor = true;
            // 
            // radioButtonFast
            // 
            this.radioButtonFast.AutoSize = true;
            this.radioButtonFast.Enabled = false;
            this.radioButtonFast.Location = new System.Drawing.Point(40, 88);
            this.radioButtonFast.Name = "radioButtonFast";
            this.radioButtonFast.Size = new System.Drawing.Size(145, 17);
            this.radioButtonFast.TabIndex = 5;
            this.radioButtonFast.Text = "急速版（可能炸配置）";
            this.radioButtonFast.UseVisualStyleBackColor = true;
            // 
            // radioButtonRu
            // 
            this.radioButtonRu.AutoSize = true;
            this.radioButtonRu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioButtonRu.Enabled = false;
            this.radioButtonRu.Location = new System.Drawing.Point(40, 111);
            this.radioButtonRu.Name = "radioButtonRu";
            this.radioButtonRu.Size = new System.Drawing.Size(97, 17);
            this.radioButtonRu.TabIndex = 6;
            this.radioButtonRu.Text = "俄罗斯轮盘版";
            this.radioButtonRu.UseVisualStyleBackColor = false;
            // 
            // timerRoll
            // 
            this.timerRoll.Tick += new System.EventHandler(this.timerRoll_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 43);
            this.button2.TabIndex = 7;
            this.button2.Text = "立刻关闭FF14但不关闭ACT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timerResponding
            // 
            this.timerResponding.Enabled = true;
            this.timerResponding.Interval = 1000;
            this.timerResponding.Tick += new System.EventHandler(this.timerResponding_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // checkBoxResponding
            // 
            this.checkBoxResponding.AutoSize = true;
            this.checkBoxResponding.Location = new System.Drawing.Point(16, 19);
            this.checkBoxResponding.Name = "checkBoxResponding";
            this.checkBoxResponding.Size = new System.Drawing.Size(158, 17);
            this.checkBoxResponding.TabIndex = 0;
            this.checkBoxResponding.Text = "自动结束停止响应的游戏";
            this.checkBoxResponding.UseVisualStyleBackColor = true;
            this.checkBoxResponding.CheckedChanged += new System.EventHandler(this.checkBoxResponding_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "阈值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "秒（游戏刚启动2分钟内不会生效）";
            // 
            // numericUpDownResponding
            // 
            this.numericUpDownResponding.Location = new System.Drawing.Point(50, 42);
            this.numericUpDownResponding.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownResponding.Name = "numericUpDownResponding";
            this.numericUpDownResponding.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownResponding.TabIndex = 11;
            this.numericUpDownResponding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownResponding.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkPrevent);
            this.groupBox1.Controls.Add(this.checkBoxAutoKill);
            this.groupBox1.Controls.Add(this.checkBoxConfirm);
            this.groupBox1.Controls.Add(this.radioButtonSafe);
            this.groupBox1.Controls.Add(this.radioButtonFast);
            this.groupBox1.Controls.Add(this.radioButtonRu);
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 171);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxResponding);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDownResponding);
            this.groupBox2.Location = new System.Drawing.Point(3, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 71);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FFXIV";
            // 
            // AutoClosePlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "AutoClosePlugin";
            this.Size = new System.Drawing.Size(537, 364);
            this.VisibleChanged += new System.EventHandler(this.AutoClosePlugin_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResponding)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CheckBox checkPrevent;
        private Button button1;
        private CheckBox checkBoxAutoKill;
        private CheckBox checkBoxConfirm;
        private RadioButton radioButtonSafe;
        private RadioButton radioButtonFast;
        private RadioButton radioButtonRu;
        private System.Windows.Forms.Timer timerRoll;
        private System.Windows.Forms.Timer timerResponding;
        private ContextMenuStrip contextMenuStrip1;
        private CheckBox checkBoxResponding;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDownResponding;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button2;

        #endregion
        public AutoClosePlugin()
        {
            InitializeComponent();
        }

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        readonly string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\AutoClose.config.xml");
        SettingsSerializer xmlSettings;

        private int rbx;
        private int rby;
        private bool isFFIVRunning => Process.GetProcessesByName("ffxiv_dx11")?.Length > 0 || Process.GetProcessesByName("ffxiv")?.Length > 0;
        private bool isFFXIVHasRun;

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginScreenSpace.Text = "AutoClose";
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
            LoadSettings();

            timerResponding.Enabled = checkBoxResponding.Checked;

            isFFXIVHasRun = isFFIVRunning;

            rbx = radioButtonRu.Location.X;
            rby = radioButtonRu.Location.Y;

            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);

            WaitForProcessStart();
            WaitForProcessEnd();

            lblStatus.Text = "在跑了在跑了";
        }

        public void DeInitPlugin()
        {
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;

            SaveSettings();
            startWatch.Stop();
            stopWatch.Stop();
            lblStatus.Text = "歇了";
        }
        #endregion

        void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
            //throw new NotImplementedException();
        }

        void LoadSettings()
        {
            // Add any controls you want to save the state of
            xmlSettings.AddControlSetting(checkPrevent.Name, checkPrevent);
            xmlSettings.AddControlSetting(checkBoxAutoKill.Name, checkBoxAutoKill);
            xmlSettings.AddControlSetting(checkBoxConfirm.Name, checkBoxConfirm);
            xmlSettings.AddControlSetting(checkBoxResponding.Name, checkBoxResponding);
            xmlSettings.AddControlSetting(numericUpDownResponding.Name, numericUpDownResponding);

            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }
        }

        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
            xWriter.WriteEndElement();  // </SettingsSerializer>
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }

        ManagementEventWatcher startWatch;
        ManagementEventWatcher stopWatch;

        void WaitForProcessStart()
        {
            startWatch = new ManagementEventWatcher(
              new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
            startWatch.Start();
        }

        void WaitForProcessEnd()
        {
            stopWatch = new ManagementEventWatcher(
              new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            stopWatch.EventArrived += new EventArrivedEventHandler(stopWatch_EventArrived);
            stopWatch.Start();
        }

        HashSet<string> checkList = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "点我启动ACT.exe", "CafeACT.exe", "Advanced Combat Tracker.exe" };
        HashSet<string> gameList = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "ffxiv.exe", "ffxiv_dx11.exe" };

        void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                var pn = e.NewEvent.Properties["ProcessName"].Value;
                var pid = e.NewEvent.Properties["ProcessID"].Value;
                if (checkPrevent.Checked && checkList.Contains((string)pn))
                {
                    Console.WriteLine($"Process started: {pid} {pn}");
                    Console.WriteLine("Process started: {0}", pid);
                    var process = Process.GetProcessById(Convert.ToInt32(pid));
                    if (process != null)
                    {
                        process.Kill();
                        ActGlobals.oFormActMain.Activate();
                    }
                    Console.WriteLine("Process started: {0}", e.NewEvent.Properties["ProcessName"].Value);
                }

                if (gameList.Contains((string)pn))
                {
                    isFFXIVHasRun = true;
                }
            }
            finally { };
        }

        void stopWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                var pn = e.NewEvent.Properties["ProcessName"].Value;

                if (checkBoxAutoKill.Checked && isFFXIVHasRun && gameList.Contains((string)pn) && !isFFIVRunning)
                {
                    if (checkBoxConfirm.Checked && MessageBox.Show("退？", "无了！", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        isFFXIVHasRun = false;
                        return;
                    }

                    startWatch.Stop();
                    stopWatch.Stop();
                    ActGlobals.oFormActMain.Close();
                }
            }
            finally { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            ActGlobals.oFormActMain.Close();
        }

        private void timerRoll_Tick(object sender, EventArgs e)
        {
            var rd = new Random();
            radioButtonRu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rd.Next(128, 255))))), ((int)(((byte)(rd.Next(128, 255))))), ((int)(((byte)(rd.Next(128, 255))))));
            radioButtonRu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(rd.Next(64, 192))))), ((int)(((byte)(rd.Next(64, 192))))), ((int)(((byte)(rd.Next(64, 192))))));
            radioButtonRu.Location = new System.Drawing.Point(rbx + rd.Next(-3, 4), rby + rd.Next(-3, 4));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isFFXIVHasRun = false;
            Process.GetProcessesByName("ffxiv_dx11").ToList().ForEach(p => { try { p.Kill(); } finally { } });
            Process.GetProcessesByName("ffxiv").ToList().ForEach(p => { try { p.Kill(); } finally { } });
        }

        private void AutoClosePlugin_VisibleChanged(object sender, EventArgs e)
        {
            timerRoll.Enabled = this.Visible;
        }

        private void timerResponding_Tick(object sender, EventArgs e)
        {
            Process.GetProcessesByName("ffxiv_dx11").ToList().ForEach(p =>
            {
                var processRunningTime = DateTime.Now - p.StartTime;

                if (processRunningTime.TotalMinutes < 2)
                {
                    return;
                }

                var task = Task.Factory.StartNew(() => p.Responding);
                var processResponding = task.Wait((int)(numericUpDownResponding.Value * 1000)) && task.Result;


                if (!processResponding)
                {
                    try
                    {
                        p.Kill();
                        MessageBox.Show("FFXIV卡死了，杀掉杀掉！");
                    }
                    catch (Exception) { }
                }
            });
        }

        private void checkBoxResponding_CheckedChanged(object sender, EventArgs e)
        {
            timerResponding.Enabled = checkBoxResponding.Checked;
        }
    }
}
