using System;
using Raylib_cs;
using System.Numerics;

namespace DVD_Logo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 800;
            const int screenHeight = 600;
            Raylib.InitWindow(screenWidth, screenHeight, "DVD Logo");
            Raylib.SetTargetFPS(60);

            Vector2 position = new Vector2(screenWidth / 2, screenHeight / 2);
            Vector2 direction = new Vector2(1, 1); 
            float speed = 200.0f; 

              string text = "DVD";
            float fontSize = 50;
            float spacing = 2;
            Color textColor = Color.Yellow;

            
            while (!Raylib.WindowShouldClose())
            {
                float frameTime = Raylib.GetFrameTime(); 

               
                position += direction * speed * frameTime;

               
                Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), text, fontSize, spacing);

                
                if (position.X <= 0 || position.X + textSize.X >= screenWidth)
                {
                    direction.X *= -1; 
                    textColor = GetRandomColor(); 
                }

                if (position.Y <= 0 || position.Y + textSize.Y >= screenHeight)
                {
                    direction.Y *= -1; 
                    textColor = GetRandomColor(); 
                }

                
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawTextEx(Raylib.GetFontDefault(), text, position, fontSize, spacing, textColor);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        static Color GetRandomColor()
        {
            Random random = new Random();
            return new Color(random.Next(256), random.Next(256), random.Next(256), 255);
        }
    }
}
