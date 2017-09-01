namespace WinAppExtCITS
{
    partial class MainUI
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.serverUrl = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.connectIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.connectIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.DodgerBlue;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.Color.White;
            this.start.Location = new System.Drawing.Point(38, 76);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(96, 35);
            this.start.TabIndex = 0;
            this.start.Text = "Start Spy";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.DodgerBlue;
            this.stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.ForeColor = System.Drawing.Color.White;
            this.stop.Location = new System.Drawing.Point(140, 76);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(88, 35);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop Spy";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // serverUrl
            // 
            this.serverUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverUrl.Location = new System.Drawing.Point(38, 26);
            this.serverUrl.Name = "serverUrl";
            this.serverUrl.Size = new System.Drawing.Size(190, 24);
            this.serverUrl.TabIndex = 2;
            this.serverUrl.Text = "wss://localhost:8887";
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.Color.White;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Location = new System.Drawing.Point(243, 24);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(67, 28);
            this.connect.TabIndex = 3;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // connectIcon
            // 
            this.connectIcon.Image = global::WinAppExtCITS.Properties.Resources.error;
            this.connectIcon.Location = new System.Drawing.Point(316, 26);
            this.connectIcon.Name = "connectIcon";
            this.connectIcon.Size = new System.Drawing.Size(16, 16);
            this.connectIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.connectIcon.TabIndex = 4;
            this.connectIcon.TabStop = false;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 150);
            this.Controls.Add(this.connectIcon);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.serverUrl);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.MaximizeBox = false;
            this.Name = "MainUI";
            this.Text = "WinAppExtCITS";
            ((System.ComponentModel.ISupportInitialize)(this.connectIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox serverUrl;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.PictureBox connectIcon;
    }
}

