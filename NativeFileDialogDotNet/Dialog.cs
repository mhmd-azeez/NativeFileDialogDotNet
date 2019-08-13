namespace NativeFileDialogDotNet
{
    public abstract class Dialog
    {
        public string DefaultPath { get; set; }

        public string Path { get; protected set; }

        public abstract NfdResult Show();

        protected virtual void Reset()
        {
            Path = null;
        }
    }
}
