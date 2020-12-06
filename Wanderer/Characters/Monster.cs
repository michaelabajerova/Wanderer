using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using GreenFox;
using Wanderer.GameMap;


namespace Wanderer.Characters
{
    class Monster : Character
    {
        public int Level { get; set; }
        List<string> monsters = new List<string>();

        public Monster(FoxDraw foxDraw, Map map) : base(foxDraw, map)
        {
            PositionOnArray = new Point(7, 7);
            Image.Source = new Bitmap(@"C:\Users\bajer\Documents\wanderer-cs\img\skeleton.png");
            foxDraw.AddImage(Image, PositionOnArray.X * 72, PositionOnArray.Y * 72);
            /*MaxHP = CurrentHP = 2 * Level * dice.Roll();
            DefendPoint = Level / 2 * dice.Roll();
            StrikePoint = Level * dice.Roll();*/
        }
        public void AddMonster(string skeleton)
        {
            monsters.Add(skeleton);
        }

    }
}
