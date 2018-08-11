

/****** Object:  Table AspNetRoles    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE AspNetRoles(
  Id Nvarchar2(128) NOT NULL,
  Name Nvarchar2(256) NOT NULL,
 CONSTRAINT PK_AspNetRoles PRIMARY KEY 
(
  Id 
) 
);

/****** Object:  Table AspNetUserClaims    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE AspNetUserClaims(
  Id Number(10) NOT NULL,
  UserId Nvarchar2(128) NOT NULL,
  ClaimType Nvarchar2(1000) NULL,
  ClaimValue Nvarchar2(1000) NULL
);


/****** Object:  Table AspNetUserLogins    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE AspNetUserLogins(
  LoginProvider Nvarchar2(128) NOT NULL,
  ProviderKey Nvarchar2(128) NOT NULL,
  UserId Nvarchar2(128) NOT NULL
);

/****** Object:  Table AspNetUserRoles    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE AspNetUserRoles(
  UserId Nvarchar2(128) NOT NULL,
  RoleId Nvarchar2(128) NOT NULL,
 CONSTRAINT PK_AspNetUserRoles PRIMARY KEY 
(
  UserId,
  RoleId 
) 
);

/****** Object:  Table AspNetUsers    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE AspNetUsers(
  Id Nvarchar2(128) NOT NULL,
  Hometown Nvarchar2(1000) NULL,
  Email Nvarchar2(256) NULL,
  EmailConfirmed Number(1) NOT NULL,
  PasswordHash Nvarchar2(1000) NULL,
  SecurityStamp Nvarchar2(1000) NULL,
  PhoneNumber Nvarchar2(1000) NULL,
  PhoneNumberConfirmed Number(1) NOT NULL,
  TwoFactorEnabled Number(1) NOT NULL,
  LockoutEndDateUtc Timestamp(0) NULL,
  LockoutEnabled Number(1) NOT NULL,
  AccessFailedCount Number(10) NOT NULL,
  UserName Nvarchar2(256) NOT NULL,
 CONSTRAINT PK_AspNetUsers PRIMARY KEY 
(
  Id 
) 
);


/****** Object:  Table tblBranch    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblBranch(
  branch_id Number(10)  NOT NULL,
  branch_name Varchar2(150) NOT NULL,
  address Varchar2(250) NULL,
  contact_person Varchar2(150) NULL,
  contact_no Varchar2(50) NULL,
  display_next Number(10) NOT NULL,
  static_ip Varchar2(20) NULL,
 CONSTRAINT PK_tblBranch PRIMARY KEY 
(
  branch_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblBranch_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblBranch_seq_tr
 BEFORE INSERT ON tblBranch FOR EACH ROW
 WHEN (NEW.branch_id IS NULL)
BEGIN
 SELECT tblBranch_seq.NEXTVAL INTO :NEW.branch_id FROM dual;
END;
/
/****** Object:  Table tblBranchUser    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblBranchUser(
  user_branch_id Number(10)  NOT NULL,
  user_id Nvarchar2(128) NOT NULL,
  branch_id Number(10) NOT NULL,
 CONSTRAINT PK_tblBranchUser PRIMARY KEY 
(
  user_branch_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblBranchUser_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblBranchUser_seq_tr
 BEFORE INSERT ON tblBranchUser FOR EACH ROW
 WHEN (NEW.user_branch_id IS NULL)
BEGIN
 SELECT tblBranchUser_seq.NEXTVAL INTO :NEW.user_branch_id FROM dual;
END;
/
/****** Object:  Table tblBreakType    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblBreakType(
  break_type_id Number(10)  NOT NULL,
  break_type_short_name Varchar2(5) NOT NULL,
  break_type_name Varchar2(150) NOT NULL,
  start_time Timestamp(3) NULL,
  end_time Timestamp(3) NULL,
  duration Number(10) NOT NULL,
 CONSTRAINT PK_tblBreakType PRIMARY KEY 
(
  break_type_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblBreakType_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblBreakType_seq_tr
 BEFORE INSERT ON tblBreakType FOR EACH ROW
 WHEN (NEW.break_type_id IS NULL)
BEGIN
 SELECT tblBreakType_seq.NEXTVAL INTO :NEW.break_type_id FROM dual;
END;
/
/****** Object:  Table tblCounter    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblCounter(
  counter_id Number(10)  NOT NULL,
  branch_id Number(10) NOT NULL,
  counter_no Varchar2(5) NOT NULL,
  location Varchar2(250) NULL,
 CONSTRAINT PK_tblCounter PRIMARY KEY 
(
  counter_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblCounter_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblCounter_seq_tr
 BEFORE INSERT ON tblCounter FOR EACH ROW
 WHEN (NEW.counter_id IS NULL)
BEGIN
 SELECT tblCounter_seq.NEXTVAL INTO :NEW.counter_id FROM dual;
END;
/
/****** Object:  Table tblCustomer    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblCustomer(
  customer_id Number(19)  NOT NULL,
  customer_name Varchar2(150) NOT NULL,
  contact_no Varchar2(15) NOT NULL,
  address Varchar2(250) NULL,
  customer_type_id Number(10) NOT NULL,
 CONSTRAINT PK_tblCustomer PRIMARY KEY 
(
  customer_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblCustomer_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblCustomer_seq_tr
 BEFORE INSERT ON tblCustomer FOR EACH ROW
 WHEN (NEW.customer_id IS NULL)
BEGIN
 SELECT tblCustomer_seq.NEXTVAL INTO :NEW.customer_id FROM dual;
END;
/
/****** Object:  Table tblCustomerType    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblCustomerType(
  customer_type_id Number(10)  NOT NULL,
  customer_type_name Varchar2(50) NOT NULL,
 CONSTRAINT PK_tblCustomerType PRIMARY KEY 
(
  customer_type_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblCustomerType_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblCustomerType_seq_tr
 BEFORE INSERT ON tblCustomerType FOR EACH ROW
 WHEN (NEW.customer_type_id IS NULL)
BEGIN
 SELECT tblCustomerType_seq.NEXTVAL INTO :NEW.customer_type_id FROM dual;
END;
/
/****** Object:  Table tblDailyBreak    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblDailyBreak(
  daily_break_id Number(19)  NOT NULL,
  break_type_id Number(10) NOT NULL,
  user_id Nvarchar2(128) NOT NULL,
  counter_id Number(10) NOT NULL,
  start_time Timestamp(3) NOT NULL,
  end_time Timestamp(3) NULL,
  remarks Varchar2(250) NULL,
 CONSTRAINT PK_tblDailyBreak PRIMARY KEY 
(
  daily_break_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblDailyBreak_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblDailyBreak_seq_tr
 BEFORE INSERT ON tblDailyBreak FOR EACH ROW
 WHEN (NEW.daily_break_id IS NULL)
BEGIN
 SELECT tblDailyBreak_seq.NEXTVAL INTO :NEW.daily_break_id FROM dual;
END;
/
/****** Object:  Table tblServiceDetail    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblServiceDetail(
  service_id Number(19)  NOT NULL,
  token_id Number(19) NOT NULL,
  customer_id Number(19) NOT NULL,
  issues Nvarchar2(1000) NOT NULL,
  solutions Nvarchar2(1000) NOT NULL,
  service_datetime Timestamp(0) NOT NULL,
  start_time Timestamp(3) NOT NULL,
  end_time Timestamp(3) NOT NULL,
  service_sub_type_id Number(10) NOT NULL,
 CONSTRAINT PK_tblServiceDetail PRIMARY KEY 
(
  service_id 
) 
);

-- Generate ID using sequence and trigger
CREATE SEQUENCE tblServiceDetail_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblServiceDetail_seq_tr
 BEFORE INSERT ON tblServiceDetail FOR EACH ROW
 WHEN (NEW.service_id IS NULL)
BEGIN
 SELECT tblServiceDetail_seq.NEXTVAL INTO :NEW.service_id FROM dual;
END;
/ 


/****** Object:  Table tblServiceStatus    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblServiceStatus(
  service_status_id Number(5)  NOT NULL,
  service_status Varchar2(50) NOT NULL,
 CONSTRAINT PK_tblServiceStatus PRIMARY KEY 
(
  service_status_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblServiceStatus_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblServiceStatus_seq_tr
 BEFORE INSERT ON tblServiceStatus FOR EACH ROW
 WHEN (NEW.service_status_id IS NULL)
BEGIN
 SELECT tblServiceStatus_seq.NEXTVAL INTO :NEW.service_status_id FROM dual;
END;
/
/****** Object:  Table tblServiceSubType    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblServiceSubType(
  service_sub_type_id Number(10)  NOT NULL,
  service_type_id Number(10) NOT NULL,
  service_sub_type_name Varchar2(100) NOT NULL,
  max_duration Number(10) NOT NULL,
 CONSTRAINT PK_tblServiceSubType PRIMARY KEY 
(
  service_sub_type_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblServiceSubType_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblServiceSubType_seq_tr
 BEFORE INSERT ON tblServiceSubType FOR EACH ROW
 WHEN (NEW.service_sub_type_id IS NULL)
BEGIN
 SELECT tblServiceSubType_seq.NEXTVAL INTO :NEW.service_sub_type_id FROM dual;
END;
/
/****** Object:  Table tblServiceType    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblServiceType(
  service_type_id Number(10)  NOT NULL,
  service_type_name Varchar2(150) NOT NULL,
 CONSTRAINT PK_tblServiceType PRIMARY KEY 
(
  service_type_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblServiceType_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblServiceType_seq_tr
 BEFORE INSERT ON tblServiceType FOR EACH ROW
 WHEN (NEW.service_type_id IS NULL)
BEGIN
 SELECT tblServiceType_seq.NEXTVAL INTO :NEW.service_type_id FROM dual;
END;
/
/****** Object:  Table tblTokenQueue    Script Date: 08-Jul-18 2:33:50 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE tblTokenQueue(
  token_id Number(19)  NOT NULL,
  branch_id Number(10) NOT NULL,
  service_type_id Number(10) NOT NULL,
  contact_no Varchar2(15) NOT NULL,
  token_no Number(10) NOT NULL,
  service_date Timestamp(3) NOT NULL,
  cancel_time Timestamp(3) NULL,
  service_status_id Number(5) NOT NULL,
  counter_id Number(10) NULL,
  user_id Nvarchar2(128) NULL,
 CONSTRAINT PK_tblTokenQueue PRIMARY KEY 
(
  token_id 
) 
);


-- Generate ID using sequence and trigger
CREATE SEQUENCE tblTokenQueue_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER tblTokenQueue_seq_tr
 BEFORE INSERT ON tblTokenQueue FOR EACH ROW
 WHEN (NEW.token_id IS NULL)
BEGIN
 SELECT tblTokenQueue_seq.NEXTVAL INTO :NEW.token_id FROM dual;
END;

/



/
ALTER TABLE tblCustomer MODIFY customer_type_id DEFAULT 1;
 

ALTER TABLE AspNetUserRoles ADD FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id); 
ALTER TABLE AspNetUserRoles ADD FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id); 
ALTER TABLE tblBranchUser ADD FOREIGN KEY (user_id) REFERENCES AspNetUsers(Id); 
ALTER TABLE tblBranchUser ADD FOREIGN KEY (branch_id) REFERENCES tblBranch(branch_id); 
ALTER TABLE tblCounter  ADD FOREIGN KEY(branch_id) REFERENCES tblBranch (branch_id);
ALTER TABLE tblCustomer  ADD FOREIGN KEY(customer_type_id) REFERENCES tblCustomerType (customer_type_id);
ALTER TABLE tblDailyBreak  ADD FOREIGN KEY(user_id)REFERENCES AspNetUsers (Id);
ALTER TABLE tblDailyBreak  ADD FOREIGN KEY(break_type_id) REFERENCES tblBreakType (break_type_id);
ALTER TABLE tblDailyBreak  ADD FOREIGN KEY(counter_id) REFERENCES tblCounter (counter_id);
ALTER TABLE tblServiceDetail  ADD FOREIGN KEY(customer_id) REFERENCES tblCustomer (customer_id);
ALTER TABLE tblServiceDetail  ADD FOREIGN KEY(service_sub_type_id) REFERENCES tblServiceSubType (service_sub_type_id);
ALTER TABLE tblServiceDetail  ADD FOREIGN KEY(token_id) REFERENCES tblTokenQueue (token_id);
ALTER TABLE tblServiceSubType  ADD FOREIGN KEY(service_type_id) REFERENCES tblServiceType (service_type_id);
ALTER TABLE tblTokenQueue  ADD FOREIGN KEY(user_id) REFERENCES AspNetUsers (Id);
ALTER TABLE tblTokenQueue  ADD FOREIGN KEY(branch_id) REFERENCES tblBranch (branch_id);
ALTER TABLE tblTokenQueue  ADD FOREIGN KEY(counter_id) REFERENCES tblCounter (counter_id);
ALTER TABLE tblTokenQueue ADD FOREIGN KEY(service_status_id) REFERENCES tblServiceStatus (service_status_id);
ALTER TABLE tblTokenQueue  ADD FOREIGN KEY(service_type_id) REFERENCES tblServiceType (service_type_id);



/

CREATE OR REPLACE PROCEDURE    USP_AspNetRoles_SelectAll (
   po_cursor   OUT SYS_REFCURSOR)
IS
BEGIN
   --open po_cursor for select * from tblservicetype;

   OPEN po_cursor FOR
      SELECT *
        FROM ASPNETROLES R;
END;
/



CREATE OR REPLACE PROCEDURE    USP_AspNetRoles_SelectByUserId (
   p_user_id       VARCHAR2,
   po_cursor   OUT SYS_REFCURSOR)
IS
BEGIN
   --open po_cursor for select * from tblservicetype;

   OPEN po_cursor FOR
      SELECT R.*
        FROM ASPNETROLES R
             INNER JOIN ASPNETUSERROLES UR ON R.ID = UR.ROLEID
       WHERE UR.USERID = p_user_id;
END;
/



CREATE OR REPLACE PROCEDURE USP_BranchUsers_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select bu.user_branch_id,br.branch_name,us.Hometown,us.UserName,ro.Name from tblBranchUser bu inner join AspNetUserRoles ur
on ur.UserId=bu.user_id
inner join AspNetRoles ro on ro.Id=ur.RoleId
inner join tblBranch br on br.branch_id=bu.branch_id
inner join AspNetUsers us on us.Id=bu.user_id' ;
IF(quer IS NOT NULL) THEN
   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/



CREATE OR REPLACE PROCEDURE USP_BranchUser_Insert
 
(
p_branch_id number,
 p_user_id varchar2 ,
po_PKValue out number)

IS
Begin
INSERT INTO tblbranchuser
           (branch_id,
           user_id
           )
           
     VALUES
           (p_branch_id,
           p_user_id);
         select USER_BRANCH_ID into po_PKValue from tblbranchuser
 where branch_id=p_branch_id and user_id=p_user_id ;      
End;
/



CREATE OR REPLACE PROCEDURE USP_Branch_Delete
 
(
p_branch_id number 
)

IS

BEGIN
      DELETE FROM tblbranch
      
           
     where branch_id=p_branch_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_Branch_Edit (
   p_branch_id       NUMBER,
   po_cursor     OUT SYS_REFCURSOR
   )
IS
BEGIN
   --open po_cursor for select * from tblservicetype;
   OPEN po_cursor FOR
      SELECT *
        FROM tblbranch
       WHERE branch_id = p_branch_id;
END;
/



CREATE OR REPLACE PROCEDURE    USP_Branch_Insert (
    P_BRANCH_NAME     VARCHAR2,
    P_ADDRESS         VARCHAR2,
    P_CONTACT_PERSON  VARCHAR2,
    P_CONTACT_NO      VARCHAR2,
    P_DISPLAY_NEXT    NUMBER,
    P_STATIC_IP       VARCHAR2,
    po_PKValue    OUT NUMBER)
IS
BEGIN
   INSERT INTO TBLBRANCH (
    BRANCH_NAME,
    ADDRESS,
    CONTACT_PERSON,
    CONTACT_NO,
    DISPLAY_NEXT,
    STATIC_IP)
   VALUES (
    P_BRANCH_NAME,
    P_ADDRESS,
    P_CONTACT_PERSON,
    P_CONTACT_NO,
    P_DISPLAY_NEXT,
    P_STATIC_IP);

   SELECT BRANCH_ID
     INTO po_PKValue
     FROM TBLBRANCH
    WHERE BRANCH_NAME = P_BRANCH_NAME;
END;
/



CREATE OR REPLACE PROCEDURE USP_Branch_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select * from tblbranch' ;
IF(quer IS NOT NULL) THEN
   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/


CREATE OR REPLACE PROCEDURE USP_Branch_Update
 
(p_branch_id number,p_branchuser_id number,p_user_id number
)

IS
Begin
Update  tblbranchuser
           set branch_id= p_branch_id,
           user_id= p_user_id
           
     where user_branch_id=p_branchuser_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_BreakType_Delete
 
(
p_breakType_id number 
)
IS

BEGIN
      DELETE FROM tblBreakType
            
     where break_type_id=p_breakType_id;
            
End;
/



CREATE OR REPLACE PROCEDURE USP_BreakType_Edit (
   p_breakType_id       NUMBER,
   po_cursor        OUT SYS_REFCURSOR
   )
IS
BEGIN
   OPEN po_cursor FOR
      SELECT *
        FROM tblBreakType
       WHERE break_type_id = p_breakType_id;
END;
/




CREATE OR REPLACE PROCEDURE USP_BreakType_Insert
(p_break_type_name varchar2,p_break_type_short_name varchar2,p_duration number,
p_start_time date,p_end_time date
, po_PKValue out number)

IS
Begin
INSERT INTO tblBreakType
           (break_type_name,
           break_type_short_name,
           duration,
           start_time,
           end_time )
           
     VALUES
           (p_break_type_name,
           p_break_type_short_name,
           p_duration,
           p_start_time,
           p_end_time
           );  
       
 select break_type_id into po_PKValue from tblBreakType 
 where break_type_name=p_break_type_name and break_type_short_name= p_break_type_short_name and duration=p_duration and start_time = p_start_time and end_time= p_end_time;   
End;
/



CREATE OR REPLACE PROCEDURE USP_BreakType_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select * from tblBreakType' ;
IF(quer IS NOT NULL) THEN
   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/



CREATE OR REPLACE PROCEDURE USP_BreakType_Update
 
(p_break_type_name varchar2,p_break_type_short_name varchar2,p_duration number,
p_start_time date,p_end_time date,
p_breakType_id number
)

IS
Begin
Update  tblBreakType
           set break_type_name = p_break_type_name,
          break_type_short_name=p_break_type_short_name,
           duration=p_duration,
           start_time=p_start_time,
           end_time=p_end_time
     where break_type_id = p_breakType_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_Counters_Delete
 
(
p_Counter_id number 
)

IS

BEGIN
      DELETE FROM tblcounter
      
           
     where counter_id=p_Counter_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_Counters_Edit (
   p_Counter_id       NUMBER,
   po_cursor      OUT SYS_REFCURSOR
   )
IS
BEGIN
   --open po_cursor for select * from tblservicetype;
   OPEN po_cursor FOR
      SELECT *
        FROM tblcounter
       WHERE counter_id = p_Counter_id;
END;
/




CREATE OR REPLACE PROCEDURE USP_Counters_Insert
(p_location varchar2,p_counter_no varchar2,p_branch_id number

, po_PKValue out number)

IS
Begin


 
INSERT INTO tblcounter
           (counter_no,
           branch_id,
           location )
           
     VALUES
           (p_counter_no,
           p_branch_id,
           p_location
           );  
       
 select counter_id into po_PKValue from tblcounter 
 where counter_no=p_counter_no and branch_id= p_branch_id and location=p_location;   
End;
/



CREATE OR REPLACE PROCEDURE    USP_Counters_SelectAll (
   po_cursor   OUT SYS_REFCURSOR)
IS
   quer   VARCHAR2 (500) := ' ';
BEGIN
   quer :=
      'select con.counter_id,br.branch_id,BR.BRANCH_NAME,con.counter_no,con.location from tblCounter con inner join tblBranch br
on br.branch_id=con.branch_id';

   IF (quer IS NOT NULL)
   THEN
      OPEN po_cursor FOR quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
   END IF;
END;
/



CREATE OR REPLACE PROCEDURE USP_Counters_Update
 
(p_location varchar2,p_counter_no varchar2,p_branch_id number,
p_Counter_id number
)

IS
Begin
Update  tblcounter
           set counter_no = p_counter_no,
          branch_id=p_branch_id,
           location=p_location
     where counter_id = p_Counter_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_Customer_Edit (
   p_customer_id       NUMBER,
   po_cursor       OUT SYS_REFCURSOR
   )
IS
BEGIN
   --open po_cursor for select * from tblservicetype;
   OPEN po_cursor FOR
      SELECT *
        FROM tblcustomer
       WHERE customer_id = p_customer_id;
END;
/


CREATE OR REPLACE PROCEDURE USP_Customer_Insert
 
(p_customer_name varchar2,p_contact_no varchar2,p_address varchar2,p_customer_type_id number

, po_PKValue out number)

IS
Begin


 
INSERT INTO tblcustomer
           (customer_name,
           contact_no,
           address,
           customer_type_id
           )
           
     VALUES
           (p_customer_name,
           p_contact_no,
           p_address,
           1);  
       
 select customer_id into po_PKValue from tblcustomer 
 where customer_name=p_customer_name and contact_no= p_contact_no  and address=p_address ;   
End;
/



CREATE OR REPLACE PROCEDURE USP_Customer_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select cus.customer_id,cus.customer_name,cus.contact_no,cus.address,ct.customer_type_name from tblCustomer cus
 inner join tblCustomerType ct on ct.customer_type_id=cus.customer_type_id' ;
IF(quer IS NOT NULL) THEN
   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/



CREATE OR REPLACE PROCEDURE USP_Customer_Update
 
(p_customer_name varchar2,p_contact_no varchar2,p_address varchar2,p_customer_type_id number,
p_customer_id number
)

IS
Begin
Update  tblcustomer
           set customer_name = p_customer_name,
           contact_no = p_contact_no,
          
           address=p_address ,
           customer_type_id=p_customer_type_id
     where customer_id = p_customer_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_DailyBreak_Delete
 
(
p_dailyBreak_id number 
)
IS

BEGIN
      DELETE FROM tblDailyBreak
            
     where daily_break_id=p_dailyBreak_id;
            
End;
/



CREATE OR REPLACE PROCEDURE USP_DailyBreak_Edit (
   p_dailyBreak_id       NUMBER,
   po_cursor         OUT SYS_REFCURSOR
   )
IS
BEGIN
   OPEN po_cursor FOR
      SELECT *
        FROM tblDailyBreak
       WHERE daily_break_id = p_dailyBreak_id;
END;
/




CREATE OR REPLACE PROCEDURE USP_DailyBreak_Insert
(p_break_type_id number,p_counter_id number,p_start_time date,
p_end_time date,p_user_id varchar2,p_remarks varchar2
, po_PKValue out number)

IS
Begin
INSERT INTO tblDailyBreak
           (break_type_id,
           counter_id,
           start_time,
           end_time,
           user_id,
           remarks )
           
     VALUES
           (p_break_type_id,
           p_counter_id,
           p_start_time,
           p_end_time,
           p_user_id,
           p_remarks
           );  
       
 select daily_break_id into po_PKValue from tblDailyBreak 
 where break_type_id=p_break_type_id and counter_id= p_counter_id and start_time=p_start_time and user_id = p_user_id and end_time= p_end_time
 and remarks=p_remarks;   
End;
/



CREATE OR REPLACE PROCEDURE USP_DailyBreak_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select * from tblDailyBreak' ;
IF(quer IS NOT NULL) THEN
   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/



CREATE OR REPLACE PROCEDURE USP_DailyBreak_Update
 
(p_break_type_id number,p_counter_id number,p_start_time date,
p_end_time date,p_user_id varchar2,p_remarks varchar2,
p_dailyBreak_id number
)

IS
Begin
Update  tblDailyBreak
           set break_type_id = p_break_type_id,
          counter_id=p_counter_id,
           user_id=p_user_id,
           start_time=p_start_time,
           end_time=p_end_time,
           remarks=p_remarks 
     where daily_break_id = p_dailyBreak_id;
End;
/



CREATE OR REPLACE PROCEDURE    USP_DASHBOARD_ADMIN (
   po_cursor   OUT SYS_REFCURSOR)
IS
BEGIN
   --open po_cursor for select * from tblservicetype;

   OPEN po_cursor FOR
      SELECT B.BRANCH_NAME, NVL(COUNT(TQ.TOKEN_ID),0) TOKENS
            , NVL(COUNT(SD.SERVICE_ID),0) SERVICES
        FROM TBLBRANCH B
        LEFT JOIN TBLTOKENQUEUE TQ 
            ON B.BRANCH_ID=TQ.BRANCH_ID
        LEFT JOIN TBLSERVICEDETAIL SD ON TQ.TOKEN_ID = SD.TOKEN_ID
        GROUP BY B.BRANCH_NAME;
END;
/



CREATE OR REPLACE PROCEDURE    USP_DASHBOARD_COUNTERS (
   P_BRANCH_ID   IN     NUMBER,
   po_CURSOR       OUT SYS_REFCURSOR)
IS
BEGIN
   --open po_cursor for select * from tblservicetype;

   OPEN po_CURSOR FOR
        SELECT C.COUNTER_NO,
               NVL (COUNT (TQ.TOKEN_ID), 0) TOKENS,
               NVL (COUNT (SD.SERVICE_ID), 0) SERVICES
          FROM TBLCOUNTER C
               LEFT JOIN TBLTOKENQUEUE TQ ON C.COUNTER_ID = TQ.COUNTER_ID
               LEFT JOIN TBLSERVICEDETAIL SD ON TQ.TOKEN_ID = SD.TOKEN_ID
         WHERE C.BRANCH_ID = P_BRANCH_ID
      GROUP BY C.COUNTER_NO;

  
END;
/



CREATE OR REPLACE PROCEDURE    USP_DASHBOARD_STATUSES (
   P_BRANCH_ID   IN     NUMBER,
   po_CURSOR       OUT SYS_REFCURSOR)
IS
BEGIN
   --open po_cursor for select * from tblservicetype;

   OPEN po_CURSOR FOR
        SELECT SS.SERVICE_STATUS, NVL (COUNT (TQ.TOKEN_ID), 0) TOKENS
          FROM TBLSERVICESTATUS SS
               LEFT JOIN TBLTOKENQUEUE TQ
                  ON SS.SERVICE_STATUS_ID = TQ.SERVICE_STATUS_ID
         WHERE TQ.BRANCH_ID = P_BRANCH_ID
      GROUP BY SS.SERVICE_STATUS;

  
END;
/



CREATE OR REPLACE PROCEDURE    USP_GetInProgressTokenList (
   -- Add the parameters for the stored procedure here
   p_branch_id       NUMBER,
   PO_CURSOR           OUT SYS_REFCURSOR)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.

   -- Insert statements for procedure here
   OPEN PO_CURSOR FOR
        SELECT b.static_ip,
               c.counter_no,
               NVL (TO_CHAR (t.token_no), 'ON') token_no
          FROM tblCounter c
               INNER JOIN tblBranch b ON c.branch_id = b.branch_id
               LEFT JOIN
               (SELECT *
                  FROM tblTokenQueue
                 WHERE     service_status_id = 2
                       AND TRUNC (service_date) = TRUNC (SYSDATE)) t
                  ON c.counter_id = t.counter_id
         WHERE b.branch_id = p_branch_id
      ORDER BY C.COUNTER_NO;
END;
/



CREATE OR REPLACE PROCEDURE    USP_GetNextTokenList (
   p_branch_id       NUMBER,
   PO_CURSOR     OUT SYS_REFCURSOR)
AS
BEGIN
   OPEN PO_CURSOR FOR
      SELECT b.static_ip, b.display_next, t.token_no
        FROM tblTokenQueue t
             INNER JOIN tblBranch b ON t.branch_id = b.branch_id
       WHERE     t.branch_id = p_branch_id
             AND service_status_id = 1
             AND TRUNC (service_date) = TRUNC (SYSDATE)
       ORDER BY t.token_no ASC;
END;
/



CREATE OR REPLACE PROCEDURE    USP_SERVICEDETAIL_INSERT (
   P_TOKEN_ID              IN     NUMBER,
   P_CONTACT_NO            IN     VARCHAR,
   P_START_TIME            IN     DATE,
   P_SERVICE_SUB_TYPE_ID   IN     NUMBER,
   P_ISSUES                IN     VARCHAR2,
   P_SOLUTIONS             IN     VARCHAR2,
   P_CUSTOMER_NAME         IN     VARCHAR2,
   P_ADDRESS               IN     VARCHAR2,
   P_COUNTER_ID            IN     NUMBER,
   P_USER_ID               IN     VARCHAR2,
   po_PKValue                 OUT NUMBER)
IS
   /******************************************************************************
      NAME:       USP_DAILYSERVICE_NEWCALL
      PURPOSE:    CALLING NEW CUSTOMER FOR SERVICE WITH NEW TOKEN

      REVISIONS:
      Ver        Date        Author           Description
      ---------  ----------  ---------------  ------------------------------------
      1.0        7/28/2018   KAMRUL       1. Created this procedure.
   ******************************************************************************/



   P_ROWCOUNT_CUSTOMER   NUMBER := 0;
   P_CUSTOMER_ID         NUMBER := 0;
