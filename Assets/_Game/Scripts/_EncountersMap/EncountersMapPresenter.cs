using UnityEngine;

namespace EncountersMap
{
    public class EncountersMapPresenter
    {
        private EncountersMapView _view;
        private EncountersMapModel _model;

        public EncountersMapPresenter(EncountersMapView view, EncountersMapModel model)
        {
            _view = view;
            _model = model;

            SetupSubscriptions();
        }

        private void SetupSubscriptions()
        {

        }
    }
}