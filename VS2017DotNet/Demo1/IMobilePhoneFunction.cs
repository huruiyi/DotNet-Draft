namespace Demo1
{
    //手机功能接口
    public interface IMobilePhoneFunction
    {
        //手机充电接口
        void Charging(ElectricSource oElectricsource);

        //打电话
        void RingUp();

        //接电话
        void ReceiveUp();

        //上网
        void SurfInternet();

        //移动办公
        void MobileOa();
    }
}