BEGIN
   SELECT COUNT (1)
     INTO P_ROWCOUNT_CUSTOMER
     FROM TBLCUSTOMER C
    WHERE C.CONTACT_NO = P_CONTACT_NO;

   IF (P_ROWCOUNT_CUSTOMER > 0)
   THEN
      UPDATE TBLCUSTOMER
         SET customer_name = P_CUSTOMER_NAME, ADDRESS = P_ADDRESS
       WHERE CONTACT_NO = P_CONTACT_NO;
   ELSE
      INSERT INTO TBLCUSTOMER (customer_name,
                               ADDRESS,
                               CONTACT_NO,
                               customer_type_id)
           VALUES (P_CUSTOMER_NAME,
                   P_ADDRESS,
                   P_CONTACT_NO,
                   1);
   END IF;

   SELECT CUSTOMER_ID
     INTO P_CUSTOMER_ID
     FROM TBLCUSTOMER C
    WHERE C.CONTACT_NO = P_CONTACT_NO;

   UPDATE TBLTOKENQUEUE
      SET service_status_id = 3,
          contact_no = P_CONTACT_NO,
          COUNTER_ID = P_COUNTER_ID,
          USER_ID = P_USER_ID
    WHERE TOKEN_ID = P_TOKEN_ID;

   INSERT INTO TBLSERVICEDETAIL (token_id,
                                 customer_id,
                                 service_sub_type_id,
                                 issues,
                                 solutions,
                                 start_time,
                                 service_datetime,
                                 end_time)
        VALUES (P_TOKEN_ID,
                P_CUSTOMER_ID,
                P_SERVICE_SUB_TYPE_ID,
                P_ISSUES,
                P_SOLUTIONS,
                P_START_TIME,
                SYSDATE,
                SYSDATE);

   SELECT SERVICE_ID
     INTO po_PKValue
     FROM TBLSERVICEDETAIL
    WHERE TOKEN_ID = P_TOKEN_ID;
