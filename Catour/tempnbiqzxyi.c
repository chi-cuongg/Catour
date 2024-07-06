#include <stdio.h>
#include <math.h>
#include <stdbool.h>
void swap(int *a, int *b){
	int temp = *a;
	*a = *b;
	*b = temp;
}

bool snt(int n){
	if(n<=1) return 0;
	int i;
	for(i=2; i<=sqrt(n); i++){
		if(n%i==0) return 0;
	}
	return 1;
}

bool fibo(int a){
	int sum=0;
	while(a>0){
		sum += a%10;
		a/=10;
	}
	if(sum==1 || sum==2 || sum==3 || sum==5 || sum==8 || sum==13 || sum== 21) return 1;
	else return 0;
}

int main(){
	int a, b;
	scanf("%d%d", &a, &b);
	if(a>b) swap(&a, &b);
	int i;
	for(i=a; i<=b; i++){
		if(snt(i) && fibo(i)) printf("%d ", i);
	}
}