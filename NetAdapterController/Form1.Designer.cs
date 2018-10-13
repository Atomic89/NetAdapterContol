namespace NetAdapterController
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.adaptersListTextBox = new System.Windows.Forms.RichTextBox();
            this.searchAdapters = new System.Windows.Forms.Button();
            this.IdDeviceTextBox = new System.Windows.Forms.TextBox();
            this.IdDevice = new System.Windows.Forms.Label();
            this.EnableButton = new System.Windows.Forms.Button();
            this.DisableButton = new System.Windows.Forms.Button();
            this.ConnectionStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // adaptersListTextBox
            // 
            this.adaptersListTextBox.Location = new System.Drawing.Point(12, 12);
            this.adaptersListTextBox.Name = "adaptersListTextBox";
            this.adaptersListTextBox.Size = new System.Drawing.Size(313, 313);
            this.adaptersListTextBox.TabIndex = 0;
            this.adaptersListTextBox.Text = "";
            // 
            // searchAdapters
            // 
            this.searchAdapters.Location = new System.Drawing.Point(106, 331);
            this.searchAdapters.Name = "searchAdapters";
            this.searchAdapters.Size = new System.Drawing.Size(111, 23);
            this.searchAdapters.TabIndex = 1;
            this.searchAdapters.Text = "Найти адаптеры";
            this.searchAdapters.UseVisualStyleBackColor = true;
            this.searchAdapters.Click += new System.EventHandler(this.searchAdapters_Click);
            // 
            // IdDeviceTextBox
            // 
            this.IdDeviceTextBox.Location = new System.Drawing.Point(377, 41);
            this.IdDeviceTextBox.Name = "IdDeviceTextBox";
            this.IdDeviceTextBox.Size = new System.Drawing.Size(43, 20);
            this.IdDeviceTextBox.TabIndex = 2;
            // 
            // IdDevice
            // 
            this.IdDevice.AutoSize = true;
            this.IdDevice.Location = new System.Drawing.Point(331, 15);
            this.IdDevice.Name = "IdDevice";
            this.IdDevice.Size = new System.Drawing.Size(148, 13);
            this.IdDevice.TabIndex = 3;
            this.IdDevice.Text = "Id устройства для операции";
            // 
            // EnableButton
            // 
            this.EnableButton.Location = new System.Drawing.Point(331, 78);
            this.EnableButton.Name = "EnableButton";
            this.EnableButton.Size = new System.Drawing.Size(75, 20);
            this.EnableButton.TabIndex = 4;
            this.EnableButton.Text = "Включить";
            this.EnableButton.UseVisualStyleBackColor = true;
            this.EnableButton.Click += new System.EventHandler(this.EnableButton_Click);
            // 
            // DisableButton
            // 
            this.DisableButton.Location = new System.Drawing.Point(412, 78);
            this.DisableButton.Name = "DisableButton";
            this.DisableButton.Size = new System.Drawing.Size(73, 20);
            this.DisableButton.TabIndex = 5;
            this.DisableButton.Text = "Выключить";
            this.DisableButton.UseVisualStyleBackColor = true;
            this.DisableButton.Click += new System.EventHandler(this.DisableButton_Click);
            // 
            // ConnectionStatus
            // 
            this.ConnectionStatus.AutoSize = true;
            this.ConnectionStatus.Location = new System.Drawing.Point(393, 118);
            this.ConnectionStatus.Name = "ConnectionStatus";
            this.ConnectionStatus.Size = new System.Drawing.Size(0, 13);
            this.ConnectionStatus.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 403);
            this.Controls.Add(this.ConnectionStatus);
            this.Controls.Add(this.DisableButton);
            this.Controls.Add(this.EnableButton);
            this.Controls.Add(this.IdDevice);
            this.Controls.Add(this.IdDeviceTextBox);
            this.Controls.Add(this.searchAdapters);
            this.Controls.Add(this.adaptersListTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox adaptersListTextBox;
        private System.Windows.Forms.Button searchAdapters;
        private System.Windows.Forms.TextBox IdDeviceTextBox;
        private System.Windows.Forms.Label IdDevice;
        private System.Windows.Forms.Button EnableButton;
        private System.Windows.Forms.Button DisableButton;
        private System.Windows.Forms.Label ConnectionStatus;
    }
}

