using System;
using JetBrains.Annotations;
using R3;
using TMPro;
using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    public sealed class HudView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _coinsCountText;

        private IDisposable _disposable;

        public void Initialize(HudViewModel viewModel)
        {
            var disposableBuilder = Disposable.CreateBuilder();

            viewModel.Coins.Subscribe(ViewModel_Coins_OnChanged).AddTo(ref disposableBuilder);

            _disposable = disposableBuilder.Build();
        }

        private void ViewModel_Coins_OnChanged(int value)
        {
            _coinsCountText.text = value.ToString();
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _disposable?.Dispose();
            _disposable = default;
        }
    }
}
