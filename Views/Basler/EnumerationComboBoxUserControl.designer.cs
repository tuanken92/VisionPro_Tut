namespace PylonLiveViewControl
{
    partial class EnumerationComboBoxUserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // comboBox
            //
            this.comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Enabled = false;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point( 4, 26 );
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size( 143, 21 );
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectedIndexChanged += new System.EventHandler( this.comboBox_SelectedIndexChanged );
            //
            // labelName
            //
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point( 4, 11 );
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size( 27, 13 );
            this.labelName.TabIndex = 1;
            this.labelName.Text = "N/A";
            //
            // EnumerationComboBoxUserControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.labelName );
            this.Controls.Add( this.comboBox );
            this.Name = "EnumerationComboBoxUserControl";
            this.Size = new System.Drawing.Size( 150, 57 );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label labelName;
    }
}
