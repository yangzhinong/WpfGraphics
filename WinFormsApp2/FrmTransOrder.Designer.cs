namespace WinFormsApp2;

partial class FrmTransOrder
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
        groupBox1 = new GroupBox();
        label4 = new Label();
        label5 = new Label();
        label3 = new Label();
        btnReset = new Button();
        btnShow = new Button();
        tbRotaionAngle = new TextBox();
        tbTranslationY = new TextBox();
        label9 = new Label();
        tbTranslationX = new TextBox();
        label2 = new Label();
        label1 = new Label();
        rbRotationFirst = new RadioButton();
        rbTranslationFirst = new RadioButton();
        panel1 = new Panel();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(btnReset);
        groupBox1.Controls.Add(btnShow);
        groupBox1.Controls.Add(tbRotaionAngle);
        groupBox1.Controls.Add(tbTranslationY);
        groupBox1.Controls.Add(label9);
        groupBox1.Controls.Add(tbTranslationX);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(rbRotationFirst);
        groupBox1.Controls.Add(rbTranslationFirst);
        groupBox1.Dock = DockStyle.Left;
        groupBox1.Location = new Point(5, 5);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(189, 515);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(20, 144);
        label4.Name = "label4";
        label4.Size = new Size(72, 17);
        label4.TabIndex = 9;
        label4.Text = "Translation";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(20, 257);
        label5.Name = "label5";
        label5.Size = new Size(57, 17);
        label5.TabIndex = 9;
        label5.Text = "Rotation";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(13, 28);
        label3.Name = "label3";
        label3.Size = new Size(43, 17);
        label3.TabIndex = 9;
        label3.Text = "Order";
        // 
        // btnReset
        // 
        btnReset.Location = new Point(29, 476);
        btnReset.Name = "btnReset";
        btnReset.Size = new Size(134, 23);
        btnReset.TabIndex = 8;
        btnReset.Text = "Reset";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        // 
        // btnShow
        // 
        btnShow.Location = new Point(29, 447);
        btnShow.Name = "btnShow";
        btnShow.Size = new Size(134, 23);
        btnShow.TabIndex = 8;
        btnShow.Text = "Show Result";
        btnShow.UseVisualStyleBackColor = true;
        btnShow.Click += btnShow_Click;
        // 
        // tbRotaionAngle
        // 
        tbRotaionAngle.Location = new Point(76, 280);
        tbRotaionAngle.Name = "tbRotaionAngle";
        tbRotaionAngle.Size = new Size(61, 23);
        tbRotaionAngle.TabIndex = 6;
        tbRotaionAngle.Text = "0";
        // 
        // tbTranslationY
        // 
        tbTranslationY.Location = new Point(76, 206);
        tbTranslationY.Name = "tbTranslationY";
        tbTranslationY.Size = new Size(61, 23);
        tbTranslationY.TabIndex = 7;
        tbTranslationY.Text = "0";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(29, 283);
        label9.Name = "label9";
        label9.Size = new Size(41, 17);
        label9.TabIndex = 4;
        label9.Text = "Angle";
        // 
        // tbTranslationX
        // 
        tbTranslationX.Location = new Point(76, 173);
        tbTranslationX.Name = "tbTranslationX";
        tbTranslationX.Size = new Size(61, 23);
        tbTranslationX.TabIndex = 6;
        tbTranslationX.Text = "0";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(54, 209);
        label2.Name = "label2";
        label2.Size = new Size(15, 17);
        label2.TabIndex = 5;
        label2.Text = "Y";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(54, 176);
        label1.Name = "label1";
        label1.Size = new Size(16, 17);
        label1.TabIndex = 4;
        label1.Text = "X";
        // 
        // rbRotationFirst
        // 
        rbRotationFirst.AutoSize = true;
        rbRotationFirst.Location = new Point(13, 86);
        rbRotationFirst.Name = "rbRotationFirst";
        rbRotationFirst.Size = new Size(103, 21);
        rbRotationFirst.TabIndex = 2;
        rbRotationFirst.Text = "Rotation First";
        rbRotationFirst.UseVisualStyleBackColor = true;
        // 
        // rbTranslationFirst
        // 
        rbTranslationFirst.AutoSize = true;
        rbTranslationFirst.Checked = true;
        rbTranslationFirst.Location = new Point(13, 59);
        rbTranslationFirst.Name = "rbTranslationFirst";
        rbTranslationFirst.Size = new Size(118, 21);
        rbTranslationFirst.TabIndex = 0;
        rbTranslationFirst.TabStop = true;
        rbTranslationFirst.Text = "Translation First";
        rbTranslationFirst.UseVisualStyleBackColor = true;
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel1.BorderStyle = BorderStyle.Fixed3D;
        panel1.Location = new Point(200, 8);
        panel1.Name = "panel1";
        panel1.Size = new Size(593, 512);
        panel1.TabIndex = 1;
        // 
        // FrmTransOrder
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 525);
        Controls.Add(panel1);
        Controls.Add(groupBox1);
        Name = "FrmTransOrder";
        Padding = new Padding(5);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Trans Order";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private RadioButton rbRotationFirst;
    private RadioButton rbTranslationFirst;
    private TextBox tbTranslationX;
    private Label label2;
    private Label label1;
    private TextBox tbTranslationY;
    private Button btnShow;
    private TextBox tbRotaionAngle;
    private Label label9;
    private Button btnReset;
    private Panel panel1;
    private Label label3;
    private Label label4;
    private Label label5;
}