using NativeFileDialogDotNet.Internal;
using System;

namespace NativeFileDialogDotNet
{
    public class FolderPickerDialog : Dialog
    {
        public override NfdResult Show()
        {
            var defaultPath = StringHelper.EncodeUtf8String(DefaultPath);

            var result = Nfd.NFD_PickFolder(defaultPath, out var outPath);

            Reset();

            switch (result)
            {
                case nfdresult_t.NFD_ERROR:
                    var error = Nfd.NFD_GetError();
                    var message = StringHelper.DecodeUtf8String(error);
                    throw new NfdException(message);

                case nfdresult_t.NFD_OKAY:
                    Path = StringHelper.DecodeUtf8String(outPath);
                    return NfdResult.Okay;

                case nfdresult_t.NFD_CANCEL:
                    return NfdResult.Cancel;
            }

            throw new ArgumentOutOfRangeException(nameof(result));
        }
    }
}
