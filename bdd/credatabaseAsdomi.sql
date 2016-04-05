drop database if exists asdomi;
create database asdomi;
USE asdomi

CREATE TABLE patient
(numSS char(13) not null,
 nomPatient char(20),
 prenomPatient char(15),
 ruePatient char(50),
 villePatient char(20),
 cpPatient char(5),
 datenaissPatient date)engine = innodb;

 
 
 alter table patient
   add primary key (numSS);
   
   describe patient;


 
 CREATE TABLE salarie
(numSalarie int not null  AUTO_INCREMENT primary key,
 nomSalarie char(20),
 prenomSalarie char(15),
 telSalarie char(10))engine = innodb;
 
 /*alter table salarie
   add primary key (numSalarie);  */

 describe salarie;

CREATE TABLE vehicule
(numVehicule int not null AUTO_INCREMENT primary key,
noImmat char(10),
marque char(20), 
categorie char (5),
dateAcquisition date)engine = innodb;

/* alter table vehicule
   add primary key (numVehicule); */

describe vehicule;
	
CREATE TABLE intervention
(numSalarie int not null,
dateIntervention date not null,
heureDebut time not null,  
dureeIntervention int, 
nbKm int, 
numSS char(13), 
numVehicule int)engine = innodb;

alter table intervention
   add primary key (numSalarie, dateIntervention, heureDebut);
   
 alter table intervention
 add constraint FK_intervention_salarie foreign key (numSalarie)
      references salarie (numSalarie);  
	  
	  alter table intervention
 add constraint FK_intervention_vehicule foreign key (numVehicule)
      references vehicule (numVehicule);  
	
describe intervention;

INSERT INTO patient VALUES
('2081101053012', 'BIENASSIS', 'Marie', '2 rue du docteur Long','Bourg En Bresse','01000','1908-11-13'),
('1250601086108', 'DUPOND', 'Jules', '5 rue du docteur Millet','Pont d''Ain','01150','1925-06-29'),
('2341001235857', 'DURAND', 'Elodie', '9 rue Paul Verlaine','Montluel','01120','1934-10-12'),
('1310301426125', 'PETIT', 'Arthur', '15 avenue Général De Gaulle','Bourg En Bresse','01000','1931-03-16'),
('2240501129521', 'MARTIN', 'Jacqueline', '18 rue des ajoncs','Pont d''Ain','01150','1924-05-03'),
('1180901654123', 'LEROY', 'Pierre', '5 rue  Molitor','Pont d''Ain','01150','1918-09-16'),
('2200801153624', 'LEROY', 'Jeanne', '5 rue Thouin ','Pont d''Ain','01150','1920-08-13'),
('1270301235412', 'LAMOTTE', 'Annick', '5 allée des Pervenches','Bourg En Bresse','01000','1927-03-25'),
('1290101263125', 'PICHON', 'Philippe', '8 allée des Violettes','Montluel','01120','1929-01-23'),
('2311201321654', 'PICHON', 'Bénédicte', '8 allée des Violettes','Montluel','01120','1931-12-20'),
('1080901053020', 'LONGWY', 'Marcel', '2 rue du Général Leclerc','Bourg En Bresse','01000','1908-11-13');
 
 select * from patient;
 
 INSERT INTO salarie (nomSalarie, prenomSalarie,telSalarie) VALUES
( 'DABARD', 'Rosine', '0685142679'),
( 'RENOUAL', 'Emilie', '0652416398'),
( 'TARAUD', 'Alain', '0652894123');

select * from salarie;

INSERT INTO vehicule (noImmat, marque,categorie, dateAcquisition) VALUES
( 'AC-352-GH', 'Renault', '5CV','2011-05-18'),
( 'FL-756-PM', 'Fiat', '5CV','2012-11-26'),
( 'DG-865-QV', 'Peugeot', '7CV','2013-04-22');
	
select * from vehicule;

insert into intervention values
(1,'2013-05-02', '10:00:00',45, 5, '2081101053012', 1),
(1,'2013-05-02', '11:00:00',90, 8, '2341001235857', 1),
(1,'2013-05-02', '14:00:00',60, 15, '2240501129521', 1),
(1,'2013-05-02', '15:30:00',45, 4, '1270301235412', 1),
(1,'2013-05-02', '16:30:00',60, 6, '1080901053020', 1),
(2,'2013-05-03', '09:00:00',45, 3, '2311201321654', 3),
(2,'2013-05-03', '10:00:00',60, 8, '2081101053012', 3),
(2,'2013-05-03', '11:15:00',30, 18, '1270301235412', 3),
(2,'2013-05-03', '13:30:00',60, 2, '1180901654123', 3),
(2,'2013-05-03', '14:45:00',45, 3, '2200801153624', 3),
(2,'2013-05-03', '16:00:00',60, 10, '2341001235857', 3),
(3,'2013-05-02', '10:00:00',75, 3, '1250601086108', 2),
(3,'2013-05-02', '13:00:00',45, 3, '2081101053012', 2),
(3,'2013-05-03', '10:00:00',90, 15, '1250601086108', 2),
(3,'2013-05-03', '13:30:00',120, 5, '1080901053020', 2);


select * from intervention;


select s.nomSalarie, i.dateIntervention, i.heureDebut, p.nomPatient, p.prenomPatient, v.noImmat 
from intervention i, salarie s, patient p, vehicule v
where i.numSalarie = s.numSalarie
and i.numSS = p.numSS
and i.numVehicule = v.numVehicule
order by s.nomSalarie,  i.dateIntervention, i.heureDebut ;


