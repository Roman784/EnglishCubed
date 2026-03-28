using GameRoot;
using GameState;
using R3;
using UnityEngine;

namespace Currency
{
    public class Wallet
    {
        private int _coins;
        private int _lastSavedCoins;

        private Subject<int> _coinsChangedSignalSubj = new();
        private CurrencyRepository Repository => G.Repository.Currency;
        
        public int Coins => _coins;
        public Observable<int> CoinsChangedSignal => _coinsChangedSignalSubj;


        public Wallet()
        {
            _coins = Repository.GetCoins();
        }

        public void Save()
        {
            if (_coins == _lastSavedCoins) return;

            _lastSavedCoins = _coins;
            Repository.SetCoins(_coins);
        }

        public void AddCoins(int value, bool save = true)
        {
            _coins += value;
            _coinsChangedSignalSubj.OnNext(_coins);

            if (save) Save();
        }

        public bool TrySpendCoins(int value, bool save = true)
        {
            if (value > _coins) return false;

            _coins -= value;
            _coinsChangedSignalSubj.OnNext(_coins);

            if (save) Save();
            return true;
        }
    }
}