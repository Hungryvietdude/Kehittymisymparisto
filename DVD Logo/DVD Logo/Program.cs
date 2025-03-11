﻿using System;
using Raylib_cs;
using System.Numerics;

namespace DVD_Logo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Avaa ikkuna
            const int screenWidth = 800;
            const int screenHeight = 600;
            Raylib.InitWindow(screenWidth, screenHeight, "DVD Logo");
            Raylib.SetTargetFPS(60);

            // Tekstin aloituspaikka (keskellä ruutua)
            Vector2 position = new Vector2(screenWidth / 2, screenHeight / 2);
            Vector2 direction = new Vector2(1, 1); // Suunta
            float speed = 200.0f; // Nopeus

            // Tekstin koko ja väri
            string text = "DVD";
            float fontSize = 50;
            float spacing = 2;
            Color textColor = Color.Yellow;

            // Päälooppi
            while (!Raylib.WindowShouldClose())
            {
                float frameTime = Raylib.GetFrameTime(); // Delta time

                // Päivitä sijainti
                position += direction * speed * frameTime;

                // Mittaa tekstin koko
                Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), text, fontSize, spacing);

                // Törmäykset reunoihin
                if (position.X <= 0 || position.X + textSize.X >= screenWidth)
                {
                    direction.X *= -1; // Käännä X-suunnan liike
                    textColor = GetRandomColor(); // Vaihda väri
                }

                if (position.Y <= 0 || position.Y + textSize.Y >= screenHeight)
                {
                    direction.Y *= -1; // Käännä Y-suunnan liike
                    textColor = GetRandomColor(); // Vaihda väri
                }

                // Piirrä ruutu
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawTextEx(Raylib.GetFontDefault(), text, position, fontSize, spacing, textColor);
                Raylib.EndDrawing();
            }

            // Sulje ikkuna
            Raylib.CloseWindow();
        }

        // Funktio satunnaisen värin saamiseksi
        static Color GetRandomColor()
        {
            Random random = new Random();
            return new Color(random.Next(256), random.Next(256), random.Next(256), 255);
        }
    }
}
