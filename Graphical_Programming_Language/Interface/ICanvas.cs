namespace Graphical_Programming_Language.Interface
{
    public interface ICanvas
    {
        Point CurrentPosition { get; set; }
        TextBox CommandTextBox { get; }
        PictureBox PictureBox { get; }
        Pen DrawingPen { get; set; }
        Color FillColor { get; set; }
        bool IsFilling { get; set; }

    }
}
