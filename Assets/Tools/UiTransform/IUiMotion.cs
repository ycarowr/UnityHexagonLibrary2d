namespace Tools.UiTransform
{
    public interface IUiMotion
    {
        UiMotionBase Movement { get; }
        UiMotionBase Rotation { get; }
        UiMotionBase Scale { get; }
    }
}