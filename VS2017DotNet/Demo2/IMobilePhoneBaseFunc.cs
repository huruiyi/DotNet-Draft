namespace Demo2
{
    //手机基础功能接口
    public interface IMobilePhoneBaseFunc
    {
        //手机充电接口
        void Charging(ElectricSource oElectricsource);

        //打电话
        void RingUp();

        //接电话
        void ReceiveUp();
    }
}