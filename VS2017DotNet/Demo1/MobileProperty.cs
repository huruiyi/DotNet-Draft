namespace Demo1
{
    //手机属性实现类
    public class MobileProperty : IMobilePhoneProperty
    {
        public string Ram { get; set; }

        public string Rom { get; set; }

        public string Cpu { get; set; }

        public int Size { get; set; }

        public string Pixel { get; set; }
    }
}