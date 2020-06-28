using HexBoardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiMenuElements : MonoBehaviour
    {
        [SerializeField] private BoardElementsController controller;
        
        [Header("Itens"), SerializeField] private ItemData apple;
        [SerializeField] private ItemData banana;
        [SerializeField] private ItemData grape;
        
        [Header("Creatures"), SerializeField] private CreatureData jellyfish;
        [SerializeField] private CreatureData octopus;
        [SerializeField] private CreatureData turtle;

        [Header("Menu Buttons"), SerializeField] private Button jellyfishButton;
        [SerializeField] private Button appleButton;
        [SerializeField] private Button bananaButton;
        [SerializeField] private Button grapeButton;
        [SerializeField] private Button octopusButton;
        [SerializeField] private Button turtleButton;
        [SerializeField] private Button removeButton;
        [SerializeField] private Button pathButton;

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