Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: 计算器加法
	Given 输入第一个参数"50"到计算器
	And 输入第二个参数"70"到计算器
	When 点击加法计算
	Then 结果显示"120"

Scenario: 计算器减法
	Given 输入第一个参数"40"到计算器
	And 输入第二个参数"70"到计算器
	When 点击减法计算
	Then 结果显示"-30"