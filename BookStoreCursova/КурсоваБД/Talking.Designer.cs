namespace КурсоваБД
{
    partial class Talking
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textLocalPort = new System.Windows.Forms.TextBox();
            this.textLocalIP = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textFriendPort = new System.Windows.Forms.TextBox();
            this.textFriendIP = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.attachBut = new System.Windows.Forms.Button();
            this.attach = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.smtp = new System.Windows.Forms.TextBox();
            this.subject = new System.Windows.Forms.TextBox();
            this.to = new System.Windows.Forms.TextBox();
            this.from = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.body = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textLocalPort);
            this.groupBox2.Controls.Add(this.textLocalIP);
            this.groupBox2.Enabled = false;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(11, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 108);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ви";
            // 
            // textLocalPort
            // 
            this.textLocalPort.Enabled = false;
            this.textLocalPort.Location = new System.Drawing.Point(80, 69);
            this.textLocalPort.Name = "textLocalPort";
            this.textLocalPort.Size = new System.Drawing.Size(94, 19);
            this.textLocalPort.TabIndex = 1;
            this.textLocalPort.Text = "81";
            // 
            // textLocalIP
            // 
            this.textLocalIP.Location = new System.Drawing.Point(80, 31);
            this.textLocalIP.Name = "textLocalIP";
            this.textLocalIP.Size = new System.Drawing.Size(94, 19);
            this.textLocalIP.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textFriendPort);
            this.groupBox3.Controls.Add(this.textFriendIP);
            this.groupBox3.Enabled = false;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(11, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 108);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Клієнт";
            // 
            // textFriendPort
            // 
            this.textFriendPort.Location = new System.Drawing.Point(80, 69);
            this.textFriendPort.Name = "textFriendPort";
            this.textFriendPort.Size = new System.Drawing.Size(94, 19);
            this.textFriendPort.TabIndex = 1;
            this.textFriendPort.Text = "80";
            // 
            // textFriendIP
            // 
            this.textFriendIP.Location = new System.Drawing.Point(80, 31);
            this.textFriendIP.Name = "textFriendIP";
            this.textFriendIP.Size = new System.Drawing.Size(94, 19);
            this.textFriendIP.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(228, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(176, 130);
            this.listBox1.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(277, 225);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 20;
            this.button4.Text = "З\'єднання";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(277, 263);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 25);
            this.button5.TabIndex = 21;
            this.button5.Text = "Відправити";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 169);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(393, 19);
            this.textBox1.TabIndex = 22;
            // 
            // attachBut
            // 
            this.attachBut.Location = new System.Drawing.Point(423, 178);
            this.attachBut.Name = "attachBut";
            this.attachBut.Size = new System.Drawing.Size(99, 27);
            this.attachBut.TabIndex = 38;
            this.attachBut.Text = "Прикріпити файл";
            this.attachBut.UseVisualStyleBackColor = true;
            this.attachBut.Click += new System.EventHandler(this.attachBut_Click);
            // 
            // attach
            // 
            this.attach.Location = new System.Drawing.Point(422, 210);
            this.attach.Name = "attach";
            this.attach.Size = new System.Drawing.Size(100, 19);
            this.attach.TabIndex = 37;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(617, 327);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 19);
            this.password.TabIndex = 36;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(617, 298);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 19);
            this.username.TabIndex = 35;
            // 
            // smtp
            // 
            this.smtp.Enabled = false;
            this.smtp.Location = new System.Drawing.Point(617, 270);
            this.smtp.Name = "smtp";
            this.smtp.Size = new System.Drawing.Size(100, 19);
            this.smtp.TabIndex = 34;
            this.smtp.Text = "smtp.gmail.com";
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(617, 240);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(100, 19);
            this.subject.TabIndex = 33;
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(617, 212);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(100, 19);
            this.to.TabIndex = 32;
            // 
            // from
            // 
            this.from.Enabled = false;
            this.from.Location = new System.Drawing.Point(617, 181);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(100, 19);
            this.from.TabIndex = 31;
            this.from.Text = "burevisnyk88@gmail.com";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(552, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 14);
            this.label12.TabIndex = 30;
            this.label12.Text = "Пароль";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(552, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 14);
            this.label11.TabIndex = 29;
            this.label11.Text = "Ім\'я користувача";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(552, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "Smtp сервер";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(552, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 14);
            this.label9.TabIndex = 27;
            this.label9.Text = "Тема";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(552, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 14);
            this.label8.TabIndex = 26;
            this.label8.Text = "До";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(552, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "Від";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(423, 303);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(99, 43);
            this.send.TabIndex = 24;
            this.send.Text = "Відіслати поідомлення";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // body
            // 
            this.body.Location = new System.Drawing.Point(423, 18);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(297, 153);
            this.body.TabIndex = 23;
            this.body.Text = "";
            // 
            // Talking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(754, 368);
            this.Controls.Add(this.attachBut);
            this.Controls.Add(this.attach);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.smtp);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.send);
            this.Controls.Add(this.body);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Talking";
            this.Load += new System.EventHandler(this.Jobs_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textLocalPort;
        private System.Windows.Forms.TextBox textLocalIP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textFriendPort;
        private System.Windows.Forms.TextBox textFriendIP;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button attachBut;
        private System.Windows.Forms.TextBox attach;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox smtp;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.TextBox from;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.RichTextBox body;

    }
}