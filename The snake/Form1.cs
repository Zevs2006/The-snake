using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace The_snake
{
    public partial class Form1 : Form
    {
        private List<Point> snake; // Тело змейки
        private Point food; // Еда
        private int score; // Счет
        private int direction; // Направление змейки (0 = влево, 1 = вверх, 2 = вправо, 3 = вниз)
        private Random rand; // Генератор случайных чисел для еды
        private int gridSize = 20; // Размер сетки (каждая клетка змейки и еды будет 20x20)

        public Form1()
        {
            InitializeComponent();
            snake = new List<Point> { new Point(100, 100), new Point(80, 100), new Point(60, 100) };
            rand = new Random();
            food = GenerateFood();
            score = 0;
            direction = 2; // Изначально змейка движется вправо
            gameTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Очищаем картинку перед каждым кадром
            pictureBox1.Refresh();

            Graphics g = pictureBox1.CreateGraphics();

            // Отрисовка змейки
            foreach (Point p in snake)
            {
                g.FillRectangle(Brushes.Green, new Rectangle(p.X, p.Y, gridSize, gridSize));
            }

            // Отрисовка еды
            g.FillRectangle(Brushes.Red, new Rectangle(food.X, food.Y, gridSize, gridSize));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            this.Invalidate(); // Обновляем экран для перерисовки
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (direction != 2) direction = 0;
                    break;
                case Keys.Up:
                    if (direction != 3) direction = 1;
                    break;
                case Keys.Right:
                    if (direction != 0) direction = 2;
                    break;
                case Keys.Down:
                    if (direction != 1) direction = 3;
                    break;
            }
        }

        private void MoveSnake()
        {
            Point head = snake[0]; // Голова змейки
            Point newHead = head;

            // Вычисление новой позиции головы в зависимости от направления
            switch (direction)
            {
                case 0:
                    newHead.X -= gridSize;
                    break;
                case 1:
                    newHead.Y -= gridSize;
                    break;
                case 2:
                    newHead.X += gridSize;
                    break;
                case 3:
                    newHead.Y += gridSize;
                    break;
            }

            // Добавляем новую голову в начало списка
            snake.Insert(0, newHead);

            // Проверяем, съела ли змейка еду
            if (newHead == food)
            {
                score++;
                lblScore.Text = "Счет: " + score;
                food = GenerateFood(); // Генерируем новую еду
            }
            else
            {
                snake.RemoveAt(snake.Count - 1); // Убираем последний сегмент змейки
            }
        }

        private void CheckCollision()
        {
            Point head = snake[0];

            // Проверка столкновений с границами
            if (head.X < 0 || head.Y < 0 || head.X >= pictureBox1.Width || head.Y >= pictureBox1.Height)
            {
                GameOver();
            }

            // Проверка столкновений с телом змейки
            for (int i = 1; i < snake.Count; i++)
            {
                if (head == snake[i])
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show("Игра окончена! Ваш счет: " + score);
            ResetGame();
        }

        private void ResetGame()
        {
            snake = new List<Point> { new Point(100, 100), new Point(80, 100), new Point(60, 100) };
            direction = 2;
            score = 0;
            lblScore.Text = "Счет: 0";
            food = GenerateFood();
            gameTimer.Start();
        }

        private Point GenerateFood()
        {
            int x = rand.Next(0, pictureBox1.Width / gridSize) * gridSize;
            int y = rand.Next(0, pictureBox1.Height / gridSize) * gridSize;
            return new Point(x, y);
        }
    }
}
