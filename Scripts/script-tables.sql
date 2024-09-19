CREATE DATABASE CoursesManagementDB;
GO
use CoursesManagementDB
-- ����� ���� �������


CREATE TABLE users (
    [user_id] INT PRIMARY KEY,
    [name] VARCHAR(100) NOT NULL,
    [password] VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
	phone VARCHAR(15) ,
    CONSTRAINT CK_Email CHECK (email LIKE '%_@__%.__%'),
    pay_lesson DECIMAL(10, 2) ,
    [role] INT,
    CONSTRAINT CK_Role CHECK ([role] IN (1, 2))  ,-- ����� �� ����� role
	adress varchar(200) 
);

-- ����� ���� ������
CREATE TABLE courses (
    course_code INT PRIMARY KEY,
    course_name VARCHAR(100) NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    teacher_id INT ,
	director_id int,
	schoole_code INT,
	course_duration INT, 
    FOREIGN KEY (teacher_id) REFERENCES users([user_id]),
	FOREIGN KEY (director_id) REFERENCES users([user_id]),
	FOREIGN KEY (schoole_code) REFERENCES schools(schoole_code)


);


CREATE TABLE schools (
    schoole_code INT PRIMARY KEY,
    schoole_name VARCHAR(100) NOT NULL,
	director_id INT,FOREIGN KEY (director_id) REFERENCES users([user_id]),
	adress varchar(200) 
);


-- ����� ���� �������
CREATE TABLE students (
    name VARCHAR(100) NOT NULL,
    id_number INT PRIMARY KEY,
    phone VARCHAR(15),
    address VARCHAR(255),
    registration_date date,
    grade VARCHAR(50) NOT NULL,
   course_code int FOREIGN KEY (course_code) REFERENCES courses(course_code)
);

CREATE TABLE Reports (
    rep_id INT PRIMARY KEY,
    reportDate DATE,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES users([user_id]),
    director_id INT,
    FOREIGN KEY (director_id) REFERENCES users([user_id]),
    formTime TIME,        -- ����� ���� TIME
    toTime TIME,          -- ����� ���� TIME
    numHours DECIMAL(10, 2),
    travel DECIMAL(10, 2)
);