END;
/



CREATE OR REPLACE PROCEDURE    USP_SERVICEDETAIL_NEWCALL (
   P_BRANCH_ID        IN     NUMBER,
   P_COUNTER_ID       IN     NUMBER,
   P_USER_ID          IN     VARCHAR,
   PO_TOKEN_ID           OUT NUMBER,
   PO_TOKEN_NO           OUT NUMBER,
   PO_CONTACT_NO         OUT VARCHAR2,
   PO_SERVICE_TYPE       OUT VARCHAR2,
   PO_START_TIME         OUT DATE,
   PO_CUSTOMER_NAME      OUT VARCHAR2,
   PO_ADDRESS            OUT VARCHAR2,
   PO_CURSOR             OUT SYS_REFCURSOR)
IS
   P_ROWCOUNT_TOKEN      NUMBER := 0;
   P_ROWCOUNT_CUSTOMER   NUMBER := 0;
   P_TOKEN_ID            NUMBER := 0;
   P_SERVICE_TYPE_ID     NUMBER := 0;
   P_TOKEN_NO            NUMBER := 0;
   P_CUSTOMER_NAME       VARCHAR2 (150);
   P_ADDRESS             VARCHAR2 (250);
   P_CONTACT_NO          VARCHAR2 (150);
   P_SERVICE_TYPE        VARCHAR2 (100);
