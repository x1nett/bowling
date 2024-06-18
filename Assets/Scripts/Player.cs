using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private int[] rolls = new int[20];
        private int currentRoll = 0;
        private int finalScore;

        public Text[] scoreText;
        public Text playerText;
        public Text finalScoreText;

        public void AddScore(int pinCount)
        {
            rolls[currentRoll] = pinCount;
            UpdateScoreText(pinCount);
            UpdateScore();
            currentRoll++;
        }

        private void UpdateScoreText(int pinCount)
        {
            if (IsStrike(currentRoll))
            {
                scoreText[currentRoll].text = "X";
                currentRoll++;
            }
            else if (currentRoll % 2 != 0 && IsSpare(currentRoll))
            {
                scoreText[currentRoll].text = "/";
            }
            else
            {
                scoreText[currentRoll].text = rolls[currentRoll].ToString();
            }
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex - 1] == 10;
        }

        public void UpdateScore()
        {
            finalScore = CalculateScore();
            finalScoreText.text = finalScore.ToString();
        }

        private int CalculateScore()
        {
            int score = 0;
            int rollIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += 10 + StrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (rollIndex % 2 != 0 && IsSpare(rollIndex))
                {
                    score += 10 + SpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        private int StrikeBonus(int rollIndex)
        {
            return rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private int SpareBonus(int rollIndex)
        {
            return rolls[rollIndex + 2];
        }

        private int SumOfBallsInFrame(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        internal void SetName(string name)
        {
            playerText.text = name;
        }
    }
}
