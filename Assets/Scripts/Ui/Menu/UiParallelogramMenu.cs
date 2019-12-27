﻿using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiParallelogramMenu : UiParentMenu
    {
        [SerializeField] Button confirmButton;
        [SerializeField] ParallelogramBoardDataShape dataShape;
        [SerializeField] Slider height;
        [SerializeField] Slider width;

        protected override void Awake()
        {
            base.Awake();
            confirmButton.onClick.AddListener(OnConfirm);
        }

        void OnConfirm()
        {
            dataShape.width = (int) width.value;
            dataShape.height = (int) height.value;
            boardController.SetBoarDataAndCreate(dataShape);
        }
    }
}