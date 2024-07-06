#include <stdio.h>
#include <math.h>

static int a[20];

int prime(){
    int i, j;
	
	a[0]=0;
	a[1]=0;
	for(i=2; i<=19; i++){
		a[i]=1;
	}
	
    for(i=2; i<=sqrt(19); i++){
        if(a[i]){
        	for(j=i*i; j<=19; j+=i) a[j]=0;
		}
    }
}

int main(){
    int n, i = 1;

    scanf("%d", &n);

    prime();
    while((pow(2, i-1) * (pow(2, i)-1)) < n){
        while(i++){
            if(a[i]) break;
        }

        printf("%.0lf ", pow(2, i-1) * (pow(2, i)-1));
        printf("%d\n", i);
    }
}