#include <stdio.h>
#include <stdlib.h>
int main(void)
{
char *data;
long num1,num2;
printf("%s%c%c\n",
"Content-Type:text/html;charset=iso-8859-1",13,10);
printf("<TITLE>Multiplication results</TITLE>\n");
printf("<H3>Multiplication results</H3>\n");
data = getenv("QUERY_STRING");
if(data == NULL)
  printf("<P>Error! Error in passing data from form to script.");
else if(sscanf(data,"num1=%ld&num2=%ld",&num1,&num2)!=2)
  printf("<P>Error! Invalid data. Data must be numeric.");
else
  printf("<P>The product of %ld and %ld is %ld.",num1,num2,num1*num1);
return 0;
}