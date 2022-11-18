#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

int exploit();
int main(int argc, char** argv) {
    char command[256];
    int commandCheck;
    char temp[100];
    MYSQL_ROW row;
    MYSQL* conn = mysql_init(NULL);
    char* ret;
    const char special[] = "!@#$%^&*(){}:;<>',.-";
    char *ret2;
	
    //connect to database
    if (mysql_real_connect(conn, "localhost", "root", "1111", "Wiki", 0, NULL, 0) == NULL) {
        printf("Connection Failed\n");
        exit(1);
    }
    strcat(temp, argv[1]);
    ret = getenv("MYSQL_HOME");
    int z = 2;
    char blank[] = " ";
    while(1){
        if(argv[z] == NULL){
            break;
	}
	strcat(temp, blank);
	strcat(temp, argv[2]);
	z++;
    } 
    // construct query
	
    for(int i = 1; i<argc; i++) {
    	ret2 = strpbrk(argv[i], special);
    	if(ret2) {
		return 0;
  	}
    }
    commandCheck = snprintf(command, sizeof command, "SELECT description FROM Information WHERE word = \'%s\';", temp);

    if (mysql_real_query(conn, command, 250) != 0) { //check information
        printf("Not Connected to Database\n");
	sprintf(temp, "Current directory is %s", ret);
	printf("%s\n", temp);
        return 0;
    }
    else {
        MYSQL_RES* result = mysql_store_result(conn);
        if (mysql_num_rows(result) != 0) {
            row = mysql_fetch_row(result);
            printf("%s\n", row[0]);
            mysql_close(conn);
        }
        else {
            mysql_close(conn);
            printf("No description exists for the word %s. To add a description, please edit the word description.\n", temp);
	    return 2;
        }
        return 1;
    }
}

int exploit() {
    printf("[Team Ate] Dummy Function for PoC\n");
    return 0;
}
