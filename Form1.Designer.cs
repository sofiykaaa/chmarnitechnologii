namespace laba3
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
            this.FirstName = new System.Windows.Forms.Label();
            this.Fatherly = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.PhoneNumber = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.FatherlyBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.NumBox = new System.Windows.Forms.TextBox();
            this.AddContact = new System.Windows.Forms.Button();
            this.TableGrid = new System.Windows.Forms.DataGridView();
            this.DeleteContact = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.CreateContainer = new System.Windows.Forms.Button();
            this.UpdatePhoto = new System.Windows.Forms.Button();
            this.Download = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Location = new System.Drawing.Point(51, 43);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(69, 16);
            this.FirstName.TabIndex = 0;
            this.FirstName.Text = "FirstName";
            this.FirstName.Click += new System.EventHandler(this.FirstName_Click);
            // 
            // Fatherly
            // 
            this.Fatherly.AutoSize = true;
            this.Fatherly.Location = new System.Drawing.Point(51, 71);
            this.Fatherly.Name = "Fatherly";
            this.Fatherly.Size = new System.Drawing.Size(55, 16);
            this.Fatherly.TabIndex = 1;
            this.Fatherly.Text = "Fatherly";
            this.Fatherly.Click += new System.EventHandler(this.Fatherly_Click);
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Location = new System.Drawing.Point(51, 99);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(69, 16);
            this.LastName.TabIndex = 2;
            this.LastName.Text = "LastName";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(51, 127);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(58, 16);
            this.Address.TabIndex = 3;
            this.Address.Text = "Address";
            this.Address.Click += new System.EventHandler(this.Address_Click);
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSize = true;
            this.PhoneNumber.Location = new System.Drawing.Point(51, 155);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(94, 16);
            this.PhoneNumber.TabIndex = 4;
            this.PhoneNumber.Text = "PhoneNumber";
            this.PhoneNumber.Click += new System.EventHandler(this.PhoneNumber_Click);
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Location = new System.Drawing.Point(169, 37);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(100, 22);
            this.FirstNameBox.TabIndex = 5;
            this.FirstNameBox.TextChanged += new System.EventHandler(this.FirstNameBox_TextChanged);
            // 
            // FatherlyBox
            // 
            this.FatherlyBox.Location = new System.Drawing.Point(169, 65);
            this.FatherlyBox.Name = "FatherlyBox";
            this.FatherlyBox.Size = new System.Drawing.Size(100, 22);
            this.FatherlyBox.TabIndex = 6;
            this.FatherlyBox.TextChanged += new System.EventHandler(this.FatherlyBox_TextChanged);
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(169, 93);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(100, 22);
            this.LastNameBox.TabIndex = 7;
            this.LastNameBox.TextChanged += new System.EventHandler(this.LastNameBox_TextChanged);
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(169, 121);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(100, 22);
            this.AddressBox.TabIndex = 8;
            this.AddressBox.TextChanged += new System.EventHandler(this.AddressBox_TextChanged);
            // 
            // NumBox
            // 
            this.NumBox.Location = new System.Drawing.Point(169, 149);
            this.NumBox.Name = "NumBox";
            this.NumBox.Size = new System.Drawing.Size(100, 22);
            this.NumBox.TabIndex = 9;
            this.NumBox.TextChanged += new System.EventHandler(this.NumBox_TextChanged);
            // 
            // AddContact
            // 
            this.AddContact.Location = new System.Drawing.Point(111, 211);
            this.AddContact.Name = "AddContact";
            this.AddContact.Size = new System.Drawing.Size(92, 23);
            this.AddContact.TabIndex = 10;
            this.AddContact.Text = "AddContact";
            this.AddContact.UseVisualStyleBackColor = true;
            this.AddContact.Click += new System.EventHandler(this.AddContact_Click);
            // 
            // TableGrid
            // 
            this.TableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableGrid.Location = new System.Drawing.Point(334, 37);
            this.TableGrid.Name = "TableGrid";
            this.TableGrid.RowHeadersWidth = 51;
            this.TableGrid.RowTemplate.Height = 24;
            this.TableGrid.Size = new System.Drawing.Size(365, 197);
            this.TableGrid.TabIndex = 11;
            this.TableGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableGrid_CellContentClick);
            // 
            // DeleteContact
            // 
            this.DeleteContact.Location = new System.Drawing.Point(209, 211);
            this.DeleteContact.Name = "DeleteContact";
            this.DeleteContact.Size = new System.Drawing.Size(119, 23);
            this.DeleteContact.TabIndex = 12;
            this.DeleteContact.Text = "DeleteContact";
            this.DeleteContact.UseVisualStyleBackColor = true;
            this.DeleteContact.Click += new System.EventHandler(this.DeleteContact_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(18, 211);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 13;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // CreateContainer
            // 
            this.CreateContainer.Location = new System.Drawing.Point(762, 37);
            this.CreateContainer.Name = "CreateContainer";
            this.CreateContainer.Size = new System.Drawing.Size(120, 47);
            this.CreateContainer.TabIndex = 14;
            this.CreateContainer.Text = "CreateContainer";
            this.CreateContainer.UseVisualStyleBackColor = true;
            this.CreateContainer.Click += new System.EventHandler(this.CreateContainer_Click);
            // 
            // UpdatePhoto
            // 
            this.UpdatePhoto.Location = new System.Drawing.Point(762, 109);
            this.UpdatePhoto.Name = "UpdatePhoto";
            this.UpdatePhoto.Size = new System.Drawing.Size(120, 47);
            this.UpdatePhoto.TabIndex = 15;
            this.UpdatePhoto.Text = "UploadPhoto";
            this.UpdatePhoto.UseVisualStyleBackColor = true;
            this.UpdatePhoto.Click += new System.EventHandler(this.UpdatePhoto_Click);
            // 
            // Download
            // 
            this.Download.Location = new System.Drawing.Point(762, 187);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(120, 47);
            this.Download.TabIndex = 16;
            this.Download.Text = "Download";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(762, 264);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(120, 47);
            this.Delete.TabIndex = 17;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(962, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 360);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.UpdatePhoto);
            this.Controls.Add(this.CreateContainer);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.DeleteContact);
            this.Controls.Add(this.TableGrid);
            this.Controls.Add(this.AddContact);
            this.Controls.Add(this.NumBox);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.FatherlyBox);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.PhoneNumber);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.Fatherly);
            this.Controls.Add(this.FirstName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label Fatherly;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label PhoneNumber;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.TextBox FatherlyBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.TextBox NumBox;
        private System.Windows.Forms.Button AddContact;
        private System.Windows.Forms.DataGridView TableGrid;
        private System.Windows.Forms.Button DeleteContact;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button CreateContainer;
        private System.Windows.Forms.Button UpdatePhoto;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

