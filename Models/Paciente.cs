
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVacina.Models
{
    public class Paciente
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        //DataType serve para não precisar preencher hora
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}