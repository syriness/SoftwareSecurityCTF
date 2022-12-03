#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <mysql.h>
#include <string.h>

#define MAX_LEN 20

int exploit(void);
char* concat(const char* s1, const char* s2);

int main(int argc, char** argv) {
	//FILE* fp;
	char command[256];
	int commandCheck;
	MYSQL_ROW row;
	MYSQL* conn = mysql_init(NULL);
	const char special[] = "!@#$%^&*(){}:;<>',.-";
	char *ret;
	
	int isNewKeyword = 0;

	if (argc != 3){
		printf("Arguments number must be two.\n");
		return 0;
	}
	else if(argc == 3){
		printf("\nStarting Mysql connecting : ");
	}

	//connect to database
	if (mysql_real_connect(conn, "localhost", "root", "1111", "Wiki", 0, NULL, 0) == NULL) {
		printf("Connection Failed");
		return 0;
	}

	 for(int i = 1; i<argc; i++) {
  		ret = strpbrk(argv[i], special);
  		if(ret) {
			return 0;
		}
	}
	
	commandCheck = snprintf(command, sizeof command, "SELECT * FROM Information WHERE word=\'%s\';", argv[1]);
	if (mysql_real_query(conn, command, 250) != 0) {
		printf("query failed\n");
	}
	else {
		MYSQL_RES* result = mysql_store_result(conn);
		int resnum = mysql_num_rows(result);
		if(resnum == 1){
			printf("**Existing Keyword**\n");
			isNewKeyword = 0;
		}
		else if(resnum == 0) {
			printf("**New Keyword**\n");
			isNewKeyword = 1;
		}
	}

	//insert record into database with tempfile
	char descriptionStr[MAX_LEN];
	char* content = "";

	if(isNewKeyword == 1){
		commandCheck = snprintf(command, sizeof command, "INSERT INTO Information VALUES (\'%s\', \'%s\');", argv[1], argv[2]);
		mysql_real_query(conn, command, 250);
	}
	else if(isNewKeyword == 0){
		commandCheck = snprintf(command, sizeof command, "UPDATE Information SET description=\'%s\' WHERE word=\'%s\';", argv[2], argv[1]);
		mysql_real_query(conn, command, 250);
	}
	fprintf(stdout, "\n**Database Wrote**\n");

	return 0;
}

int exploit() {
	printf("[Team Ate] Dummy Function for PoC\n");
	return 0;
}

char* concat(const char* s1,const char* s2){
	char* res = malloc(strlen(s1) + strlen(s2) + 1);
	strcpy(res, s1);
	strcat(res, s2);
	return res;
}
