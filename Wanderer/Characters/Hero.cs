using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using GreenFox;
using Wanderer.GameMap;

namespace Wanderer.Characters
{
    class Hero : Character
    {
        private int randomD6 = new Random().Next(1, 7);
        public Hero(FoxDraw foxDraw, Map map) : base(foxDraw, map)
        {
            PositionOnArray = new Point(0, 0);
            Image.Source = new Bitmap(@"C:\Users\bajer\Documents\wanderer-cs\img\hero-down.png");
            foxDraw.AddImage(Image, PositionOnArray.X * 72, PositionOnArray.Y * 72);
            MaxHP = CurrentHP = 20 + 3 * randomD6;
            DefendPoint = 2 * randomD6;
            StrikePoint = 5 + randomD6;
            CurrentHP = MaxHP;
        }
        public override void DrawCharacter(Point newPoint, Avalonia.Input.KeyEventArgs pressed)
        {
            switch (pressed.Key)
            {
                case Avalonia.Input.Key.W:
                    {
                        ImagePath = @"C:\Users\bajer\Documents\wanderer-cs\img\hero-up.png";
                        break;
                    }
                case Avalonia.Input.Key.S:
                    {
                        ImagePath = @"C:\Users\bajer\Documents\wanderer-cs\img\hero-down.png";
                        break;
                    }
                case Avalonia.Input.Key.A:
                    {
                        ImagePath = @"C:\Users\bajer\Documents\wanderer-cs\img\mario-left.png";
                        break;
                    }
                case Avalonia.Input.Key.D:
                    {
                        ImagePath = @"C:\Users\bajer\Documents\wanderer-cs\img\hero-right.png";
                        break;
                    }
                default:
                    break;
            }
            Image.Source = new Bitmap(ImagePath);
        }
        public void Move(object sender, Avalonia.Input.KeyEventArgs pressed)
        {
            switch (pressed.Key)
            {
                case Avalonia.Input.Key.W:
                    {
                        MoveCharacter(pressed, 0, -72);
                            break;
                    }
                case Avalonia.Input.Key.S:
                    {
                        MoveCharacter(pressed, 0, 72);
                        break;
                    }
                case Avalonia.Input.Key.A:
                    {
                        MoveCharacter(pressed, -72, -0);
                        break;
                    }
                case Avalonia.Input.Key.D:
                    {
                        MoveCharacter(pressed, 72, 0);
                        break;
                    }
                default:
                    break;
            }
            DrawChar.SetPosition(Image, PositionOnArray.X, PositionOnArray.Y);
            
        }
        public override void MoveCharacter(Avalonia.Input.KeyEventArgs pressed, int newPositionX = 0, int newPositionY = 0)
        {
            PositionOnArray = new Point(newPositionX + PositionOnArray.X, newPositionY + PositionOnArray.Y);
            DrawCharacter(new Point(PositionOnArray.X + newPositionX, PositionOnArray.Y + newPositionY), pressed);
        }
        public void SaveText()
        {
            string hero = $"Arnold";
            File.WriteAllText("hero.txt", hero);
        }
    }
}
