using System;
using System.Threading;
namespace AdivinaNumero
{
    class MainClass
    {
        public static Game CurrentGame;
        static Thread inputThread;

        public static void Main(string[] args)
        {
            CurrentGame = new Game();
            CurrentGame.GameInit();
            inputThread = new Thread(Input);
            inputThread.Start();
            Console.Write(CurrentGame.ReadScores());
            while(CurrentGame.CurrentState != Game.eGameState.End)
            {
                switch (CurrentGame.CurrentState)
                {
                    case Game.eGameState.Start:
                        Console.WriteLine("Digite un valor entre 1 y 1000:");
                        CurrentGame.CurrentState = Game.eGameState.InGame;
                        break;

                    case Game.eGameState.InGame:
                        if (CurrentGame.LastTry == 0)
                            continue;

                        //check if secret number is guessed...
                        switch (CurrentGame.CheckIfGuessed())
                        {
                            case Game.AttemptResult.Greater:
                                Console.WriteLine("El numero secreto es menor.");
                                break;

                            case Game.AttemptResult.Lower:
                                Console.WriteLine("El numero secreto es mayor.");
                                break;
                            default:
                                Console.WriteLine("HAS ADIVINADO!");
                                CurrentGame.CurrentState = Game.eGameState.End;
                                CurrentGame.SaveState();
                                break;
                        }

                        if (CurrentGame.CurrentState != Game.eGameState.End)
                            Console.WriteLine("Digite otro valor: ");

                        CurrentGame.LastTry = 0;
                        break;
                }

            }

            inputThread.Abort();
            inputThread.Join();
            Console.WriteLine($"Ha adivinado en {CurrentGame.Attempts} intentos");
            Console.WriteLine($"Ha tomado {CurrentGame.timeSpan.TotalSeconds} segundos");
            Console.WriteLine("Gracias por jugar!");
        }

        static void Input()
        {
            int _currentValue = 0;
            while(CurrentGame.CurrentState != Game.eGameState.End)
            {
                _currentValue = Convert.ToInt32(Console.ReadLine());
                CurrentGame.LastTry = _currentValue;
            }
        }
    }
}
