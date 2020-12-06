using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using GreenFox;
using Wanderer.GameMap;

namespace Wanderer.Characters
{
    abstract class Character
    {
        public Point PositionOnArray { get; set; }
        public Image Image { get; set; }

        public string ImagePath { get; set; }
        public int[,] Map { get; set; }
        protected int MaxHP { get; set; }
        protected int CurrentHP { get; set; }
        protected int DefendPoint { get; set; }
        protected int StrikePoint { get; set; }
        protected FoxDraw DrawChar { get; set;}

        public Character(FoxDraw foxDraw, Map map)
        {
            Map = map.Tiles;
            Image = new Image();
            DrawChar = foxDraw;
        }
        public virtual void DrawCharacter(Point newPoint, Avalonia.Input.KeyEventArgs pressed)
        {
            DrawChar.SetPosition(Image, newPoint.X * 72, newPoint.Y * 72);
            PositionOnArray = newPoint;

        }
        public virtual void MoveCharacter(Avalonia.Input.KeyEventArgs pressed, int newPositionX = 0, int newPositionY = 0)
        {
            Map[(int)PositionOnArray.X, (int)PositionOnArray.Y] = 0;
            Map[(int)PositionOnArray.X + newPositionX, (int)PositionOnArray.Y + newPositionY] = 1;

            /*DrawCharacter(new Point(PositionOnArray.X + newPositionX, PositionOnArray.Y + newPositionY));*/
        }
    }    
}
