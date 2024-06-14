#include <stdio.h>
#include <math.h>

int snt(int a){
	if(a<2) return 0;
	int i;
	for(i=2; i<=sqrt(a); i++){
		if(a%i==0) return 0;
	}
	return 1;
}

int sntt(int a){
	int n;
	while(a!=0){
		n=a%10;
		a/=10;
		if(n!=2 || n!=3 || n!=5 || n!=7) return 0;
	}return 1;
}

int main(){
	int a, b, sum = 0;
	scanf("%d %d", &a, &b);
	int i;
	for(i=a; i<=b; i++){
		if(snt(i) && sntt(i)) sum++;
	}printf("%d", sum);
}