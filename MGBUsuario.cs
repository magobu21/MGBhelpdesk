using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGBLogicaHelpdesk
{
    public class MGBUsuario
    {
        //propiedades de la clase usuario
        private string emailUsuario;
        private string nombreUsuario;
        private string telefonoUsuario;
        private string areaUsuario;
        private int perfilUsuario;

        public void EscribirEmail(string email)
        {
            this.emailUsuario = email;
        }

        public void EscribirNombre(string nom)
        {
            this.nombreUsuario = nom;
        }

        public void EscribirTelefono(string tel)
        {
            this.telefonoUsuario = tel;
        }

        public void EscribirArea(string area)
        {
            this.areaUsuario = area;
        }

        public void EscribirPerfil(int perf)
        {
            this.perfilUsuario = perf;
        }

        public string LeerEmail()
        {
            return this.emailUsuario;
        }

        public string LeerNombre()
        {
            return this.nombreUsuario;
        }

        public string LeerTelefono()
        {
            return this.telefonoUsuario;
        }

        public string LeerArea()
        {
            return this.areaUsuario;
        }

        public int LeerPerfil()
        {
            return this.perfilUsuario;
        }

        public string EmailUsuario
        {
            get => emailUsuario;
            set => emailUsuario = value;
        }

        public string NombreUsuario
        {
            get => nombreUsuario;
            set => nombreUsuario = value;
        }

        public string TelefonoUsuario
        {
            get => telefonoUsuario;
            set => telefonoUsuario = value;
        }

        public string AreaUsuario
        {
            get => areaUsuario;
            set => areaUsuario = value;
        }

        public int PerfilUsario
        {
            get => perfilUsuario;
            set => perfilUsuario = value;
        }

        private string comando;

        public void crearcliente()
        {
            string insertarcadenacl;
            insertarcadenacl = "INSERT INTO Usuarios_mgb (usuarios_email,usuarios_nombre,usuarios_celular,usuarios_area, usuarios_perfil) VALUES('" + this.emailUsuario + "','" + this.nombreUsuario + "','" + this.telefonoUsuario + "','" + this.areaUsuario + "','" + this.perfilUsuario + "')";
            comando = insertarcadenacl;
        }




    }

}
