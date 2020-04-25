using HexBoardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiMenuElements : MonoBehaviour
    {
        [Header("Itens"), SerializeField] private ItemData apple;
        [SerializeField] private Button appleButton;
        [SerializeField] private ItemData banana;
        [SerializeField] private Button bananaButton;
        [SerializeField] private BoardElementsController controller;
        [SerializeField] private ItemData grape;
        [SerializeField] private Button grapeButton;

        [Header("Creatures"), SerializeField] private CreatureData jellyfish;

        [Header("Menu Buttons"), SerializeField]
        private Button jellyfishButton;

        [SerializeField] private CreatureData octopus;
        [SerializeField] private Button octopusButton;

        [Header("Remove"), SerializeField] private Button removeButton;
        [SerializeField] private CreatureData turtle;
        [SerializeField] private Button turtleButton;

        private void Awake()
        {
            BindClickEvents();
            BindArtwork();
        }

        private void BindArtwork()
        {
            jellyfishButton.image.sprite = jellyfish.GetArtwork();
            octopusButton.image.sprite = octopus.GetArtwork();
            turtleButton.image.sprite = turtle.GetArtwork();
            bananaButton.image.sprite = banana.GetArtwork();
            appleButton.image.sprite = apple.GetArtwork();
            grapeButton.image.sprite = grape.GetArtwork();
        }

        private void BindClickEvents()
        {
            jellyfishButton.onClick.AddListener(() => controller.SetElementProvider(jellyfish));
            octopusButton.onClick.AddListener(() => controller.SetElementProvider(octopus));
            turtleButton.onClick.AddListener(() => controller.SetElementProvider(turtle));
            bananaButton.onClick.AddListener(() => controller.SetElementProvider(banana));
            appleButton.onClick.AddListener(() => controller.SetElementProvider(apple));
            grapeButton.onClick.AddListener(() => controller.SetElementProvider(grape));
            removeButton.onClick.AddListener(() => controller.SetElementProvider(null));
        }
    }
}