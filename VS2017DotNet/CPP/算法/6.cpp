//��1��2��3��4,5�����֣�����ɶ��ٸ�������ͬ�����ظ����ֵ�4λ�������Ƕ��٣�

//   _  _ _
//   1  1  1
//   2  2  2
//   3  3  3
//   4  4  4
#include<stdio.h>
#include <stdlib.h>
#include<math.h>

//���ȸ㶨���п��ܣ�Ȼ��ɸ�������������ġ�
//ѭ��������ʵ�ֱ������еĿ��ܣ�Ȼ��ɸ�������������ġ�
int method_exhaustion(int number)
{
	for (int i = 1; i <= number; i++)//������λ
	{
		for (int j = 1; j <= number; j++)//����ʮλ
		{
			for (int k = 1; k <= number; k++)//������λ
			{
				if (i != j && j != k && i != k)
				{
					printf("%d%d%d\n", i, j, k);
				}
			}
		}
	}
	return 0;
}
int method_exhaustion(int number);
int main6()//main()
{
	int a;
	scanf_s("%d", &a);
	method_exhaustion(a);
	system("pause");
	return 0;
}