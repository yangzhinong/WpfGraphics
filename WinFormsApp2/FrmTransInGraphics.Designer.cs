namespace WinFormsApp2;

partial class FrmTransInGraphics
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
        btnReset = new Button();
        btnShow = new Button();
        tbShearY = new TextBox();
        tbShearX = new TextBox();
        tbRotateAtY = new TextBox();
        tbRotaionAngle = new TextBox();
        tbRotateAtX = new TextBox();
        tbScaleY = new TextBox();
        label8 = new Label();
        tbScaleX = new TextBox();
        label6 = new Label();
        tbTranslationY = new TextBox();
        label7 = new Label();
        label9 = new Label();
        label4 = new Label();
        label5 = new Label();
        tbTranslationX = new TextBox();
        label3 = new Label();
        label2 = new Label();
        label1 = new Label();
        rbShear = new RadioButton();
        rbRotation = new RadioButton();
        rbScale = new RadioButton();
        rbTranslation = new RadioButton();
        panel1 = new Panel();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(btnReset);
        groupBox1.Controls.Add(btnShow);
        groupBox1.Controls.Add(tbShearY);
        groupBox1.Controls.Add(tbShearX);
        groupBox1.Controls.Add(tbRotateAtY);
        groupBox1.Controls.Add(tbRotaionAngle);
        groupBox1.Controls.Add(tbRotateAtX);
        groupBox1.Controls.Add(tbScaleY);
        groupBox1.Controls.Add(label8);
        groupBox1.Controls.Add(tbScaleX);
        groupBox1.Controls.Add(label6);
        groupBox1.Controls.Add(tbTranslationY);
        groupBox1.Controls.Add(label7);
        groupBox1.Controls.Add(label9);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(tbTranslationX);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(rbShear);
        groupBox1.Controls.Add(rbRotation);
        groupBox1.Controls.Add(rbScale);
        groupBox1.Controls.Add(rbTranslation);
        groupBox1.Dock = DockStyle.Left;
        groupBox1.Location = new Point(5, 5);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(189, 515);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
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
        // tbShearY
        // 
        tbShearY.Location = new Point(76, 403);
        tbShearY.Name = "tbShearY";
        tbShearY.Size = new Size(61, 23);
        tbShearY.TabIndex = 7;
        tbShearY.Text = "0";
        // 
        // tbShearX
        // 
        tbShearX.Location = new Point(76, 370);
        tbShearX.Name = "tbShearX";
        tbShearX.Size = new Size(61, 23);
        tbShearX.TabIndex = 6;
        tbShearX.Text = "0";
        // 
        // tbRotateAtY
        // 
        tbRotateAtY.Location = new Point(75, 308);
        tbRotateAtY.Name = "tbRotateAtY";
        tbRotateAtY.Size = new Size(61, 23);
        tbRotateAtY.TabIndex = 7;
        tbRotateAtY.Text = "0";
        // 
        // tbRotaionAngle
        // 
        tbRotaionAngle.Location = new Point(76, 241);
        tbRotaionAngle.Name = "tbRotaionAngle";
        tbRotaionAngle.Size = new Size(61, 23);
        tbRotaionAngle.TabIndex = 6;
        tbRotaionAngle.Text = "0";
        // 
        // tbRotateAtX
        // 
        tbRotateAtX.Location = new Point(76, 275);
        tbRotateAtX.Name = "tbRotateAtX";
        tbRotateAtX.Size = new Size(61, 23);
        tbRotateAtX.TabIndex = 6;
        tbRotateAtX.Text = "0";
        // 
        // tbScaleY
        // 
        tbScaleY.Location = new Point(76, 169);
        tbScaleY.Name = "tbScaleY";
        tbScaleY.Size = new Size(61, 23);
        tbScaleY.TabIndex = 7;
        tbScaleY.Text = "1";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(54, 406);
        label8.Name = "label8";
        label8.Size = new Size(15, 17);
        label8.TabIndex = 5;
        label8.Text = "Y";
        // 
        // tbScaleX
        // 
        tbScaleX.Location = new Point(76, 136);
        tbScaleX.Name = "tbScaleX";
        tbScaleX.Size = new Size(61, 23);
        tbScaleX.TabIndex = 6;
        tbScaleX.Text = "1";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(53, 311);
        label6.Name = "label6";
        label6.Size = new Size(15, 17);
        label6.TabIndex = 5;
        label6.Text = "Y";
        // 
        // tbTranslationY
        // 
        tbTranslationY.Location = new Point(76, 85);
        tbTranslationY.Name = "tbTranslationY";
        tbTranslationY.Size = new Size(61, 23);
        tbTranslationY.TabIndex = 7;
        tbTranslationY.Text = "0";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(54, 373);
        label7.Name = "label7";
        label7.Size = new Size(16, 17);
        label7.TabIndex = 4;
        label7.Text = "X";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(29, 244);
        label9.Name = "label9";
        label9.Size = new Size(41, 17);
        label9.TabIndex = 4;
        label9.Text = "Angle";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(54, 172);
        label4.Name = "label4";
        label4.Size = new Size(15, 17);
        label4.TabIndex = 5;
        label4.Text = "Y";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(54, 278);
        label5.Name = "label5";
        label5.Size = new Size(16, 17);
        label5.TabIndex = 4;
        label5.Text = "X";
        // 
        // tbTranslationX
        // 
        tbTranslationX.Location = new Point(76, 52);
        tbTranslationX.Name = "tbTranslationX";
        tbTranslationX.Size = new Size(61, 23);
        tbTranslationX.TabIndex = 6;
        tbTranslationX.Text = "0";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(54, 139);
        label3.Name = "label3";
        label3.Size = new Size(16, 17);
        label3.TabIndex = 4;
        label3.Text = "X";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(54, 88);
        label2.Name = "label2";
        label2.Size = new Size(15, 17);
        label2.TabIndex = 5;
        label2.Text = "Y";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(54, 55);
        label1.Name = "label1";
        label1.Size = new Size(16, 17);
        label1.TabIndex = 4;
        label1.Text = "X";
        // 
        // rbShear
        // 
        rbShear.AutoSize = true;
        rbShear.Location = new Point(13, 343);
        rbShear.Name = "rbShear";
        rbShear.Size = new Size(59, 21);
        rbShear.TabIndex = 3;
        rbShear.Text = "Shear";
        rbShear.UseVisualStyleBackColor = true;
        // 
        // rbRotation
        // 
        rbRotation.AutoSize = true;
        rbRotation.Location = new Point(13, 209);
        rbRotation.Name = "rbRotation";
        rbRotation.Size = new Size(75, 21);
        rbRotation.TabIndex = 2;
        rbRotation.Text = "Rotation";
        rbRotation.UseVisualStyleBackColor = true;
        // 
        // rbScale
        // 
        rbScale.AutoSize = true;
        rbScale.Location = new Point(13, 108);
        rbScale.Name = "rbScale";
        rbScale.Size = new Size(56, 21);
        rbScale.TabIndex = 1;
        rbScale.Text = "Scale";
        rbScale.UseVisualStyleBackColor = true;
        // 
        // rbTranslation
        // 
        rbTranslation.AutoSize = true;
        rbTranslation.Checked = true;
        rbTranslation.Location = new Point(13, 23);
        rbTranslation.Name = "rbTranslation";
        rbTranslation.Size = new Size(90, 21);
        rbTranslation.TabIndex = 0;
        rbTranslation.TabStop = true;
        rbTranslation.Text = "Translation";
        rbTranslation.UseVisualStyleBackColor = true;
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
        // FrmTransInGraphics
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 525);
        Controls.Add(panel1);
        Controls.Add(groupBox1);
        Name = "FrmTransInGraphics";
        Padding = new Padding(5);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Trans In Graphics";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private RadioButton rbShear;
    private RadioButton rbRotation;
    private RadioButton rbScale;
    private RadioButton rbTranslation;
    private TextBox tbTranslationX;
    private Label label2;
    private Label label1;
    private TextBox tbShearY;
    private TextBox tbShearX;
    private TextBox tbRotateAtY;
    private TextBox tbRotateAtX;
    private TextBox tbScaleY;
    private Label label8;
    private TextBox tbScaleX;
    private Label label6;
    private TextBox tbTranslationY;
    private Label label7;
    private Label label4;
    private Label label5;
    private Label label3;
    private Button btnShow;
    private TextBox tbRotaionAngle;
    private Label label9;
    private Button btnReset;
    private Panel panel1;
}