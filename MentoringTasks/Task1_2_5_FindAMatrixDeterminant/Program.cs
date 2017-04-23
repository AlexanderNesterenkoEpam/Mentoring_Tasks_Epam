using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_5_FindAMatrixDeterminant
{
    
    public class Program
    {
        public int n;
        int[,] mtx;
        int[,] temp_matrix;
        int i, j;
        int det_res; //определитель

        public static void Main(string[] args)
        {
            Program pr = new Program();
            pr.method();
            int [,] matix = MatixOperations.GenerateRandomMatrix(2,2);
            ConsoleOperations op = new ConsoleOperations();
            op.ShowMatrix(matix);
            int determinant = pr.det(matix, 2);
            Console.WriteLine(determinant);
        }

        
       public void method()
       {
          n=2;	//размерность массива
	      mtx = new int[n, n];	//матрица
	      temp_matrix = new int[n, n];
       }
   

    public void get_matr(int [,] matrix, int kolvo, int i,int j)	//процедура вычеркивания строки и столбца
    {
	    int ki,kj,di,dj;
	    di = 0;
	for (ki=0;ki<kolvo-1;ki++)
	{
		if (ki==i) di=1;
		dj=0;
		for (kj=0;kj<kolvo-1;kj++)
		{
			if (kj==j) dj=1;
			temp_matrix[ki,kj]=matrix[ki+di,kj+dj];
		}
	}
}


public int det(int[,] matrix, int count)	//функция вычисления определителя(матрица,размерность)
{
	int temp=0;	//временная переменная для хранения определителя
	int k=1;	//степень
/*=============================================================================================================
													вычисление определителей
==============================================================================================================*/
	if(count<1){
		Console.WriteLine("Not run");
                return 0;
        }
	else if (count==1)
		temp= matrix[0,0];
	else if (count==2)
		temp=matrix[0,0]*matrix[1,1]-matrix[1,0]*matrix[0,1];
	else
	{
		for(i=0;i<count;i++)
		{
			get_matr(matrix,count,i,0);
			
			temp=temp+k*matrix[i,0]*det(temp_matrix,count-1);
			k=-k;
		}
	}
	return temp;
        }

    }
}

