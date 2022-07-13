namespace FinalProject_Phase1
{
    partial class FormHotelSelection
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
            this.lstBxRoomType = new System.Windows.Forms.ListBox();
            this.lstBxHotelLocation = new System.Windows.Forms.ListBox();
            this.dateTimePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerArrival = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblReceipt = new System.Windows.Forms.Label();
            this.picBxRoom = new System.Windows.Forms.PictureBox();
            this.picBxHotel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBxRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxHotel)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBxRoomType
            // 
            this.lstBxRoomType.FormattingEnabled = true;
            this.lstBxRoomType.Items.AddRange(new object[] {
            "1 King Bed",
            "2 Queen Beds",
            "1 Bedroom Suite"});
            this.lstBxRoomType.Location = new System.Drawing.Point(111, 112);
            this.lstBxRoomType.Name = "lstBxRoomType";
            this.lstBxRoomType.Size = new System.Drawing.Size(202, 43);
            this.lstBxRoomType.TabIndex = 32;
            this.lstBxRoomType.SelectedIndexChanged += new System.EventHandler(this.lstBxRoomType_SelectedIndexChanged_1);
            // 
            // lstBxHotelLocation
            // 
            this.lstBxHotelLocation.FormattingEnabled = true;
            this.lstBxHotelLocation.Items.AddRange(new object[] {
            "Miami",
            "Fort Lauderdale",
            "Orlando"});
            this.lstBxHotelLocation.Location = new System.Drawing.Point(111, 63);
            this.lstBxHotelLocation.Name = "lstBxHotelLocation";
            this.lstBxHotelLocation.Size = new System.Drawing.Size(202, 43);
            this.lstBxHotelLocation.TabIndex = 31;
            this.lstBxHotelLocation.SelectedIndexChanged += new System.EventHandler(this.lstBxHotelLocation_SelectedIndexChanged);
            // 
            // dateTimePickerDeparture
            // 
            this.dateTimePickerDeparture.Location = new System.Drawing.Point(113, 214);
            this.dateTimePickerDeparture.MinDate = new System.DateTime(2021, 4, 3, 0, 0, 0, 0);
            this.dateTimePickerDeparture.Name = "dateTimePickerDeparture";
            this.dateTimePickerDeparture.Size = new System.Drawing.Size(189, 20);
            this.dateTimePickerDeparture.TabIndex = 30;
            this.dateTimePickerDeparture.Value = new System.DateTime(2021, 4, 3, 0, 0, 0, 0);
            this.dateTimePickerDeparture.ValueChanged += new System.EventHandler(this.dateTimePickerDeparture_ValueChanged);
            // 
            // dateTimePickerArrival
            // 
            this.dateTimePickerArrival.Location = new System.Drawing.Point(111, 169);
            this.dateTimePickerArrival.MinDate = new System.DateTime(2021, 4, 3, 0, 0, 0, 0);
            this.dateTimePickerArrival.Name = "dateTimePickerArrival";
            this.dateTimePickerArrival.Size = new System.Drawing.Size(189, 20);
            this.dateTimePickerArrival.TabIndex = 29;
            this.dateTimePickerArrival.Value = new System.DateTime(2021, 4, 3, 0, 0, 0, 0);
            this.dateTimePickerArrival.ValueChanged += new System.EventHandler(this.dateTimePickerArrival_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Departure Date";
//            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Arrival Date";
        //    this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Room Type";
         //   this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Hotel Location";
          //  this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(57, 279);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(59, 13);
            this.lblInfo.TabIndex = 33;
            this.lblInfo.Text = "Hotel Info: ";
           // this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(215, 435);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(134, 39);
            this.btnNext.TabIndex = 34;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(43, 435);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 45);
            this.btnBack.TabIndex = 35;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblReceipt
            // 
            this.lblReceipt.AutoSize = true;
            this.lblReceipt.Location = new System.Drawing.Point(57, 302);
            this.lblReceipt.Name = "lblReceipt";
            this.lblReceipt.Size = new System.Drawing.Size(19, 13);
            this.lblReceipt.TabIndex = 38;
            this.lblReceipt.Text = "<>";
           // this.lblReceipt.Click += new System.EventHandler(this.lblReceipt_Click);
            // 
            // picBxRoom
            // 
            this.picBxRoom.Location = new System.Drawing.Point(415, 311);
            this.picBxRoom.Name = "picBxRoom";
            this.picBxRoom.Size = new System.Drawing.Size(466, 280);
            this.picBxRoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxRoom.TabIndex = 37;
            this.picBxRoom.TabStop = false;
          //  this.picBxRoom.Click += new System.EventHandler(this.picBxRoom_Click);
            // 
            // picBxHotel
            // 
            this.picBxHotel.Location = new System.Drawing.Point(415, 38);
            this.picBxHotel.Name = "picBxHotel";
            this.picBxHotel.Size = new System.Drawing.Size(466, 267);
            this.picBxHotel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxHotel.TabIndex = 36;
            this.picBxHotel.TabStop = false;
          //  this.picBxHotel.Click += new System.EventHandler(this.picBxHotel_Click);
            // 
            // FormHotelSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 615);
            this.Controls.Add(this.lblReceipt);
            this.Controls.Add(this.picBxRoom);
            this.Controls.Add(this.picBxHotel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lstBxRoomType);
            this.Controls.Add(this.lstBxHotelLocation);
            this.Controls.Add(this.dateTimePickerDeparture);
            this.Controls.Add(this.dateTimePickerArrival);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormHotelSelection";
            this.Text = "Hotel Selection";
            ((System.ComponentModel.ISupportInitialize)(this.picBxRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxHotel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBxRoomType;
        private System.Windows.Forms.ListBox lstBxHotelLocation;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeparture;
        private System.Windows.Forms.DateTimePicker dateTimePickerArrival;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox picBxHotel;
        private System.Windows.Forms.PictureBox picBxRoom;
        private System.Windows.Forms.Label lblReceipt;
    }
}