@echo comenzando instalacion de base de datos Academico
sqlcmd -S. -E -i "BDAcademico.sql"
sqlcmd -S. -E -i "PATCarrera.sql"
@echo finalizada instalacion de base de datos
pause