/******************************************************************************
   NAME:       USP_DAILYSERVICE_NEWCALL
   PURPOSE:    CALLING NEW CUSTOMER FOR SERVICE WITH NEW TOKEN

   REVISIONS:
   Ver        Date        Author           Description
   ---------  ----------  ---------------  ------------------------------------
   1.0        7/28/2018   KAMRUL       1. Created this procedure.
******************************************************************************/



BEGIN
     SELECT COUNT (1)
       INTO P_ROWCOUNT_TOKEN
       FROM TBLTOKENQUEUE T
      WHERE     (   (T.counter_id = P_COUNTER_ID AND T.service_status_id = 2)
                 OR (    T.counter_id IS NULL
                     AND T.service_status_id = 1
                     AND T.branch_id = P_BRANCH_ID))
            AND TRUNC (T.service_date) = TRUNC (SYSDATE)
   ORDER BY T.token_id ASC;

   DBMS_OUTPUT.PUT_LINE ('P_ROWCOUNT_TOKEN:' || P_ROWCOUNT_TOKEN);

   IF (P_ROWCOUNT_TOKEN > 0)
   THEN
      SELECT *
        INTO P_TOKEN_ID,
             P_TOKEN_NO,
             P_CONTACT_NO,
             P_SERVICE_TYPE_ID,
             P_SERVICE_TYPE
        FROM (  SELECT T.TOKEN_ID,
                       T.TOKEN_NO,
                       T.CONTACT_NO,
                       S.SERVICE_TYPE_ID,
                       S.SERVICE_TYPE_NAME
                  FROM TBLTOKENQUEUE T
                       INNER JOIN TBLSERVICETYPE S
                          ON T.SERVICE_TYPE_ID = S.SERVICE_TYPE_ID
                 WHERE     (   (    T.counter_id = P_COUNTER_ID
                                AND T.service_status_id = 2)
                            OR (    T.counter_id IS NULL
                                AND T.service_status_id = 1
                                AND T.branch_id = P_BRANCH_ID))
                       AND TRUNC (T.service_date) = TRUNC (SYSDATE)
              ORDER BY T.token_id ASC) TBL
       WHERE ROWNUM <= 1;
   END IF;

   IF (P_ROWCOUNT_TOKEN > 0)
   THEN
      UPDATE TBLTOKENQUEUE
         SET service_status_id = 2,
             counter_id = P_COUNTER_ID,
             user_id = P_USER_ID
       WHERE token_id = P_TOKEN_ID;
   END IF;

   IF (P_ROWCOUNT_TOKEN > 0)
   THEN
      UPDATE TBLDAILYBREAK
         SET end_time = SYSDATE
       WHERE user_id = P_USER_ID AND end_time IS NULL;
   END IF;

   SELECT COUNT (1)
     INTO P_ROWCOUNT_CUSTOMER
     FROM TBLCUSTOMER
    WHERE contact_no = P_CONTACT_NO;

   IF (P_ROWCOUNT_TOKEN > 0 AND P_ROWCOUNT_CUSTOMER > 0)
   THEN
      SELECT customer_name, address
        INTO P_CUSTOMER_NAME, P_ADDRESS
        FROM TBLCUSTOMER
       WHERE contact_no = P_CONTACT_NO;
   END IF;

   IF (P_ROWCOUNT_TOKEN > 0)
   THEN
      PO_TOKEN_ID := P_TOKEN_ID;
      PO_TOKEN_NO := P_TOKEN_NO;
      PO_CONTACT_NO := P_CONTACT_NO;
      PO_SERVICE_TYPE := P_SERVICE_TYPE;
      PO_CUSTOMER_NAME := P_CUSTOMER_NAME;
      PO_ADDRESS := P_ADDRESS;
      PO_START_TIME := SYSDATE;

      DBMS_OUTPUT.PUT_LINE ('PO_CUSTOMER_NAME:' || PO_CUSTOMER_NAME);

      --SELECT PO_TOKEN_ID, PO_SERVICE_TYPE, PO_CONTACT_NO INTO TBL_USP_SERVICEDETAIL_NEWCALL FROM DUAL;

      OPEN PO_CURSOR FOR
         SELECT SST.*
           FROM TBLSERVICESUBTYPE SST
          WHERE SST.SERVICE_TYPE_ID = P_SERVICE_TYPE_ID;

      COMMIT;
   END IF;
