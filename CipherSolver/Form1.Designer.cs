namespace CipherSolver
{
    partial class Form1
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
            this.inputText = new System.Windows.Forms.TextBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.ciphersBox = new System.Windows.Forms.ComboBox();
            this.decodeButton = new System.Windows.Forms.Button();
            this.encodeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.shiftText = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(12, 42);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(250, 375);
            this.inputText.TabIndex = 0;
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(547, 42);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(250, 375);
            this.outputText.TabIndex = 1;
            // 
            // ciphersBox
            // 
            this.ciphersBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ciphersBox.FormattingEnabled = true;
            this.ciphersBox.Items.AddRange(new object[] {
            "Caesar",
            "Atbash",
            "A1Z26",
            "Vigenere",
            "Modified Affine"});
            this.ciphersBox.Location = new System.Drawing.Point(292, 42);
            this.ciphersBox.Name = "ciphersBox";
            this.ciphersBox.Size = new System.Drawing.Size(232, 21);
            this.ciphersBox.TabIndex = 2;
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(352, 394);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(110, 23);
            this.decodeButton.TabIndex = 3;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(352, 353);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(110, 23);
            this.encodeButton.TabIndex = 4;
            this.encodeButton.Text = "Encode";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(292, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Shift:";
            // 
            // shiftText
            // 
            this.shiftText.Location = new System.Drawing.Point(332, 84);
            this.shiftText.Name = "shiftText";
            this.shiftText.Size = new System.Drawing.Size(100, 20);
            this.shiftText.TabIndex = 6;
            this.shiftText.Text = "0";
            this.shiftText.TextChanged += new System.EventHandler(this.shiftText_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(292, 111);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(34, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Key:";
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(332, 110);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(100, 20);
            this.keyText.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 461);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.shiftText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.ciphersBox);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.inputText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.ComboBox ciphersBox;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox shiftText;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox keyText;
    }
}