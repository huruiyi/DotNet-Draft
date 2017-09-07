using BankInterface;
using System.ComponentModel.Composition;

namespace BankOfChina
{
    [Export(typeof(ICard))]
    public class ZHCard : ICard
    {
        public string GetCountInfo()
        {
            return "Bank Of China";
        }

        public void SaveMoney(double money)
        {
            this.Money += money;
        }

        public void CheckOutMoney(double money)
        {
            this.Money -= money;
        }

        public double Money { get; set; }
    }
}