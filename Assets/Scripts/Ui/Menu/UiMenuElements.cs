using HexBoardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiMenuElements : MonoBehaviour
    {
        [Header("Itens"), SerializeField] ItemData apple;
        [SerializeField] Button appleButton;
        [SerializeField] ItemData banana;
        [SerializeField] Button bananaButton;
        [SerializeField] BoardElementsController controller;
        [SerializeField] ItemData grape;
        [SerializeField] Button grapeButton;

        [Header("Creatures"), SerializeField] CreatureData jellyfish;

        [Header("Menu Buttons"), SerializeField]
        Button jellyfishButton;

        [SerializeField] CreatureData octopus;
        [SerializeField] Button octopusButton;

        [Header("Remove"), SerializeField] Button removeButton;
        [SerializeField] CreatureData turtle;
        [SerializeField] Button turtleButton;

        void Awake()
        {
            BindClickEvents();
            BindArtwork();
        }

        void BindArtwork()
        {
            jellyfishButton.image.sprite = jellyfish.GetArtwork();
            octopusButton.image.sprite = octopus.GetArtwork();
            turtleButton.image.sprite = turtle.GetArtwork();
            bananaButton.image.sprite = banana.GetArtwork();
            appleButton.image.sprite = apple.GetArtwork();
            grapeButton.image.sprite = grape.GetArtwork();
        }

        void BindClickEvents()
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