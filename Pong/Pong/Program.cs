﻿using Raylib_cs;
using System.Numerics;

//Kysyin Chatgptltä piirtämään minun puolesta ja vähän apua liikkeiden parantamista
class PongGame
{
    static void Main()
    {
        const int screenWidth = 800;
        const int screenHeight = 450;
        Raylib.InitWindow(screenWidth, screenHeight, "Pong");
        Raylib.SetTargetFPS(60);

        int paddleWidth = 10, paddleHeight = 100, paddleSpeed = 5;
        Vector2 player1 = new Vector2(20, screenHeight / 2 - paddleHeight / 2);
        Vector2 player2 = new Vector2(screenWidth - 30, screenHeight / 2 - paddleHeight / 2);

        Vector2 ball = new Vector2(screenWidth / 2, screenHeight / 2);
        Vector2 ballSpeed = new Vector2(4, 4);

        int score1 = 0, score2 = 0;

        while (!Raylib.WindowShouldClose())
        {
            if (Raylib.IsKeyDown(KeyboardKey.W) && player1.Y > 0)
                player1.Y -= paddleSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.S) && player1.Y < screenHeight - paddleHeight)
                player1.Y += paddleSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Up) && player2.Y > 0)
                player2.Y -= paddleSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Down) && player2.Y < screenHeight - paddleHeight)
                player2.Y += paddleSpeed;

            ball += ballSpeed;

            if (ball.Y <= 0 || ball.Y >= screenHeight - 10)
                ballSpeed.Y *= -1;

            if (Raylib.CheckCollisionRecs(
                    new Rectangle(ball.X, ball.Y, 10, 10),
                    new Rectangle(player1.X, player1.Y, paddleWidth, paddleHeight)) ||
                Raylib.CheckCollisionRecs(
                    new Rectangle(ball.X, ball.Y, 10, 10),
                    new Rectangle(player2.X, player2.Y, paddleWidth, paddleHeight)))
            {
                ballSpeed.X *= -1;
            }

            if (ball.X <= 0)
            {
                score2++;
                ball = new Vector2(screenWidth / 2, screenHeight / 2);
                ballSpeed = new Vector2(4, 4);
            }
            if (ball.X >= screenWidth - 10)
            {
                score1++;
                ball = new Vector2(screenWidth / 2, screenHeight / 2);
                ballSpeed = new Vector2(-4, 4); 
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawRectangle((int)player1.X, (int)player1.Y, paddleWidth, paddleHeight, Color.White);
            Raylib.DrawRectangle((int)player2.X, (int)player2.Y, paddleWidth, paddleHeight, Color.White);
            Raylib.DrawRectangle((int)ball.X, (int)ball.Y, 10, 10, Color.White);
            Raylib.DrawText(score1.ToString(), screenWidth / 4, 20, 40, Color.White);
            Raylib.DrawText(score2.ToString(), screenWidth * 3 / 4, 20, 40, Color.White);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
