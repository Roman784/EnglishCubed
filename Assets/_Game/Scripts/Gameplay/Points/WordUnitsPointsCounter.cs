using DG.Tweening;
using R3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Gameplay
{ 
    public class WordUnitsPointsCounter
    {
        private const float DELAY_BETWEEN_EXTRACTION = 0.25f;
        private const float DELAY_BETWEEN_MOVEMENT_TO_ACCUMULUTATION = 0.5f;

        private Vector2 _accumulationPosition;
        private WordUnitPoints _accumulativePoints;

        public Observable<WordUnitPoints> StartCounting(IEnumerable<WordUnit> wordUnits, Vector2 accumulationPosition)
        {
            var onCompleted = new Subject<WordUnitPoints>();
            _accumulativePoints = null;
            _accumulationPosition = accumulationPosition;

            Coroutines.Start(CountingRoutine(wordUnits, onCompleted));

            return onCompleted;
        }

        private IEnumerator CountingRoutine(IEnumerable<WordUnit> wordUnits, Subject<WordUnitPoints> onCompleted)
        {
            var allPoints = new List<WordUnitPoints>();

            yield return ExtractPointsRoutine(wordUnits, allPoints);
            
            if (_accumulativePoints == null)
                _accumulativePoints = allPoints[0];

            yield return MoveToAccumulationPositionRoutine(allPoints);

            onCompleted.OnNext(_accumulativePoints);
            onCompleted.OnCompleted();
        }

        private IEnumerator ExtractPointsRoutine(
            IEnumerable<WordUnit> wordUnits, List<WordUnitPoints> outPoints)
        {
            foreach (var wordUnit in wordUnits)
            {
                var createdPoints = wordUnit.ExtractPoints();
                outPoints.Add(createdPoints);

                yield return new WaitForSeconds(DELAY_BETWEEN_EXTRACTION);
            }
        }

        private IEnumerator MoveToAccumulationPositionRoutine(IEnumerable<WordUnitPoints> allPoints)
        {
            foreach (var points in allPoints)
            {
                MoveToAccumulationPosition(points);
                yield return new WaitForSeconds(DELAY_BETWEEN_MOVEMENT_TO_ACCUMULUTATION);
            }
        }

        private void MoveToAccumulationPosition(WordUnitPoints points)
        {
            if (points == _accumulativePoints)
            {
                points.MoveToAccumulator(_accumulationPosition).OnComplete(() =>
                {
                    points.TurnIntoAccumulator();
                    _accumulativePoints.Pop();
                });
            }
            else
            {
                points.SendToAccumulator().OnComplete(() =>
                {
                    _accumulativePoints.Plus(points.Value);
                    _accumulativePoints.Pop();

                    Object.Destroy(points.gameObject);
                });
            }
        }
    }
}
