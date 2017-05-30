using System.Collections.Generic;

namespace Maratona.Models
{
    public class Usuario
    {
        public string NomeCompleto { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Nascimento { get; set; }
        public string ImagemSource { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
