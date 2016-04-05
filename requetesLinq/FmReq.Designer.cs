namespace requetesLinq
{
    partial class FmReq
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbRequete = new System.Windows.Forms.ComboBox();
            this.btOk = new System.Windows.Forms.Button();
            this.tbResultat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbRequete
            // 
            this.cbRequete.FormattingEnabled = true;
            this.cbRequete.Location = new System.Drawing.Point(25, 40);
            this.cbRequete.Name = "cbRequete";
            this.cbRequete.Size = new System.Drawing.Size(558, 21);
            this.cbRequete.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(603, 40);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(83, 21);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // tbResultat
            // 
            this.tbResultat.Location = new System.Drawing.Point(12, 82);
            this.tbResultat.Multiline = true;
            this.tbResultat.Name = "tbResultat";
            this.tbResultat.Size = new System.Drawing.Size(674, 316);
            this.tbResultat.TabIndex = 2;
            // 
            // FmReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 426);
            this.Controls.Add(this.tbResultat);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.cbRequete);
            this.Name = "FmReq";
            this.Text = "Requêtes Linq Asdomi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRequete;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.TextBox tbResultat;
    }
}

