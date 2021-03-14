
using System;

namespace AgendaVacina.Models
{
    public class Usuario
    {
     
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Boolean Administrador { get; set; }
    }
}