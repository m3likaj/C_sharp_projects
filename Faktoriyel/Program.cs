int FactorialRec (int num){
    if (num == 0 || num == 1)
        return 1;
    else if (num<0)
        return -1;
    return num * FactorialRec(num-1);
}
int FactorialIter(int num){
    int factorial = 1;
    if (num<0)
        factorial = -1;
    while(num > 1){
        factorial *= num;
        num--;
    }
    return factorial;
}

int num = 3;
int factorial = FactorialIter(num);
if(factorial>0)
    Console.WriteLine($"Factorial of {num} = {factorial}");
else
    Console.WriteLine("Invalid input");