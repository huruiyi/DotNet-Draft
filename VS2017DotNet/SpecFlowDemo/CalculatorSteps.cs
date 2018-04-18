using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDemo
{
    [Binding]
    public class CalculatorSteps
    {
        Calculator calculator = new Calculator();

        [Given(@"输入第一个参数""(.*)""到计算器")]
        public void Given输入第一个参数到计算器(double p0)
        {
            calculator.First = p0;
        }
        
        [Given(@"输入第二个参数""(.*)""到计算器")]
        public void Given输入第二个参数到计算器(double p0)
        {
            calculator.Second = p0;
        }
        
        [When(@"点击加法计算")]
        public void When点击加法计算()
        {
            calculator.Add();
        }

        [When(@"点击减法计算")]
        public void When点击减法计算()
        {
            calculator.Subtraction();
        }

        [Then(@"结果显示""(.*)""")]
        public void Then结果显示(double p0)
        {
            Assert.AreEqual(p0, calculator.Result);
        }
    }
}
