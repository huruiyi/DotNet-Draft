namespace Demo2
{
    //手机基础属性实现
    public class MobilePhoneBaseProperty : IMobilePhoneBaseProperty
    {
        public string Ram { get; set; }

        public string Rom { get; set; }

        public string Cpu { get; set; }

        public int Size { get; set; }
    }
}