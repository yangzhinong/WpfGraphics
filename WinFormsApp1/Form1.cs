namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, false);
        this.BackColor = Color.White;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.PageUnit = GraphicsUnit.Inch;
        g.ResetTransform();
        g.TranslateTransform(ClientRectangle.Width / g.DpiX / 2, ClientRectangle.Height / g.DpiY / 2);
        var pen = new Pen(Color.Black, 1 / g.DpiX);
        g.DrawLine(pen, 0, 0, 1, 1);
    }
}
