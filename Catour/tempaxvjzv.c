#include <stdio.h>
#include <math.h>
#include <stdbool.h>

void solve(){
	int a[101]; int b[101];
	int m, n;
	int p;
	scanf("%d %d %d", &m, &n, &p);
	int i;
	for(i=1; i<=m; i++){
		scanf("%d", &a[i]);
	}
	for(i=1; i<=n; i++){
		scanf("%d", &b[i]);
	}
	int t=1;
	printf("Test %d:\n", t);
	for(i=1; i<=m+n; i++){
		if(i<=p) printf("%d ", a[i]);
		else if(i>p && i<=n+p) printf("%d ", b[i-p]);
		else printf("%d ", a[i-n]);
	}
	t++;
}

int main(){
	int a;
	scanf("%d", &a);
	int t;
	for(t=1; t<=a; t++){
		solve();
	}
}