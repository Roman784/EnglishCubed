using UnityEngine;

namespace GameProducer
{
    public class GameProducerContext
    {
        public int CurrentStageNumber { get; private set; }
        public int TotalStageNumbers { get; private set; }

        public float StageProgress => (float)CurrentStageNumber / TotalStageNumbers;

        public void SetCurrentStageNumber(int number)
        {
            CurrentStageNumber = number;
            ClampStageNumbers();
        }

        public void SetTotalStageNumbers(int number)
        {
            TotalStageNumbers = number;
            ClampStageNumbers();
        }

        private void ClampStageNumbers()
        {
            CurrentStageNumber = Mathf.Clamp(
                CurrentStageNumber, 0, Mathf.Min(CurrentStageNumber, TotalStageNumbers));
            TotalStageNumbers = Mathf.Clamp(
                TotalStageNumbers, 0, Mathf.Max(CurrentStageNumber, TotalStageNumbers));
        }
    }
}