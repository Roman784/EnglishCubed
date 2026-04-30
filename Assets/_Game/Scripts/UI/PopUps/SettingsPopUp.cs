using Audio;
using GameRoot;
using GameState;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsPopUp : PopUp
    {
        [Space]

        [SerializeField] private Slider _musicVolumeView;
        [SerializeField] private Slider _soundVolumeView;

        [SerializeField] private GameObject _mainMenuButton;

        private void Start()
        {
            _musicVolumeView.onValueChanged.AddListener(volume => ChangeMusicVolume(volume));
            _soundVolumeView.onValueChanged.AddListener(volume => ChangeSoudVolume(volume));
        }

        public void Open(bool activeMainMenuButton)
        {
            _mainMenuButton.SetActive(activeMainMenuButton);

            _musicVolumeView.value = G.AudioProvider.MusicVolume.CurrentValue;
            _soundVolumeView.value = G.AudioProvider.SoundVolume.CurrentValue;

            base.Open();
        }

        public override void Close()
        {
            SaveAudioState();
            base.Close();
        }

        public void OpenMainMenu()
        {
            SaveAudioState();
            G.SceneProvider.OpenMainMenu();
        }

        private void ChangeMusicVolume(float volume)
        {
            G.AudioProvider.MusicVolume.OnNext(volume);
        }

        private void ChangeSoudVolume(float volume)
        {
            G.AudioProvider.SoundVolume.OnNext(volume);
        }

        private void SaveAudioState()
        {
            G.Repository.Audio.SetMusicVolume(_musicVolumeView.value);
            G.Repository.Audio.SetSoundVolume(_soundVolumeView.value);
        }
    }
}