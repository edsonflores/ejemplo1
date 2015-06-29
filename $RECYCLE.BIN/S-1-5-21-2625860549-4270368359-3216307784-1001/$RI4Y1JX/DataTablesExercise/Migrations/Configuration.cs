namespace DataTablesExercise.Migrations
{
    using DataTablesExercise.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataTablesExercise.Models.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataTablesExercise.Models.StudentContext context)
        {
            /*context.Students.AddOrUpdate(
                s => s.Id,
                new Student { Name = "Edson", Surname = "Flores", Ci = 5989556, Birthdate = DateTime.Parse("23/11/1984") },
                new Student { Name = "Ayda", Surname = "Campos", Ci = 6052487, Birthdate = DateTime.Parse("09/08/1989") },
                new Student { Name = "Daniela", Surname = "Alcazar", Ci = 6025877, Birthdate = DateTime.Parse("20/06/1990") },
                new Student { Name = "Jimena", Surname = "Ruiz", Ci = 4885133, Birthdate = DateTime.Parse("06/11/1979") },
                new Student { Name = "Rosario", Surname = "Sanjinez", Ci = 3258965, Birthdate = DateTime.Parse("23/02/1986") },
                new Student { Name = "Maricruz", Surname = "Ribera", Ci = 8054779, Birthdate = DateTime.Parse("23/12/1988") },
                new Student { Name = "Lourdes", Surname = "Villar", Ci = 3587441, Birthdate = DateTime.Parse("23/04/1988") },
                new Student { Name = "Reyna", Surname = "Gomez", Ci = 5125896, Birthdate = DateTime.Parse("25/05/1995") },
                new Student { Name = "Cinthia", Surname = "Tarquino", Ci = 6055882, Birthdate = DateTime.Parse("13/10/1994") },
                new Student { Name = "Franz", Surname = "Pacajes", Ci = 4875441, Birthdate = DateTime.Parse("17/02/1999") },
                new Student { Name = "Alvaro", Surname = "Tarqui", Ci = 3699741, Birthdate = DateTime.Parse("11/10/1986") },
                new Student { Name = "Ricardo", Surname="Alcazar", Ci=5092741,Birthdate=DateTime.Parse("02/11/1980") },
                new Student { Name = "Jose", Surname="Mendieta", Ci=4855778,Birthdate=DateTime.Parse("11/10/1977") },
                new Student { Name = "Ramiro", Surname="Morales", Ci=5698741,Birthdate=DateTime.Parse("13/11/1975") },
                new Student { Name = "Anabel", Surname="Quintana", Ci=6022102,Birthdate=DateTime.Parse("22/05/1999") },
                new Student { Name = "Rosa", Surname="Magne", Ci=3699874,Birthdate=DateTime.Parse("30/04/1998") },
                new Student { Name = "Karen", Surname="Felipez", Ci=8259865,Birthdate=DateTime.Parse("18/03/1995") },
                new Student { Name = "Lilian", Surname="Ramirez", Ci=9025589,Birthdate=DateTime.Parse("19/02/1990") },
                new Student { Name = "Heber", Surname="Sanchez", Ci=4985225,Birthdate=DateTime.Parse("12/12/1989") },
                new Student { Name = "Alfonso", Surname="Lopez", Ci=6029874,Birthdate=DateTime.Parse("10/11/1988") },
                new Student { Name = "Adolfo", Surname="Tarquino", Ci=5025896,Birthdate=DateTime.Parse("08/10/1984") },
                new Student { Name = "Marco", Surname="Ramirez", Ci=6547898,Birthdate=DateTime.Parse("13/09/1970") },
                new Student { Name = "Pablo", Surname="Rodriguez", Ci=6025897,Birthdate=DateTime.Parse("07/07/1951") },
                new Student { Name = "Diego", Surname="Campos", Ci=7042589,Birthdate=DateTime.Parse("28/12/1953") },
                new Student { Name = "Esteban", Surname="Flores", Ci=7042589,Birthdate=DateTime.Parse("25/11/1985") },
                new Student { Name = "Concepcion", Surname="Castillo", Ci=5984565,Birthdate=DateTime.Parse("17/04/1986") },
                new Student { Name = "Malena", Surname="Loza", Ci=6258410,Birthdate=DateTime.Parse("11/10/1986") },
                new Student { Name = "Lizeth", Surname="Quisbert", Ci=5985522,Birthdate=DateTime.Parse("12/08/1984") },
                new Student { Name = "María", Surname="Ferreira", Ci=6233214,Birthdate=DateTime.Parse("13/10/1990") },
                new Student { Name = "Mario", Surname="Lopez", Ci=7487452,Birthdate=DateTime.Parse("14/11/1991") }

            );*/

            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 1; i <= 4970; i++)
            {
                string nombre = "Student " + r.Next(1, 5000);
                string apellido = "Surname " + r.Next(1, 5000);
                int carnet = r.Next(4000000, 9000000);
                string fnac = Convert.ToString(r.Next(1, 28)) + "/" + Convert.ToString(r.Next(1, 12)) + "/" + Convert.ToString(r.Next(1970, 1995));

                context.Students.AddOrUpdate(
                    s => s.Id,
                    new Student { Name = nombre, Surname = apellido, Ci = carnet, Birthdate = DateTime.Parse(fnac) }
                );
            }

        }
    }
}
