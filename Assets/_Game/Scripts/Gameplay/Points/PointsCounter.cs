using DG.Tweening;
using GameRoot;
using R3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Gameplay
{ 
    public class PointsCounter
    {
        private Vector2 _accumulationPosition;
        private Points _accumulativePoints;

        public PointsCounter(Vector2 position)
        {
            _accumulationPosition = position;
        }

        public Observable<Points> StartCounting(IEnumerable<WordUnit> wordUnits)
        {
            var onCompleted = new Subject<Points>();
            _accumulativePoints = null;

            Coroutines.Start(CountingRoutine(wordUnits, onCompleted));

            return onCompleted;
        }

        public Observable<Points> AddMultipliers(IEnumerable<PointsMultiplierData> multipliers, Vector2 position)
        {
            if (_accumulativePoints == null) return Observable.Return(_accumulativePoints);

            var onCompleted = new Subject<Points>();
            Coroutines.Start(AddMultipliersRoutine(multipliers, position, onCompleted));

            return onCompleted;
        }

        private IEnumerator CountingRoutine(IEnumerable<WordUnit> wordUnits, Subject<Points> onCompleted)
        {
            var allPoints = new List<Points>();

            yield return ExtractPointsRoutine(wordUnits, allPoints);
            
            if (_accumulativePoints == null)
                _accumulativePoints = allPoints[0];

            yield return MoveToAccumulationPositionRoutine(allPoints);

            onCompleted.OnNext(_accumulativePoints);
            onCompleted.OnCompleted();
        }

        private IEnumerator AddMultipliersRoutine(IEnumerable<PointsMultiplierData> multipliers, Vector2 position, Subject<Points> onCompleted)
        {
            yield return new WaitForSeconds(0.5f);

            foreach (var multiplier in multipliers)
            {
                var createdPoints = G.PointsFactory.Create(multiplier.Points, "x", multiplier.Message, position);

                yield return new WaitForSeconds(0.25f);

                var isSended = false;
                createdPoints.SendToAccumulator().OnComplete(() =>
                {
                    _accumulativePoints.Multiply(multiplier.Points);
                    _accumulativePoints.Pop();
                    isSended = true;
                    Object.Destroy(createdPoints);
                });

                yield return new WaitUntil(() => isSended);
            }

            onCompleted.OnNext(_accumulativePoints);
            onCompleted.OnCompleted();
        }

        private IEnumerator ExtractPointsRoutine(
            IEnumerable<WordUnit> wordUnits, List<Points> outPoints)
        {
            foreach (var wordUnit in wordUnits)
            {
                var createdPoints = G.PointsFactory.Create(wordUnit.Points, "+", "", wordUnit.PointsSpawnPosition);
                outPoints.Add(createdPoints);

                yield return new WaitForSeconds(0.25f);
            }
        }

        private IEnumerator MoveToAccumulationPositionRoutine(IEnumerable<Points> allPoints)
        {
            foreach (var points in allPoints)
            {
                MoveToAccumulationPosition(points);
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void MoveToAccumulationPosition(Points points)
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
