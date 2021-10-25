using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Cargo
    {
        public int Id { get; init; }
        public string NomeCargo { get; private set; }
        public string Descricao { get; private set; }

        private Cargo(int id)
        {
            Id = id;
        }

        public static Cargo NovoCargo(int idCargo, string nome, string descricao)
        {
            if (nome != null &&
                descricao != null &&
                !String.IsNullOrWhiteSpace(nome) &&
                !String.IsNullOrWhiteSpace(descricao))
            {
                var cargo = new Cargo(idCargo);
                cargo.NomeCargo = nome;
                cargo.Descricao = descricao;
                return cargo;
            }
            else
            {
                return null;
            }
        }

        public bool AlterarNome(string nome)
        {
            if (nome != null &&
                !String.IsNullOrWhiteSpace(nome))
            {
                NomeCargo = nome;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarDescricao(string descricao)
        {
            if (descricao != null &&
                !String.IsNullOrWhiteSpace(descricao))
            {
                Descricao = descricao;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
