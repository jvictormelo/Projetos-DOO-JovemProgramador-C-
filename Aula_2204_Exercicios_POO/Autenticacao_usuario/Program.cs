
class Program{

    static void Main(string[] args)
    {
        ICadastrador cadastrador = new Cadastrador();
        IPessoa pessoa = new Supervisor();
        cadastrador.cadastrarUsuario();
        pessoa.MostrarDados();
        
        

}


}


