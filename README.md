# SchoolAPI

### Homework 3 content 

### Users	
|Field | Constraint |
| -----| ---------- |
|u_id	 |PK NN       |
|u_name|NN|
|u_password|	NN|
|u_email|	NN|
|u_status|	NN|
|u_sys_role_id|	NN|
|u_created_date|	NN|
|u_updated_date|	NN|

### Courses
|Field | Constraint |
| -----| ---------- |
|c_id	PK| NN|
|c_name|	NN|
|c_description|	
|c_created_date	|NN|
|c_updated_date |NN|

### Course_section	
|Field | Constraint |
| -----| ---------- |
|c_id|	FK|
|cs_start_date|	NN|
|cs_end_date|	NN|
|cs_id |PK NN|
|cs_created_date|	NN|
|cs_updated_date|	

### Course_Assignment	
|Field | Constraint |
| -----| ---------- |
|c_id|	FK|
|ca_title|	NN|
|ca_description| NN|
|cs_id	|FK|

### Section_enroll	
|Field | Constraint |
| -----| ---------- |
|cs_id|	FK|
|se_start_date|	NN|
|se_end_date|	NN|
|u_id| 	FK|
|se_created_date|	NN|
|se_updated_date|	

![dataDictionary](https://user-images.githubusercontent.com/17055891/123499434-ad431500-d604-11eb-9eeb-187f8761adcb.JPG)

-------

### Homework 6 Screen shot



