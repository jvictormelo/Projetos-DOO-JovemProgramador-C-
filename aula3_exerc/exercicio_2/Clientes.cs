public class Clientes
    {
        private  int proximoId = 1;

        public int Id { get; private set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Endereco Endereco { get; set; }

        public Clientes(string nome, int idade, Endereco endereco)
        {
            this.Id = proximoId++;
            this.Nome = nome;
            this.Idade = idade;
            this.Endereco = endereco;
        }
    }