END;
/



CREATE OR REPLACE PROCEDURE    USP_ServiceDetail_SelectAll (
   po_cursor   OUT SYS_REFCURSOR)
IS
BEGIN
   OPEN po_cursor FOR
      SELECT sd.service_id,
             tq.token_id,
             tq.token_no,
             BR.BRANCH_NAME,
             CU.COUNTER_NO,
             au.UserName,
             cus.customer_id,
             cus.customer_name,
             CUS.contact_no,
             sd.issues,
             sd.solutions,
             sd.service_datetime,
             sd.start_time,
             sd.end_time,
             sst.service_sub_type_name
        FROM tblServiceDetail sd
             INNER JOIN tblTokenQueue tq ON tq.token_id = sd.token_id
             INNER JOIN TBLCOUNTER CU ON TQ.COUNTER_ID = CU.COUNTER_ID
             INNER JOIN TBLBRANCH BR ON TQ.BRANCH_ID = BR.BRANCH_ID
             INNER JOIN tblCustomer cus ON cus.customer_id = sd.customer_id
             INNER JOIN tblServiceSubType sst
                ON sst.service_sub_type_id = sd.service_sub_type_id
             INNER JOIN AspNetUsers au ON au.Id = tq.user_id;
END;
/



CREATE OR REPLACE PROCEDURE USP_ServiceSubType_Delete
 
