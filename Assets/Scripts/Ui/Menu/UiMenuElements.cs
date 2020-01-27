using HexBoardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.UI;

namespace HexBoardGame.UI
{
    public class UiMenuElements : MonoBehaviour
    {
        [SerializeField] BoardElementsController controller;
        
        [Header("Itens"), SerializeField] ItemData apple;
        [SerializeField] ItemData banana;
        [SerializeField] ItemData grape;
        
        [Header("Creatures"), SerializeField] CreatureData jellyfish;
        [SerializeField] CreatureData octopus;
        [SerializeField] CreatureData turtle;

        [Header("Menu Buttons"), SerializeField] Button jellyfishButton;
        [SerializeField] Button appleButton;
        [SerializeField] Button bananaButton;
        [SerializeField] Button grapeButton;
        [SerializeField] Button turtleButton;
        [SerializeField] Button octopusButton;
        
        [Header("Remove"), SerializeField] Button removeButton;
        
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