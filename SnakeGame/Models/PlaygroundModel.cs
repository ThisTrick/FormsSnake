using System.Drawing;

namespace FormsSnake.Models
{
    public class PlaygroundModel
    {
        public int Space { get; }
        public int Step { get; }
        
        public Point DirectionSnake { get; set; }
        
        public Point DirectionLeft { get; }
        
        public Point DirectionRight { get; }

        public Point DirectionTop { get; }
        
        public Point DirectionBottom { get; }
        
        public PlaygroundModel()
        {
            Space = 576;
            Step = 32;
            DirectionLeft = new Point(1, 0);
            DirectionRight = new Point(-1, 0);
            DirectionTop = new Point(0, -1);
            DirectionBottom = new Point(0, 1);
            DirectionSnake = DirectionLeft;
        }
        
        
        
    }
}