(
p_servicesub_type_id number 
)

IS

BEGIN
      DELETE FROM tblservicesubtype
      
           
     where service_sub_type_id=p_servicesub_type_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_ServiceSubType_Edit (
   p_servicesub_type_id       NUMBER,
   po_cursor              OUT SYS_REFCURSOR
   )
IS
BEGIN
   --open po_cursor for select * from tblservicetype;
   OPEN po_cursor FOR
      SELECT *
        FROM tblservicesubtype
       WHERE service_sub_type_id = p_servicesub_type_id;
END;
/



CREATE OR REPLACE PROCEDURE USP_ServiceSubType_Insert
(p_servicesub_type_name varchar2,p_service_type_id number,p_max_duration number

, po_PKValue out number)

IS
Begin


 
INSERT INTO tblservicesubtype
           (service_sub_type_name,
           service_type_id,
           max_duration )
           
     VALUES
           (p_servicesub_type_name,
           p_service_type_id,p_max_duration
           );  
       
 select service_type_id into po_PKValue from tblservicesubtype 
 where service_sub_type_name=p_servicesub_type_name and service_type_id= p_service_type_id and max_duration=p_max_duration;   
End;
/



CREATE OR REPLACE PROCEDURE USP_ServiceSubType_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='Select sst.service_sub_type_id, st.service_type_name,sst.service_sub_type_name,sst.max_duration from tblServiceSubType sst
inner join tblServiceType st on  sst.service_type_id = st.service_type_id' ;
IF(quer IS NOT NULL) THEN

   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/



