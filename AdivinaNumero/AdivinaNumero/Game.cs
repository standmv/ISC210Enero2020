using System;
using System.IO;
using System.Text;

namespace AdivinaNumero
{
    public class Game
    {
        #region "Enums"
        public enum eGameState
        {
            Start,
            InGame,
            End
        }

        public enum AttemptResult
        {
            Guessed,
            Lower,
            Greater
        }

        #endregion
        #region "Attributes"

        const int MIN = 1, MAX = 1000;
        const string DEFAULTPATH = "score.txt";
        public string ScorePath { get; set; }
        public int SecretNumber { get; set; }
        public eGameState CurrentState { get; set; }
        public int LastTry { get; set; }
        public int Attempts { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan timeSpan { get {
                return EndTime.Subtract(StartTime);
            } }
        #endregion

        #region "Behaviours"
        public void GameInit()
        {
            ScorePath = DEFAULTPATH;
            SecretNumber = GenerateNumber(MIN, MAX);
            CurrentState = eGameState.Start;
            Attempts = 0;
            StartTime = DateTime.Now;
        }

        private int GenerateNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public AttemptResult CheckIfGuessed()
        {
            Attempts++;
            if (LastTry == SecretNumber)
            {
                EndTime = DateTime.Now;
                return AttemptResult.Guessed;
            }
                
            if (LastTry < SecretNumber)
                return AttemptResult.Lower;
            else
                return AttemptResult.Greater;
        }

        public void SaveState()
        {
            /*using (FileStream fstream = File.Open(ScorePath, FileMode.Append))
            {
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
                var buffer = unicodeEncoding.GetBytes($"Tiempo: {timeSpan.TotalSeconds} - Intentos: {Attempts}");
                fstream.Write(buffer, 0, buffer.Length);
            }*/
            var streamWriter = File.AppendText(ScorePath);
            streamWriter.Write($"Tiempo: {timeSpan.TotalSeconds} - Intentos: {Attempts}\n");
            streamWriter.Flush();
            streamWriter.Close();
        }

        public string ReadScores()
        {
            return File.ReadAllText(ScorePath);
        }
        #endregion
    }
}
