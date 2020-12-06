
using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System.Collections.Generic;
using JetBrains.Annotations;
using GreenFox;
using Wanderer.GameMap;
using Wanderer.Characters;
using Avalonia.Input;

namespace DrawingApplication
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
            var canvas = this.Get<Canvas>("canvas");
            var foxDraw = new FoxDraw(canvas);

            int randomNumber = new Random().Next(3, 6);

            Map map = new Map();
            map.FillMap(foxDraw);
            Hero hero = new Hero(foxDraw, map);
            List<Monster> skeletons = new List<Monster>();
            for (int i = 0; i < randomNumber; i++)
            {
                skeletons.Add(new Monster(foxDraw, map));
            }
            Boss boss = new Boss(foxDraw, map);
            

            KeyUp += hero.Move;
            //hero//
            foxDraw.DrawText("Hero (Level 1) | HP: 8/10 | DP: 8 | SP: 6", new FoxDraw.TextFormatter(16, 0, Brushes.Black, new Point(0, 723)), out TextBox textBox);
            //monster
            foxDraw.DrawText("Monster (Level 1) | HP: 5/10 | DP: 2 | SP: 3", new FoxDraw.TextFormatter(16, 0, Brushes.Brown, new Point(0, 746)), out TextBox textBox2);
            //boss//
            foxDraw.DrawText("Boss (Level 100) | HP: 1000/1000 | DP: 200 | SP: 300", new FoxDraw.TextFormatter(16, 2, Brushes.DarkRed, new Point(0, 773)), out TextBox textBox3);










#endif
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