CREATE OR REPLACE PROCEDURE USP_ServiceSubType_Update
 
(p_servicesub_type_name varchar2,p_service_type_id number,p_max_duration number,
p_servicesub_type_id number
)

IS
Begin
Update  tblservicesubtype
           set service_sub_type_name = p_servicesub_type_name,
          max_duration=p_max_duration,
           service_type_id=p_service_type_id
     where service_sub_type_id = p_servicesub_type_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_ServiceType_Delete
 
(
p_service_type_id number 
)

IS

BEGIN
      DELETE FROM tblServiceType
      
           
     where service_type_id=p_service_type_id;
            
    
End;
/



CREATE OR REPLACE PROCEDURE USP_ServiceType_Edit (
   p_service_type_id       NUMBER,
   po_cursor           OUT SYS_REFCURSOR
   )
IS
BEGIN
   --open po_cursor for select * from tblservicetype;
   OPEN po_cursor FOR
      SELECT *
        FROM tblServiceType
       WHERE service_type_id = p_service_type_id;
END;
/


CREATE OR REPLACE PROCEDURE USP_ServiceType_Insert
 
(p_service_type_name varchar2,
po_PKValue out number)

IS
Begin
INSERT INTO tblServiceType
           (service_type_name)
           
     VALUES
           (p_service_type_name);
           select service_type_id into po_PKValue from tblServiceType 
 where service_type_name=p_service_type_name;      
End;
/



CREATE OR REPLACE PROCEDURE USP_ServiceType_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select * from tblservicetype' ;
BEGIN
   open po_cursor for select * from tblservicetype;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END;
END;
/



CREATE OR REPLACE PROCEDURE USP_ServiceType_Update
 
(p_service_type_name varchar2,
p_service_type_id number 
)

IS
Begin
Update  tblServiceType
           set service_type_name= p_service_type_name
           
     where service_type_id=p_service_type_id;
            
    
End;
/


CREATE OR REPLACE PROCEDURE    USP_SessionInfo_ByUserName (
   P_USER_NAME       VARCHAR2,
   po_cursor     OUT SYS_REFCURSOR)
IS
BEGIN
   --open po_cursor for select * from tblservicetype;

   OPEN po_cursor FOR
      SELECT U.ID USER_ID,
             U.Hometown USER_NAME,
             R.NAME ROLE_NAME,
             B.BRANCH_ID,
             B.BRANCH_NAME,
             B.STATIC_IP BRANCH_STATIC_IP
        FROM ASPNETROLES R
             INNER JOIN ASPNETUSERROLES UR ON R.ID = UR.ROLEID
             INNER JOIN ASPNETUSERS U ON UR.USERID = U.ID
             LEFT JOIN TBLBRANCHUSER BU ON U.ID = BU.USER_ID
             LEFT JOIN TBLBRANCH B ON BU.BRANCH_ID = B.BRANCH_ID
       WHERE U.USERNAME = P_USER_NAME;
END;
/



CREATE OR REPLACE PROCEDURE USP_Status_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select * from tblServiceStatus' ;
IF(quer IS NOT NULL) THEN
   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/



CREATE OR REPLACE PROCEDURE    USP_Token_Cancel (
    p_token_id  IN NUMBER,
    po_PKValue OUT NUMBER)
IS

BEGIN
   
    UPDATE TBLTOKENQUEUE
    SET
        SERVICE_STATUS_ID=4,
        CANCEL_TIME = SYSDATE
    WHERE  TOKEN_ID=p_token_id;
    
    SELECT TOKEN_NO INTO po_PKValue FROM TBLTOKENQUEUE WHERE TOKEN_ID=P_TOKEN_ID;

END;
/




CREATE OR REPLACE PROCEDURE    USP_Token_Insert (
   po_token_id         OUT NUMBER,
   po_token_no         OUT NUMBER,
   p_branch_id             NUMBER,
   p_service_type_id       NUMBER,
   p_contact_no            VARCHAR2
)
IS
   token_no   NUMBER := 0;
BEGIN
   SELECT NVL (MAX (TOKEN_NO), 0)
     INTO token_no
     FROM tbltokenqueue T
    WHERE     T.BRANCH_ID = p_branch_id
          AND TRUNC (T.SERVICE_DATE) = TRUNC (SYSDATE);

   po_token_no := token_no + 1;


   INSERT INTO tbltokenqueue (BRANCH_ID,
                              SERVICE_TYPE_ID,
                              CONTACT_NO,
                              TOKEN_NO,
                              SERVICE_DATE,
                              SERVICE_STATUS_ID)
        VALUES (p_branch_id,
                p_service_type_id,
                p_contact_no,
                po_token_no,
                SYSDATE,
                1);

   SELECT TOKEN_ID
     INTO PO_TOKEN_ID
     FROM TBLTOKENQUEUE
    WHERE     TOKEN_NO = po_token_no
          AND BRANCH_ID = p_branch_id
          AND CONTACT_NO = p_contact_no
          AND service_type_id = p_service_type_id
          AND SERVICE_STATUS_ID = 1
          AND TRUNC (SERVICE_DATE) = TRUNC (SYSDATE);

   COMMIT;
END;
/




CREATE OR REPLACE PROCEDURE USP_Token_SelectAll
(
po_cursor OUT SYS_REFCURSOR
) is
quer varchar2(500) := ' ';
BEGIN
quer:='select tq.token_id,br.branch_name,tq.token_no,tq.service_date,st.service_status,tq.contact_no from tblTokenQueue tq inner join
tblBranch  br on br.branch_id=tq.branch_id 
inner join tblServiceStatus st on st.service_status_id=tq.service_status_id' ;
IF(quer IS NOT NULL) THEN
   open po_cursor for quer;
   --open po_cursor for select 'dasdasd' Namee, 7 numberss from dual;
END IF;
END;
/


/

insert into aspnetroles (ID, NAME) values ('04C1962A-2932-436D-AB41-EFA45FAEBA93', 'Token Generator');
insert into aspnetroles (ID, NAME) values ('94CA1073-EC72-419F-9FA7-1CF6AD1E869F', 'Branch Admin');
insert into aspnetroles (ID, NAME) values ('D538D955-FEBF-4D07-A886-33B4CBD7B89A', 'Service Holder');
insert into aspnetroles (ID, NAME) values ('DE82ACBE-ABAD-4662-A08B-B9C9C3C7AB6F', 'Admin');
insert into aspnetroles (ID, NAME) values ('E8F251F4-5D8E-45D8-B184-D1AA4BD7D3E0', 'Display User');


