namespace ProductLableGeneration
{
    partial class AddProductForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGrossWTDOWN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNETDOWN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSupplierAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEngineeringChange = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQuantityDown = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQuantityUp = new System.Windows.Forms.TextBox();
            this.txtPN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQuantityForOneContainer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNETWTUP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtGrossWTUP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(457, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 19;
            this.button2.Text = "CACEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(31, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "RECEIVER : ";
            // 
            // txtReceiver
            // 
            this.txtReceiver.Location = new System.Drawing.Point(180, 100);
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(379, 20);
            this.txtReceiver.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PART NUMBER (11 digits):";
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Location = new System.Drawing.Point(239, 70);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(320, 20);
            this.txtPartNumber.TabIndex = 1;
            this.txtPartNumber.Leave += new System.EventHandler(this.txtPartNumber_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(272, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "NO BOXES : ";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(457, 196);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(102, 20);
            this.txtBox.TabIndex = 6;
            this.txtBox.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(272, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "GROSS WT DOWN (kg) : ";
            // 
            // txtGrossWTDOWN
            // 
            this.txtGrossWTDOWN.Location = new System.Drawing.Point(457, 166);
            this.txtGrossWTDOWN.Name = "txtGrossWTDOWN";
            this.txtGrossWTDOWN.Size = new System.Drawing.Size(102, 20);
            this.txtGrossWTDOWN.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(31, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "NET WT DOWN (kg) : ";
            // 
            // txtNETDOWN
            // 
            this.txtNETDOWN.Location = new System.Drawing.Point(180, 164);
            this.txtNETDOWN.Name = "txtNETDOWN";
            this.txtNETDOWN.Size = new System.Drawing.Size(80, 20);
            this.txtNETDOWN.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(31, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "SUPPLIER ADDRESS :";
            // 
            // txtSupplierAddress
            // 
            this.txtSupplierAddress.Location = new System.Drawing.Point(218, 329);
            this.txtSupplierAddress.Name = "txtSupplierAddress";
            this.txtSupplierAddress.Size = new System.Drawing.Size(341, 20);
            this.txtSupplierAddress.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(31, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "DESCRIPTION :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(218, 364);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(341, 20);
            this.txtDescription.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(33, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "ENGINEERING CHANGE: ";
            // 
            // txtEngineeringChange
            // 
            this.txtEngineeringChange.Location = new System.Drawing.Point(293, 296);
            this.txtEngineeringChange.Name = "txtEngineeringChange";
            this.txtEngineeringChange.Size = new System.Drawing.Size(266, 20);
            this.txtEngineeringChange.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(31, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "SUPPLIER CODE : ";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(180, 195);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(80, 20);
            this.txtSupplierCode.TabIndex = 5;
            this.txtSupplierCode.Text = "0086205";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(274, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "QUANTITY DOWN : ";
            // 
            // txtQuantityDown
            // 
            this.txtQuantityDown.Location = new System.Drawing.Point(459, 230);
            this.txtQuantityDown.Name = "txtQuantityDown";
            this.txtQuantityDown.Size = new System.Drawing.Size(102, 20);
            this.txtQuantityDown.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(33, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "QUANTITY UP : ";
            // 
            // txtQuantityUp
            // 
            this.txtQuantityUp.Location = new System.Drawing.Point(182, 230);
            this.txtQuantityUp.Name = "txtQuantityUp";
            this.txtQuantityUp.Size = new System.Drawing.Size(78, 20);
            this.txtQuantityUp.TabIndex = 7;
            // 
            // txtPN
            // 
            this.txtPN.Location = new System.Drawing.Point(180, 40);
            this.txtPN.Name = "txtPN";
            this.txtPN.Size = new System.Drawing.Size(379, 20);
            this.txtPN.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(31, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "STW PN:";
            // 
            // txtQuantityForOneContainer
            // 
            this.txtQuantityForOneContainer.Location = new System.Drawing.Point(293, 263);
            this.txtQuantityForOneContainer.Name = "txtQuantityForOneContainer";
            this.txtQuantityForOneContainer.Size = new System.Drawing.Size(266, 20);
            this.txtQuantityForOneContainer.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(33, 263);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(254, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "QUANTITY OF ONE CONTAINER:";
            // 
            // txtNETWTUP
            // 
            this.txtNETWTUP.Location = new System.Drawing.Point(180, 131);
            this.txtNETWTUP.Name = "txtNETWTUP";
            this.txtNETWTUP.Size = new System.Drawing.Size(80, 20);
            this.txtNETWTUP.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(31, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 20);
            this.label14.TabIndex = 30;
            this.label14.Text = "NET WT UP (kg) : ";
            // 
            // txtGrossWTUP
            // 
            this.txtGrossWTUP.Location = new System.Drawing.Point(457, 133);
            this.txtGrossWTUP.Name = "txtGrossWTUP";
            this.txtGrossWTUP.Size = new System.Drawing.Size(102, 20);
            this.txtGrossWTUP.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(271, 131);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(165, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "GROSS WT UP (kg) : ";
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 454);
            this.Controls.Add(this.txtNETWTUP);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtGrossWTUP);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtQuantityForOneContainer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtQuantityUp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQuantityDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSupplierCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEngineeringChange);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSupplierAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNETDOWN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGrossWTDOWN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReceiver);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGrossWTDOWN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNETDOWN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSupplierAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEngineeringChange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtQuantityDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQuantityUp;
        private System.Windows.Forms.TextBox txtPN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtQuantityForOneContainer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNETWTUP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGrossWTUP;
        private System.Windows.Forms.Label label15;
    }
}