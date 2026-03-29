using AplicacaoBanco.Repository.Contract;

namespace AplicacaoBanco.Models
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly string _conexaoMySQL;

        public EnderecoRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.getConnectionString("ConexaoMySql");
        }
        public void Atualizar(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Endereco endereco)
        {
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into Endereco(CEP, Estado, Cidade, Bairro,  " +
                    " Logradouro, Complemento, Numero)" +
                    "values (@CEP, @ESTADO, @CIDADE, @BAIRRO, @LOGRADOURO, @COMPLEMENTO, @NUMERO)", conexao);

                    cmd.Parameters.Add(@CEP, MySqlDbType.Varchar).Value = endereco.CEP;
                    cmd.Parameters.Add(@ESTADO, MySqlDbType.Varchar).Value = endereco.Estado;
                    cmd.Parameters.Add(@CIDADE, MySqlDbType.Varchar).Value = endereco.Cidade;
                    cmd.Parameters.Add(@BAIRRO, MySqlDbType.Varchar).Value = endereco.Bairro;
                    cmd.Parameters.Add(@LOGRADOURO, MySqlDbType.Varchar).Value = endereco.Logradouro;
                    cmd.Parameters.Add(@COMPLEMENTO, MySqlDbType.Varchar).Value = endereco.Complemento;
                    cmd.Parameters.Add(@NUMERO, MySqlDbType.Varchar).Value = endereco.Numero;

                    cmd.ExecuteNonQuery();

                    conexao.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no banco em cadastro cliente" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação em cadastro cliente" + ex.Message);
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Endereco ObterEndereco(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> ObterTodosEnderecos()
        {
            List<Endereco> endList = new List<EnderecoRepositorio>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ENDERECO", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    endList.Add(
                        new Endereco
                        {
                            Id = Convert.Toint32(dr["Id"]),
                            CEP = Convert.ToString(dr["CEP"]),
                            Estado = Convert.ToString(dr["Estado"]),
                            Cidade = Convert.ToString(dr["Cidade"]),
                            Bairro = Convert.ToString(dr["Bairro"]),
                            Logradouro = Convert.ToString(dr["Logradouro"]),
                            Complemento = Convert.ToString(dr["Complemento"]),
                            Numero = Convert.Toint32(dr["Numero"]),
                        }
                    );
                }
                return endList;
            }
        }
    }
}