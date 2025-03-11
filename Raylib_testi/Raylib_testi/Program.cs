using System.Numerics;
using Raylib_cs;

namespace RaylibTesti
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Vector2 A = new Vector2(800/2,0);
            Vector2 B = new Vector2(0,800/2);
            Vector2 C = new Vector2(800,800*3/4);

            Vector2 directionA = new Vector2(1, 1);
            Vector2 directionB = new Vector2(1, -1);
            Vector2 directionC = new Vector2(-1, -1);

            Vector2 Amove = new Vector2(1, 1);

            Vector2 position = new Vector2(10, 10);
            Vector2 direction = new Vector2(1, 0);
            float speed = 3.0f;

            Vector2 move = direction * speed * Raylib.GetFrameTime();
            position = position + move;

            Console.WriteLine("Hello, World!");
            Raylib.InitWindow(800, 800, "Raylib Testi");
            while(Raylib.WindowShouldClose() == false)
            {


                A += directionA * speed * Raylib.GetFrameTime();
                B += directionB * speed * Raylib.GetFrameTime();
                C += directionC * speed * Raylib.GetFrameTime();

                Raylib.BeginDrawing();



                Raylib.ClearBackground(Color.Black);

                Raylib.DrawLineV(A, B, Color.Green);
                Raylib.DrawLineV(B, C, Color.Yellow );
                Raylib.DrawLineV(C, A, Color.SkyBlue );
                Raylib.DrawText("GAMING!!!!" ,100, 100, 32, Color.Gray);

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
