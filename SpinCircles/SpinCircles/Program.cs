using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;
using MathLib;

namespace SpinCircles
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 800;
        public string windowTitle = "Spinning Circles";

        List<Vector2> path1 = new List<Vector2>();
        Vector2 circle1Pos = new Vector2(0, 0);

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }  

        void Update()
        {


            MoveCircles();
            DeletePoint();
        }

        public void MoveCircles()
        {
            
        }

        public void DeletePoint()
        {

        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            DrawPath();
            DrawCircle();

            Raylib.EndDrawing();
        }

        public void DrawPath()
        {
            for (int i = 1; i < path1.Count; i++)
                Raylib.DrawLineV(path1[i], path1[i - 1], Color.BLACK);

            foreach (var p in path1)
                Raylib.DrawCircleV(p, 3, Color.BLACK);
        }

        public void DrawCircle()
        {
            float size = 10;

            // draw a circle representing the player
            Raylib.DrawCircleV(circle1Pos, 10, Color.RED);

            // Draw a line in the direction of movement
            if (path1.Count > 0)
            {
                Vector2 endLinePoint = circle1Pos + (Vector2.Normalise(path1[0] - circle1Pos) * size);
                Raylib.DrawLineEx(circle1Pos, endLinePoint, 2, Color.BLACK);
            }
        }
    }
}
