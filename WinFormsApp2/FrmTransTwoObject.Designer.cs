namespace WinFormsApp2;

partial class FrmTransTwoObject
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
        btnReset = new Button();
        btnShow = new Button();
        tbRedRotaionAngle = new TextBox();
        tbRedTranslationY = new TextBox();
        label9 = new Label();
        tbRedTranslationX = new TextBox();
        label2 = new Label();
        label1 = new Label();
        panel1 = new Panel();
        cbHBrickHouse = new CheckBox();
        label3 = new Label();
        label6 = new Label();
        tbGreenTranslationX = new TextBox();
        label7 = new Label();
        tbGreenTranslationY = new TextBox();
        tbGreenRotationAngle = new TextBox();
        label8 = new Label();
        label10 = new Label();
        cbDBrickHouse = new CheckBox();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(cbDBrickHouse);
        groupBox1.Controls.Add(label10);
        groupBox1.Controls.Add(cbHBrickHouse);
        groupBox1.Controls.Add(label8);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(btnReset);
        groupBox1.Controls.Add(tbGreenRotationAngle);
        groupBox1.Controls.Add(btnShow);
        groupBox1.Controls.Add(tbGreenTranslationY);
        groupBox1.Controls.Add(tbRedRotaionAngle);
        groupBox1.Controls.Add(label7);
        groupBox1.Controls.Add(tbRedTranslationY);
        groupBox1.Controls.Add(tbGreenTranslationX);
        groupBox1.Controls.Add(label9);
        groupBox1.Controls.Add(label6);
        groupBox1.Controls.Add(tbRedTranslationX);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
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
        label4.Location = new Point(27, 60);
        label4.Name = "label4";
        label4.Size = new Size(72, 17);
        label4.TabIndex = 9;
        label4.Text = "Translation";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(27, 155);
        label5.Name = "label5";
        label5.Size = new Size(57, 17);
        label5.TabIndex = 9;
        label5.Text = "Rotation";
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
        // tbRedRotaionAngle
        // 
        tbRedRotaionAngle.Location = new Point(83, 178);
        tbRedRotaionAngle.Name = "tbRedRotaionAngle";
        tbRedRotaionAngle.Size = new Size(61, 23);
        tbRedRotaionAngle.TabIndex = 6;
        tbRedRotaionAngle.Text = "90";
        // 
        // tbRedTranslationY
        // 
        tbRedTranslationY.Location = new Point(83, 122);
        tbRedTranslationY.Name = "tbRedTranslationY";
        tbRedTranslationY.Size = new Size(61, 23);
        tbRedTranslationY.TabIndex = 7;
        tbRedTranslationY.Text = "0";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(36, 181);
        label9.Name = "label9";
        label9.Size = new Size(41, 17);
        label9.TabIndex = 4;
        label9.Text = "Angle";
        // 
        // tbRedTranslationX
        // 
        tbRedTranslationX.Location = new Point(83, 89);
        tbRedTranslationX.Name = "tbRedTranslationX";
        tbRedTranslationX.Size = new Size(61, 23);
        tbRedTranslationX.TabIndex = 6;
        tbRedTranslationX.Text = "100";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(61, 125);
        label2.Name = "label2";
        label2.Size = new Size(15, 17);
        label2.TabIndex = 5;
        label2.Text = "Y";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(61, 92);
        label1.Name = "label1";
        label1.Size = new Size(16, 17);
        label1.TabIndex = 4;
        label1.Text = "X";
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
        // cbHBrickHouse
        // 
        cbHBrickHouse.AutoSize = true;
        cbHBrickHouse.Checked = true;
        cbHBrickHouse.CheckState = CheckState.Checked;
        cbHBrickHouse.Location = new Point(20, 31);
        cbHBrickHouse.Name = "cbHBrickHouse";
        cbHBrickHouse.Size = new Size(106, 21);
        cbHBrickHouse.TabIndex = 10;
        cbHBrickHouse.Text = "HBrick House";
        cbHBrickHouse.UseVisualStyleBackColor = true;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(61, 351);
        label3.Name = "label3";
        label3.Size = new Size(16, 17);
        label3.TabIndex = 4;
        label3.Text = "X";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(61, 384);
        label6.Name = "label6";
        label6.Size = new Size(15, 17);
        label6.TabIndex = 5;
        label6.Text = "Y";
        // 
        // tbGreenTranslationX
        // 
        tbGreenTranslationX.Location = new Point(83, 348);
        tbGreenTranslationX.Name = "tbGreenTranslationX";
        tbGreenTranslationX.Size = new Size(61, 23);
        tbGreenTranslationX.TabIndex = 6;
        tbGreenTranslationX.Text = "100";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(36, 285);
        label7.Name = "label7";
        label7.Size = new Size(41, 17);
        label7.TabIndex = 4;
        label7.Text = "Angle";
        // 
        // tbGreenTranslationY
        // 
        tbGreenTranslationY.Location = new Point(83, 381);
        tbGreenTranslationY.Name = "tbGreenTranslationY";
        tbGreenTranslationY.Size = new Size(61, 23);
        tbGreenTranslationY.TabIndex = 7;
        tbGreenTranslationY.Text = "0";
        // 
        // tbGreenRotationAngle
        // 
        tbGreenRotationAngle.Location = new Point(83, 282);
        tbGreenRotationAngle.Name = "tbGreenRotationAngle";
        tbGreenRotationAngle.Size = new Size(61, 23);
        tbGreenRotationAngle.TabIndex = 6;
        tbGreenRotationAngle.Text = "90";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(27, 259);
        label8.Name = "label8";
        label8.Size = new Size(57, 17);
        label8.TabIndex = 9;
        label8.Text = "Rotation";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(27, 319);
        label10.Name = "label10";
        label10.Size = new Size(72, 17);
        label10.TabIndex = 9;
        label10.Text = "Translation";
        // 
        // cbDBrickHouse
        // 
        cbDBrickHouse.AutoSize = true;
        cbDBrickHouse.Checked = true;
        cbDBrickHouse.CheckState = CheckState.Checked;
        cbDBrickHouse.Location = new Point(27, 226);
        cbDBrickHouse.Name = "cbDBrickHouse";
        cbDBrickHouse.Size = new Size(106, 21);
        cbDBrickHouse.TabIndex = 10;
        cbDBrickHouse.Text = "DBrick House";
        cbDBrickHouse.UseVisualStyleBackColor = true;
        // 
        // FrmTransTwoObject
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 525);
        Controls.Add(panel1);
        Controls.Add(groupBox1);
        Name = "FrmTransTwoObject";
        Padding = new Padding(5);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Trans Two Object";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private TextBox tbRedTranslationX;
    private Label label2;
    private Label label1;
    private TextBox tbRedTranslationY;
    private Button btnShow;
    private TextBox tbRedRotaionAngle;
    private Label label9;
    private Button btnReset;
    private Panel panel1;
    private Label label4;
    private Label label5;
    private CheckBox cbDBrickHouse;
    private Label label10;
    private CheckBox cbHBrickHouse;
    private Label label8;
    private TextBox tbGreenRotationAngle;
    private TextBox tbGreenTranslationY;
    private Label label7;
    private TextBox tbGreenTranslationX;
    private Label label6;
    private Label label3;
}