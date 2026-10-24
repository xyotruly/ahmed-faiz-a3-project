
using System;

namespace MohawkGame2D
{
    // This class stores the soccer ball's position and color.
    public class SoccerBall
    {
        public float X = 400;
        public float Y = 300;
        public bool IsBlue = false;

        // Move the ball using the arrow keys.
        public void Move()
        {
            if (Input.IsKeyboardKeyDown(KeyboardKey.Left))
                X -= 4;

            if (Input.IsKeyboardKeyDown(KeyboardKey.Right))
                X += 4;

            if (Input.IsKeyboardKeyDown(KeyboardKey.Up))
                Y -= 4;

            if (Input.IsKeyboardKeyDown(KeyboardKey.Down))
                Y += 4;

            // Keep the ball inside the field.
            if (X < 25) X = 25;
            if (X > 775) X = 775;
            if (Y < 25) Y = 25;
            if (Y > 575) Y = 575;
        }

        // Draw the soccer ball.
        public void DrawBall()
        {
            if (IsBlue)
                Draw.FillColor = Color.Blue;
            else
                Draw.FillColor = Color.White;

            Draw.Circle(X, Y, 22);

            Draw.FillColor = Color.Black;
            Draw.Circle(X, Y, 9);
        }
    }

    public class Game
    {
        SoccerBall ball = new SoccerBall();
        bool spaceWasDown = false;

        public void Setup()
        {
            Window.SetSize(800, 600);
        }

        public void Update()
        {
            // Draw the soccer field.
            DrawField();

            // Move the soccer ball.
            ball.Move();

            // Change color once per Space key press.
            bool spaceDown =
                Input.IsKeyboardKeyDown(KeyboardKey.Space);

            if (spaceDown && !spaceWasDown)
                ball.IsBlue = !ball.IsBlue;

            spaceWasDown = spaceDown;

            // Draw the ball.
            ball.DrawBall();
        }

        // Draw the background and field markings.
        public void DrawField()
        {
            Draw.FillColor = Color.Green;
            Draw.Rectangle(0, 0, 800, 600);

            // Repeating grass stripes using a for loop.
            Draw.FillColor = Color.DarkGreen;

            for (int i = 0; i < 8; i++)
            {
                Draw.Rectangle(i * 100, 0, 50, 600);
            }

            // Centre line.
            Draw.FillColor = Color.White;
            Draw.Rectangle(398, 0, 4, 600);

            // Centre circle.
            Draw.Circle(400, 300, 65);

            Draw.FillColor = Color.Green;
            Draw.Circle(400, 300, 61);
        }
    }
}
