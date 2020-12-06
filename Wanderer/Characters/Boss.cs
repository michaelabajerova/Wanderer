using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using GreenFox;
using Wanderer.GameMap;

namespace Wanderer.Characters
{
    class Boss : Character
    {
        public int Level { get; set; }
        public Boss(FoxDraw foxDraw, Map map/*, Dice dice*/) : base(foxDraw, map)
        {
            PositionOnArray = new Point(0, 9);
            Image.Source = new Bitmap(@"C:\Users\bajer\Documents\wanderer-cs\img\boss.png");
            foxDraw.AddImage(Image, PositionOnArray.X * 72, PositionOnArray.Y * 72);
            /*MaxHP = 2 * Level * dice.Roll() + dice.Roll();
            DefendPoint = Level / 2 * dice.Roll() + dice.Roll() / 2;
            StrikePoint = Level * dice.Roll() + Level;*/
        }
    }
}

