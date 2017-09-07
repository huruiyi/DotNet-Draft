namespace Demo1
{
    //手机属性接口
    public interface IMobilePhoneProperty
    {
        //运行内存
        string Ram { get; set; }

        //手机存储内存
        string Rom { get; set; }

        //CPU主频
        string Cpu { get; set; }

        //屏幕大小
        int Size { get; set; }

        //摄像头像素
        string Pixel { get; set; }
    }
}