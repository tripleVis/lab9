using System;

namespace lab9
{
    class User
    {
        public string Name { get; private set; }//задаём свойства
        public int X { get; private set; }
        public int Y { get; private set; }
        public double P { get; private set; }
        public event Action<int,int> MoveHandler;//объявляет события
        public event Action<double> SqueezeHandler;

        public User(string name, int x = 0, int y = 0, double p = 1)//конструктор с параметрами
        {
            Name = name;
            X = x;
            Y = y;
            P = p;
            MoveHandler += SetCoords;
            MoveHandler += NotifyMove;
            SqueezeHandler += SetP;
            SqueezeHandler += NotifySqueeze;
        }

        public void Move(int dx, int dy) => MoveHandler.Invoke(dx, dy);

        public void SetCoords(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        private void NotifyMove(int dx, int dy) => Console.WriteLine($"{Name} переместился на {dx} по x и {dy} по y\nТекущее положение: {X}, {Y}");

        public void Squeeze(double k) => SqueezeHandler.Invoke(k);//вызов события

        public void SetP(double k) => P *= k;//изменение сжатия

        private void NotifySqueeze(double k) => Console.WriteLine($"{Name} сжался в {k} раз\nТекущее сжатие: {P}");//информация о сжатии
    }
}
