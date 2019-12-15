namespace Tools.DialogSystem
{
    public partial class DialogSystem
    {
        /// <summary>
        ///     Base dialog component.
        /// </summary>
        abstract class DialogSubComponent
        {
            protected DialogSubComponent(IDialogSystem system) => DialogSystem = system;

            /// <summary>
            ///     The parent Dialog.
            /// </summary>
            public IDialogSystem DialogSystem { get; }
        }
    }
}