namespace Demo1
{
    //具体的手机实例
    public class HuaweiMobile
    {
        private IMobilePhoneProperty _mProperty;
        private IMobilePhoneFunction _mFunc;

        public HuaweiMobile(IMobilePhoneProperty oProperty, IMobilePhoneFunction oFunc)
        {
            _mProperty = oProperty;
            _mFunc = oFunc;
        }
    }
}