using ltrModulesNet;

namespace SafeServer.ltr
{
    interface ILtr
    {
        _LTRNative.LTRERROR Start();

        void Stop();
    }
}
