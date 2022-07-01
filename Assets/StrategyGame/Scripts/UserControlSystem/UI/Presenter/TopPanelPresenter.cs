using TMPro;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System;
using UniRx;

public class TopPanelPresenter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputFielt;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menuGo;

    [Inject]
    private void Init(ITimeModel timeModel)
    {
        timeModel.GameTime.Subscribe(seconds =>
        {
            var t = TimeSpan.FromSeconds(seconds);
            _inputFielt.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        });

        _menuButton.OnClickAsObservable().Subscribe(_ => _menuGo.SetActive(true));
    }
}
