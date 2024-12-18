namespace WinFormsApp2;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        drawingPanel = new Panel();
        SuspendLayout();
        // 
        // drawingPanel
        // 
        drawingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        drawingPanel.BorderStyle = BorderStyle.FixedSingle;
        drawingPanel.Location = new Point(12, 12);
        drawingPanel.Name = "drawingPanel";
        drawingPanel.Size = new Size(776, 426);
        drawingPanel.TabIndex = 0;
        drawingPanel.Paint += drawingPanel_Paint;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(drawingPanel);
        Name = "Form1";
        Text = "Form1";
        SizeChanged += Form1_SizeChanged;
        ResumeLayout(false);
    }

    #endregion

    private Panel drawingPanel;
}
