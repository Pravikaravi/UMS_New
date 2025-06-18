using System.Drawing;
using System.Drawing.Drawing2D;

namespace UnicomTIC_Management_System.Design
{
    public class DrawRectangle
    {
        public static void DrawRoundedRectangle(Graphics g, Rectangle bounds, int radius, Color borderColor, Color fillColor, float borderWidth = 2)
        {
            using (GraphicsPath path = CreateRoundedRectPath(bounds, radius))
            using (Pen pen = new Pen(borderColor, borderWidth))
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }
        }

        private static GraphicsPath CreateRoundedRectPath(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddLine(bounds.X + radius, bounds.Y, bounds.Right - radius, bounds.Y);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddLine(bounds.Right, bounds.Y + radius, bounds.Right, bounds.Bottom - radius);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddLine(bounds.Right - radius, bounds.Bottom, bounds.X + radius, bounds.Bottom);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.AddLine(bounds.X, bounds.Bottom - radius, bounds.X, bounds.Y + radius);

            path.CloseFigure();
            return path;
        }
    }
}
