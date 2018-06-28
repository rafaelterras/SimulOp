namespace SimulOP.Forms
{
    partial class FormsPopOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormsPopOut));
            this.txbAjuda = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbAjuda
            // 
            this.txbAjuda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAjuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbAjuda.CausesValidation = false;
            this.txbAjuda.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAjuda.Location = new System.Drawing.Point(12, 12);
            this.txbAjuda.Multiline = true;
            this.txbAjuda.Name = "txbAjuda";
            this.txbAjuda.ReadOnly = true;
            this.txbAjuda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbAjuda.Size = new System.Drawing.Size(331, 240);
            this.txbAjuda.TabIndex = 0;
            this.txbAjuda.Text = resources.GetString("txbAjuda.Text");
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Location = new System.Drawing.Point(268, 258);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormsPopOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 284);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txbAjuda);
            this.MaximumSize = new System.Drawing.Size(586, 483);
            this.MinimumSize = new System.Drawing.Size(367, 323);
            this.Name = "FormsPopOut";
            this.Text = "FormsPopOut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAjuda;
        private System.Windows.Forms.Button btnOK;
    }
}