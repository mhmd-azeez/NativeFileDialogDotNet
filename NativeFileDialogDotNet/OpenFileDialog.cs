using NativeFileDialogDotNet.Internal;
using System;
using System.Collections.Generic;

namespace NativeFileDialogDotNet
{
    public class OpenFileDialog : FileDialog
    {
        public bool SelectMultipleFiles { get; set; }

        public IReadOnlyList<string> Paths { get; private set; }

        public override NfdResult Show()
        {
            var filter = StringHelper.EncodeUtf8String(Filter);
            var defaultPath = StringHelper.EncodeUtf8String(DefaultPath);

            if (SelectMultipleFiles)
                return ShowMultiple(filter, defaultPath);
            else
                return ShowSingle(filter, defaultPath);
        }

        private NfdResult ShowMultiple(byte[] filter, byte[] defaultPath)
        {
            var result = Nfd.NFD_OpenDialogMultiple(filter, defaultPath, out var pathSet);

            Reset();

            switch (result)
            {
                case nfdresult_t.NFD_ERROR:
                    var error = Nfd.NFD_GetError();
                    var message = StringHelper.DecodeUtf8String(error);
                    throw new NfdException(message);

                case nfdresult_t.NFD_OKAY:
                    var paths = new List<string>();

                    for (uint i = 0; i < pathSet.count; i++)
                    {
                        var path = Nfd.NFD_PathSet_GetPath(in pathSet, i);
                        paths.Add(StringHelper.DecodeUtf8String(path));
                    }

                    Nfd.NFD_PathSet_Free(ref pathSet);

                    Path = paths[0];
                    Paths = paths;

                    return NfdResult.Okay;

                case nfdresult_t.NFD_CANCEL:
                    return NfdResult.Cancel;
            }

            throw new ArgumentOutOfRangeException(nameof(result));
        }

        private NfdResult ShowSingle(byte[] filter, byte[] defaultPath)
        {
            var result = Nfd.NFD_OpenDialog(filter, defaultPath, out var outPath);

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

        protected override void Reset()
        {
            base.Reset();
            Paths = null;
        }
    }
}