INSERT INTO AspNetUsers (Id, Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName) VALUES (N'0e41a9df-f724-4a7b-9285-0ad558ec898d', N'Mr. Shahjahan Mia', N'admin@khulna.com', 0, N'AET4SgyLvfO9HR/Do0CSqmPMeRehdeoWgXfEXRSO+VLBnP6xVB+0hOk56kLKnaelow==', N'815db956-5b8e-4f5f-a2b5-8673e1f2257a', NULL, 0, 0, NULL, 0, 0, N'admin@khulna.com');
INSERT INTO AspNetUsers (Id, Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName) VALUES (N'2d9afde4-4069-4b67-acdb-86c75cd8d6c4', N'Miss. Servica', N'service@khulna.com', 0, N'AMwRNo9722EcIfljxaZ3YNAVyh2xiwEYmOXvaS69j1VYrm/JQJR+h7BjS/AEl6m+Hg==', N'987838d7-9cb7-47ff-923e-7b50a554eb2e', NULL, 0, 0, NULL, 0, 0, N'service@khulna.com');
INSERT INTO AspNetUsers (Id, Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName) VALUES (N'52c62203-3e6b-42b8-9e5d-9bbd7abba42c', N'Mr. Tokonur Rahman', N'token@khulna.com', 0, N'AKTAB3B5IOi7b9pWcbA4XbqQJlaWVS0DMOOmg9kIS9pOaHGAXclpareDnon7KmwD/g==', N'68376b07-91e4-4266-9d24-4a94817bfa9c', NULL, 0, 0, NULL, 0, 0, N'token@khulna.com');
INSERT INTO AspNetUsers (Id, Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName) VALUES (N'96ee0940-e909-40f6-9521-1a0388cb081c', N'Monitor', N'display@khulna.com', 0, N'AG38zM+CyGXQxunDvdm28r3/i6WFfCuR81762agh4n9lwvgJTto6SJ9GlmMY0Q9qCQ==', N'553bb0bc-57e5-4d34-b330-9b7bd2022ccc', NULL, 0, 0, NULL, 0, 0, N'display@khulna.com');
INSERT INTO AspNetUsers (Id, Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName) VALUES (N'ae58e707-fc0e-4155-bb91-b1969aa7d904', N'CEO', N'sa@ssl.com', 0, N'AF7yz5o+Z2LgHvuJeh3tZzGCDPTlQ4DKN9Qhxh2muuN9Tgg7CV2o2nBQBGep9zFUhQ==', N'a1e07ae1-d7cf-45c8-9804-d69ecbe9dd4d', NULL, 0, 0, NULL, 0, 0, N'sa@ssl.com');

INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (N'0e41a9df-f724-4a7b-9285-0ad558ec898d', N'94CA1073-EC72-419F-9FA7-1CF6AD1E869F');
INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (N'2d9afde4-4069-4b67-acdb-86c75cd8d6c4', N'D538D955-FEBF-4D07-A886-33B4CBD7B89A');
INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (N'52c62203-3e6b-42b8-9e5d-9bbd7abba42c', N'04C1962A-2932-436D-AB41-EFA45FAEBA93');
INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (N'96ee0940-e909-40f6-9521-1a0388cb081c', N'E8F251F4-5D8E-45D8-B184-D1AA4BD7D3E0');
INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (N'ae58e707-fc0e-4155-bb91-b1969aa7d904', N'DE82ACBE-ABAD-4662-A08B-B9C9C3C7AB6F');

INSERT INTO tblBranch (branch_name, address, contact_person, contact_no, display_next) VALUES (N'Khulna', N'Khulna', N'Rifad', N'014443634634', 2);

INSERT INTO tblBranchUser (user_id, branch_id) VALUES (N'0e41a9df-f724-4a7b-9285-0ad558ec898d', 1);
INSERT INTO tblBranchUser (user_id, branch_id) VALUES (N'2d9afde4-4069-4b67-acdb-86c75cd8d6c4', 1);
INSERT INTO tblBranchUser (user_id, branch_id) VALUES (N'96ee0940-e909-40f6-9521-1a0388cb081c', 1);
INSERT INTO tblBranchUser (user_id, branch_id) VALUES (N'52c62203-3e6b-42b8-9e5d-9bbd7abba42c', 1);

INSERT INTO tblCounter (branch_id, counter_no, location) VALUES (1, N'1', N'Khulna Shadar');

INSERT INTO tblServiceStatus (service_status) VALUES (N'Initiate');
INSERT INTO tblServiceStatus (service_status) VALUES (N'In progress');
INSERT INTO tblServiceStatus (service_status) VALUES (N'Closed');
INSERT INTO tblServiceStatus (service_status) VALUES (N'Canceled');
INSERT INTO tblServiceStatus (service_status) VALUES (N'Skipped');

INSERT INTO tblServiceType (service_type_name) VALUES (N'Information');
INSERT INTO tblServiceType (service_type_name) VALUES (N'Sales');
INSERT INTO tblServiceType (service_type_name) VALUES (N'Customer Care');

INSERT INTO tblCustomerType (customer_type_name) VALUES (N'Normal');

INSERT INTO tblServiceSubType (service_type_id, service_sub_type_name, max_duration) VALUES (1, N'Multiple', 15);
INSERT INTO tblServiceSubType (service_type_id, service_sub_type_name, max_duration) VALUES (2, N'PHONE', 30);
INSERT INTO tblServiceSubType (service_type_id, service_sub_type_name, max_duration) VALUES (3, N'SIM', 20);
INSERT INTO tblServiceSubType (service_type_id, service_sub_type_name, max_duration) VALUES (1, N'4G', 20);

/


ALTER TABLE ASPNETUSERROLES
 DROP CONSTRAINT SYS_C0011012
/

ALTER TABLE ASPNETUSERROLES
 ADD CONSTRAINT SYS_C0011012 
  FOREIGN KEY (ROLEID) 
  REFERENCES ASPNETROLES (ID)
  ON DELETE CASCADE
  ENABLE VALIDATE
/

ALTER TABLE ASPNETUSERROLES
 DROP CONSTRAINT SYS_C0011013
/

ALTER TABLE ASPNETUSERROLES
 ADD CONSTRAINT SYS_C0011013 
  FOREIGN KEY (USERID) 
  REFERENCES ASPNETUSERS (ID)
  ON DELETE CASCADE
  ENABLE VALIDATE
/

ALTER TABLE TBLBRANCHUSER
 DROP CONSTRAINT SYS_C0011014
/

ALTER TABLE TBLBRANCHUSER
 ADD CONSTRAINT SYS_C0011014 
  FOREIGN KEY (USER_ID) 
  REFERENCES ASPNETUSERS (ID)
  ON DELETE CASCADE
  ENABLE VALIDATE
/