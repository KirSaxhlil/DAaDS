
namespace Lab14
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
            this.tb_inputEnum = new System.Windows.Forms.TextBox();
            this.btn_BuildTree = new System.Windows.Forms.Button();
            this.pb_Tree = new System.Windows.Forms.PictureBox();
            this.btn_Processing = new System.Windows.Forms.Button();
            this.btn_Value = new System.Windows.Forms.Button();
            this.tb_Value = new System.Windows.Forms.TextBox();
            this.tb_Check = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SS_L_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tree)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_inputEnum
            // 
            this.tb_inputEnum.Location = new System.Drawing.Point(12, 12);
            this.tb_inputEnum.Name = "tb_inputEnum";
            this.tb_inputEnum.Size = new System.Drawing.Size(100, 20);
            this.tb_inputEnum.TabIndex = 0;
            // 
            // btn_BuildTree
            // 
            this.btn_BuildTree.Location = new System.Drawing.Point(118, 10);
            this.btn_BuildTree.Name = "btn_BuildTree";
            this.btn_BuildTree.Size = new System.Drawing.Size(75, 23);
            this.btn_BuildTree.TabIndex = 1;
            this.btn_BuildTree.Text = "Построить";
            this.btn_BuildTree.UseVisualStyleBackColor = true;
            this.btn_BuildTree.Click += new System.EventHandler(this.btn_BuildTree_Click);
            // 
            // pb_Tree
            // 
            this.pb_Tree.Location = new System.Drawing.Point(12, 38);
            this.pb_Tree.Name = "pb_Tree";
            this.pb_Tree.Size = new System.Drawing.Size(743, 356);
            this.pb_Tree.TabIndex = 2;
            this.pb_Tree.TabStop = false;
            // 
            // btn_Processing
            // 
            this.btn_Processing.Location = new System.Drawing.Point(237, 9);
            this.btn_Processing.Name = "btn_Processing";
            this.btn_Processing.Size = new System.Drawing.Size(75, 23);
            this.btn_Processing.TabIndex = 4;
            this.btn_Processing.Text = "Обработка";
            this.btn_Processing.UseVisualStyleBackColor = true;
            this.btn_Processing.Click += new System.EventHandler(this.btn_Processing_Click);
            // 
            // btn_Value
            // 
            this.btn_Value.Location = new System.Drawing.Point(458, 10);
            this.btn_Value.Name = "btn_Value";
            this.btn_Value.Size = new System.Drawing.Size(81, 23);
            this.btn_Value.TabIndex = 5;
            this.btn_Value.Text = "Показатель";
            this.btn_Value.UseVisualStyleBackColor = true;
            this.btn_Value.Click += new System.EventHandler(this.btn_Value_Click);
            // 
            // tb_Value
            // 
            this.tb_Value.Enabled = false;
            this.tb_Value.Location = new System.Drawing.Point(546, 10);
            this.tb_Value.Name = "tb_Value";
            this.tb_Value.Size = new System.Drawing.Size(100, 20);
            this.tb_Value.TabIndex = 6;
            // 
            // tb_Check
            // 
            this.tb_Check.Enabled = false;
            this.tb_Check.Location = new System.Drawing.Point(318, 9);
            this.tb_Check.Name = "tb_Check";
            this.tb_Check.Size = new System.Drawing.Size(100, 20);
            this.tb_Check.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SS_L_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(767, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SS_L_Status
            // 
            this.SS_L_Status.Name = "SS_L_Status";
            this.SS_L_Status.Size = new System.Drawing.Size(67, 17);
            this.SS_L_Status.Text = "Запущено.";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel1.Text = "Статус:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 431);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tb_Check);
            this.Controls.Add(this.tb_Value);
            this.Controls.Add(this.btn_Value);
            this.Controls.Add(this.btn_Processing);
            this.Controls.Add(this.pb_Tree);
            this.Controls.Add(this.btn_BuildTree);
            this.Controls.Add(this.tb_inputEnum);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tree)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_inputEnum;
        private System.Windows.Forms.Button btn_BuildTree;
        private System.Windows.Forms.PictureBox pb_Tree;
        private System.Windows.Forms.Button btn_Processing;
        private System.Windows.Forms.Button btn_Value;
        private System.Windows.Forms.TextBox tb_Value;
        private System.Windows.Forms.TextBox tb_Check;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SS_L_Status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

