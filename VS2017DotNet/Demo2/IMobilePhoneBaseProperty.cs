namespace Demo2
{
    //手机基础属性接口
    public interface IMobilePhoneBaseProperty
    {
        //运行内存
        string Ram { get; set; }

        //手机存储内存
        string Rom { get; set; }

        //CPU主频
        string Cpu { get; set; }

        //屏幕大小
        int Size { get; set; }
    }
}