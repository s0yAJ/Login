using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Data;
using System.Reflection;

namespace Login
{
    class Database
    {
        // create database school
        // go
        // 
        // use school
        // go
        // 
        // create table usuario(
        //     id int primary key identity,
        //     NombreUsuario varchar(50) not null unique,
        // 	Nombre varchar(50)not null,
        // 	Apellido varchar(50)not null,
        // 	contrasena varchar(50) not null,
        // 	roll int
        // )
        // 
        // create table roll(
        //     id int primary key identity,
        //     NOmbreDelRoll varchar(50)
        // )
        // 
        // alter table usuario add constraint fk_relacio_final
        // foreign key(roll) references roll(id)
        // 
        // 
        // insert into roll(NOmbreDelRoll)
        // values('Usuario'),
        // ('Admin')
        // 
        // insert into usuario(NombreUsuario, Nombre, Apellido, contrasena, roll)
        // values('Pracnanada_17@hotmail.com','Jakarta','Morales','asdfghjkl',2),
        // ('Julian_Rodrigo20@gmail.com','Julian','Rodrigo','qwertyuiop10',1),
        // ('Julio_Perales0@gmail.com','Julio','Perales','zxcvbnm12',1)
        // 
        // declare @n varchar(50)
        // declare @m varchar(50)
        // set @n = 'Pracnanada_17@hotmail.com'
        // set @m = 'asdfghjkl'
        // 
        // 
        // select u.Nombre, u.Apellido, r.NOmbreDelRoll from usuario u
        // inner join roll r on r.id = u.roll where NombreUsuario = @n and contrasena COLLATE Latin1_General_CS_AS = @m

        private string cadenaConexion = "Data source=DESKTOP-V8M85T4; database=school; Integrated security=true;";

        public static string NombreCompleto = "";
        public static string TipoDeUsuario = "";

        public Boolean IniciarSeccion(string n, string m)
        {
            NombreCompleto = "";
            TipoDeUsuario = "";

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlParameter parn = new SqlParameter("@n", n);
            SqlParameter parm = new SqlParameter("@m", m);

            SqlCommand command = new SqlCommand("select u.Nombre,u.Apellido,r.NOmbreDelRoll from usuario u inner join roll r on r.id = u.roll where NombreUsuario = @n and contrasena COLLATE Latin1_General_CS_AS = @m", cn);
            
            command.Parameters.Add(parn);
            command.Parameters.Add(parm);

            SqlDataReader lec = command.ExecuteReader();

            while (lec.Read())
            {
                NombreCompleto = lec.GetString(0) + " " + lec.GetString(1);
                TipoDeUsuario = lec.GetString(2);
            }
            lec.Close();
            cn.Close();
            if (String.IsNullOrEmpty(TipoDeUsuario))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        
        public string Crear(string nom, string ape, string con, string usu)
        {
            string res;
            byte num = 1;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            var cadena = $"insert into usuario(NombreUsuario,Nombre,Apellido,contrasena,roll)values('{usu}','{nom}','{ape}','{con}','{num}')";
            SqlCommand coman = new SqlCommand(cadena,cn);
            res = coman.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
            cn.Close();

            return res;
        }

    }
}
