using Maratona.Models;
using System.Collections.Generic;
using System.Linq;

namespace Maratona.Services
{
    public static class UsuarioService
    {
        public static Usuario ClaimsParaUsuario(AuthClient facebookUser)
        {
            if (facebookUser == null)
                return null;

            Usuario User = new Usuario();

            User.NomeCompleto = facebookUser.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")).Value;
            User.Nome = facebookUser.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
            User.Sobrenome = facebookUser.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")).Value;
            User.Sexo = facebookUser.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender")).Value;
            User.Email = facebookUser.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")).Value;
            User.Nascimento = facebookUser.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth")).Value;

            return User;
        }

        public static Usuario NovoUsuario()
        {
            var Usuario = new Usuario()
            {
                Tarefas = new List<Tarefa>()
            };
            Usuario.Nome = "Guilherme";
            Usuario.Sobrenome = "Camargo";
            Usuario.NomeCompleto = "Gui Silva";
            Usuario.Email = "guisfits@hotmail.com";
            Usuario.Nascimento = "23/12/1993";
            Usuario.Sexo = "Masculino";
            Usuario.ImagemSource = "https://scontent.fsod1-1.fna.fbcdn.net/v/t1.0-9/18582277_1377795535647272_2884071119668782978_n.jpg?oh=8893964a499be9503e1c06b46a11abf0&oe=59BC2932";

            var tarefas = new List<Tarefa>()
            {
                new Tarefa() { Nome = "Prova", Descricao="Hackaton", Local="FIAP", Data = new System.DateTime(2017,07,01)},
                new Tarefa() { Nome = "Exame", Descricao="Sangue", Local="Posto de saúde", Data = new System.DateTime(2017,06,14)},
                new Tarefa() { Nome = "Consulta", Descricao="Volta ao médico", Local="Clínica", Data = new System.DateTime(2017,06,30)},
                new Tarefa() { Nome = "Viagem", Descricao="Ferias", Local="Praia", Data = new System.DateTime(2017,12,01)},
                new Tarefa() { Nome = "Aniversario", Descricao="Aniversario", Local="Casa", Data = new System.DateTime(2017,12,23)},
            };
            foreach(var tarefa in tarefas)
                Usuario.Tarefas.Add(tarefa);

            return Usuario;
        }
    }
}
