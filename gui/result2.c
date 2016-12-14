#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    char *data;
    long num1, num2;
    printf("%s%c%c\n", "Content-Type:text/html;charset=iso-8859-1",13,10);
    
    printf("<style>");
    printf("H2 {");
    printf("color: red;");
    printf("margin-top: 150px;");
    printf("text-align: center;");
    printf("font-size: 25px;");
    printf("font-weight: bold;");
    printf("}");
    printf("P {");
    printf("text-align: center;");
    printf("font-size: 15px;");
    printf("}");
    printf("</style>");
    
    printf("<H2>Multiplication:</H2>\n");
    data = getenv("QUERY_STRING");
    
    if( (data == NULL) || (sscanf(data,"num1=%ld&num2=%ld", &num1, &num2)!=2))
        printf("<P>Please enter 2 numbers!");
    else
        printf("<P>%ld x %ld = %ld", num1, num2, (num1*num2));
    
    return 0;
}